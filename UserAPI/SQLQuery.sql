CREATE DATABASE DVP_Test;
GO

CREATE SCHEMA person_service;
GO

CREATE TABLE person_service.persons (
    id INT PRIMARY KEY NOT NULL IDENTITY (1, 1),
    first_name VARCHAR (50) NOT NULL,
    last_name VARCHAR (50) NOT NULL,
	email VARCHAR(50),
    document_type VARCHAR(50),
    document_number INT NOT NULL,
	created_at DATETIME DEFAULT GETDATE(),
	[full_name] AS ([first_name] + ' ' + [last_name]),
	[full_document] AS ([document_type] + ' ' + [document_number])
);
GO

CREATE TABLE person_service.users (
    id INT PRIMARY KEY NOT NULL IDENTITY (1, 1),
    username VARCHAR (50) NOT NULL,
    pass VARCHAR (50) NOT NULL,
	created_at DATETIME DEFAULT GETDATE()
);
GO

CREATE PROCEDURE procedure_select_persons
AS
SELECT * FROM person_service.persons
GO

EXEC procedure_select_persons;