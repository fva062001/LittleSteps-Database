use Little_steps

create database Little_steps
go 

create table usuario
(
usuario varchar(16) UNIQUE,
contrasena varchar(12),
);
//----------------------------------------------------------------------------------------------//

create table estudiante
(
matricula int PRIMARY KEY,
nombre varchar(10) NOT NULL,
apellido varchar(10) NOT NULL,
sexo char(1) NOT NULL,
fecha_nacimiento date NOT NULL,
edad as CONVERT(INT, ROUND(DATEDIFF(HOUR, fecha_nacimiento, GETDATE()) / 8766.0, 0)),
grado int NOT NULL, 
id_tutor varchar(13) FOREIGN KEY REFERENCES tutor(cedula) NOT NULL
);

create trigger verificar_edad on estudiante
after insert 
as
begin
BEGIN TRANSACTION
declare @edad int
set @edad = (select edad from inserted)
Print @edad
if @edad not between 3 and 5
	ROLLBACK TRANSACTION
END

//-----------------------------------------------------------------------------------------------------//

create table tutor
(
cedula varchar(13) PRIMARY KEY,
nombre varchar(13) NOT NULL,
apellido varchar(13) NOT NULL,
fecha_nacimiento date NOT NULL,
email varchar(23) NOT NULL,
direccion varchar(30),
telefono varchar(13) NOT NULL
);

//----------------------------------------------------------------------------------------------//

create table profesor
(
matricula int PRIMARY KEY,
nombre varchar(13) NOT NULL,
apellido varchar(13) NOT NULL,
email varchar(23) NOT NULL,
telefono varchar(13) NOT NULL,
fecha_nacimiento date NOT NULL,
fecha_entrada date DEFAULT GETDATE()
);

//----------------------------------------------------------------------------------------------//

create table clase
(
idClase int PRIMARY KEY,
nombre_clase varchar(20),
horario time,
dias_clase varchar(20),
ubicacion varchar(20),
grado varchar(4),
alumnos_inscritos int
);

//----------------------------------------------------------------------------------------------//

create table evaluacion
(
idEvaluacion int IDENTITY(1,1) PRIMARY KEY,
fecha_evaluacion date NOT NULL,
nota_evaluacion int NOT NULL,
curso_evaluacion int NOT NULL, 
);

//----------------------------------------------------------------------------------------------//

create table asignacion
(
idAsignacion int IDENTITY(1,1) PRIMARY KEY NOT NULL,
fecha_entrega date NOT NULL,
nota_asignacion int NOT NULL
);

//----------------------------------------------------------------------------------------------//

create table factura
(
idFactura int IDENTITY(1,1) PRIMARY KEY,
fecha_pago date default GETDATE(),
importe money NOT NULL,
cedula_tutor varchar(13) FOREIGN KEY REFERENCES tutor(cedula) NOT NULL
);

create procedure efectuar_factura @importe money, @cedula_tutor varchar(13)
as
begin
insert into factura(importe, cedula_tutor) values (@importe, @cedula_tutor)
end
go

//----------------------------------------------------------------------------------------------//