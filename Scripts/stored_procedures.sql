-- SP para insertar usuario
CREATE OR REPLACE FUNCTION sp_insert_user(
    p_name VARCHAR,
    p_phone VARCHAR,
    p_address VARCHAR,
    p_country_id INT,
    p_state_id INT,
    p_city_id INT
) RETURNS INT AS $$
DECLARE
    new_id INT;
BEGIN
    INSERT INTO users(name, phone, address, country_id, state_id, city_id)
    VALUES (p_name, p_phone, p_address, p_country_id, p_state_id, p_city_id)
    RETURNING user_id INTO new_id;

    RETURN new_id;
END;
$$ LANGUAGE plpgsql;

-- SP para obtener todos los usuarios con nombres de país, estado y ciudad
CREATE OR REPLACE FUNCTION sp_get_users()
RETURNS TABLE(
    user_id INT,
    name VARCHAR,
    phone VARCHAR,
    address VARCHAR,
    country_id INT,
    country_name VARCHAR,
    state_id INT,
    state_name VARCHAR,
    city_id INT,
    city_name VARCHAR
) AS $$
BEGIN
    RETURN QUERY
    SELECT 
        u.user_id,
        u.name,
        u.phone,
        u.address,
        u.country_id,
        c.name AS country_name,
        u.state_id,
        s.name AS state_name,
        u.city_id,
        ci.name AS city_name
    FROM users u
    JOIN country c ON u.country_id = c.country_id
    JOIN state s ON u.state_id = s.state_id
    JOIN city ci ON u.city_id = ci.city_id;
END;
$$ LANGUAGE plpgsql;
