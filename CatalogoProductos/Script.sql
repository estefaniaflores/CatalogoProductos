﻿use ProductoDB
CREATE TABLE Productos
(
	Id INT IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(100) NOT NULL, 
	Descripcion VARCHAR(100) NOT NULL, 
	Categoria VARCHAR(100) NOT NULL, 
	FotoURL VARCHAR(max) NOT NULL 
)