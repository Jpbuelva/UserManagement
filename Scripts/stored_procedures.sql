-- SP para insertar usuario

CREATE OR REPLACE FUNCTION public.sp_insert_user(
	p_name character varying,
	p_phone character varying,
	p_address character varying,
	p_country_id integer,
	p_state_id integer,
	p_city_id integer)
    RETURNS integer
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
DECLARE
    new_id INT;
    v_count INT;
BEGIN
    -- Validaciones
    SELECT COUNT(*) INTO v_count FROM country WHERE country_id = p_country_id;
    IF v_count = 0 THEN
        RAISE EXCEPTION 'El CountryId % no existe', p_country_id;
    END IF;

    SELECT COUNT(*) INTO v_count FROM state WHERE state_id = p_state_id AND country_id = p_country_id;
    IF v_count = 0 THEN
        RAISE EXCEPTION 'El StateId % no existe o no pertenece al CountryId %', p_state_id, p_country_id;
    END IF;

    SELECT COUNT(*) INTO v_count FROM city WHERE city_id = p_city_id AND state_id = p_state_id;
    IF v_count = 0 THEN
        RAISE EXCEPTION 'El CityId % no existe o no pertenece al StateId %', p_city_id, p_state_id;
    END IF;

    -- Insertar usuario
    INSERT INTO users(name, phone, address, country_id, state_id, city_id)
    VALUES (p_name, p_phone, p_address, p_country_id, p_state_id, p_city_id)
    RETURNING user_id INTO new_id;

    RETURN new_id;
END;
$BODY$;

ALTER FUNCTION public.sp_insert_user(character varying, character varying, character varying, integer, integer, integer)
    OWNER TO postgres;


-- SP para obtener todos los usuarios con nombres de país, estado y ciudad
-- FUNCTION: public.sp_get_users()

-- DROP FUNCTION IF EXISTS public.sp_get_users();

CREATE OR REPLACE FUNCTION public.sp_get_users()
RETURNS TABLE(
    "UserId"      INT,
    "Name"        VARCHAR,
    "Phone"       VARCHAR,
    "Address"     VARCHAR,
    "CountryId"   INT,
    "CountryName" VARCHAR,
    "StateId"     INT,
    "StateName"   VARCHAR,
    "CityId"      INT,
    "CityName"    VARCHAR
) 
LANGUAGE plpgsql
AS $BODY$
BEGIN
    RETURN QUERY
    SELECT 
        u.user_id    AS "UserId",
        u.name       AS "Name",
        u.phone      AS "Phone",
        u.address    AS "Address",
        u.country_id AS "CountryId",
        c.name       AS "CountryName",
        u.state_id   AS "StateId",
        s.name       AS "StateName",
        u.city_id    AS "CityId",
        ci.name      AS "CityName"
    FROM users u
    LEFT JOIN country c ON u.country_id = c.country_id
    LEFT JOIN state s   ON u.state_id = s.state_id
    LEFT JOIN city ci   ON u.city_id = ci.city_id;
END;
$BODY$;

ALTER FUNCTION public.sp_get_users()
    OWNER TO postgres;


