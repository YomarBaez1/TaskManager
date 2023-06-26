# TaskManager

Query
-- Crear la base de datos TaskManagerDB
CREATE DATABASE TaskManagerDB;

-- Usar la base de datos TaskManagerDB
USE TaskManagerDB;

-- Crear la tabla Tasks
CREATE TABLE Tasks (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion VARCHAR(255),
    FechaCreacion DATETIME,
    Estado VARCHAR(50),
    Prioridad INT
);

Datos que puede agregar a la tabla.

INSERT INTO Tasks (Descripcion, FechaCreacion, Estado, Prioridad)
VALUES ('Tarea 1', '2022-01-01', 'Pendiente', 1),
       ('Tarea 2', '2022-02-01', 'En progreso', 2),
       ('Tarea 3', '2022-03-01', 'Completada', 3);
