-- Tabla de Países
CREATE TABLE country (
    country_id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL
);

-- Tabla de Estados/Departamentos
CREATE TABLE state (
    state_id SERIAL PRIMARY KEY,
    country_id INT REFERENCES country(country_id),
    name VARCHAR(100) NOT NULL
);

-- Tabla de Ciudades
CREATE TABLE city (
    city_id SERIAL PRIMARY KEY,
    state_id INT REFERENCES state(state_id),
    name VARCHAR(100) NOT NULL
);

-- Tabla de Usuarios
CREATE TABLE users (
    user_id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    phone VARCHAR(20) NOT NULL,
    address VARCHAR(255),
    country_id INT REFERENCES country(country_id),
    state_id INT REFERENCES state(state_id),
    city_id INT REFERENCES city(city_id)
);
