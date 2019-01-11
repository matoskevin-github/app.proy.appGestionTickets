USE MASTER
CREATE DATABASE TICKETSBD
GO
USE TICKETSBD
GO
CREATE TABLE ESTADO (
  IDESTADO int IDENTITY (1,1) PRIMARY KEY NOT NULL,
  NOMBRE varchar(20),
  ACTIVO bit
)
CREATE TABLE RESPONSABLE (
  IDRESPONSABLE int IDENTITY (1,1) PRIMARY KEY NOT NULL,
  NOMBRES varchar(50),
  APELLIDOS varchar(50),
  EMAIL varchar(50),
  CARGO varchar(80),
  ACTIVO bit
)
CREATE TABLE USUARIO (
  IDUSUARIO int IDENTITY (1,1) PRIMARY KEY NOT NULL,
  NOMBRES varchar(50),
  APELLIDOS varchar(50),
  TELEFONOS varchar(20),
  EMAIL varchar(50),
  ACTIVO bit
)
CREATE TABLE TICKETS (
  IDTICKET int IDENTITY (1,1) PRIMARY KEY NOT NULL,
  FECHAGENERACION datetime,
  IDESTADO int FOREIGN KEY REFERENCES ESTADO (IDESTADO),
  IDUSUARIO int FOREIGN KEY REFERENCES USUARIO (IDUSUARIO), 
  DESCRIPCION varchar(255), 
  IDRESPONSABLE int FOREIGN KEY REFERENCES RESPONSABLE (IDRESPONSABLE),
  SOLUCION varchar(255)
) 

/*
USE MASTER
DROP DATABASE TICKETSBD
bit => 1 = true  y 0 = false
*/

insert ESTADO values ('Abierto',1)
insert ESTADO values ('En Gestion',1)
insert ESTADO values ('Cerrado',1)

insert RESPONSABLE values ('Jorge','Londoño','jorge@gmail.com','Analisa de Soporte',1)
insert RESPONSABLE values ('Ana','Ramirez','ana@gmail.com','Analista de Infraestructura',1)

insert USUARIO values ('Carlos','Arango','014144533','carlos.arango@gmail.com',1);

insert TICKETS values (GETDATE() ,1,1,'No se pueden enviar correos.',2,null)
insert TICKETS values (GETDATE() ,2,1,'Error de impresion documentos.',1,null)

select * from TICKETS
select * from ESTADO
select * from RESPONSABLE
delete from Tickets where IdTicket = 9