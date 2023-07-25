
create database ApiLogin;

use ApiLogin;

drop table usuario;

create table usuario(
id_usuario int primary key,
correo varchar(30),
contraseña varchar (255),
);



create table usuarioR
(
	id_usuarioR int primary key,
    nombresR varchar(100),
    apellidosR varchar(100),
	telefonoR varchar(20),
    correoR varchar(200),
    contraseñaR varchar(255)
);


select * from usuarioR;

insert into usuarioR(id_usuarioR,nombresR,apellidosR,telefonoR,correoR,contraseñaR)values(3,'valentina','valencia','3101514522','vale.3015@gmail.com','123123');


drop procedure listar_correo2;


create proc listar_correo2

as
begin
select
id_usuarioR,nombresR,apellidosR,telefonoR,correoR,contraseñaR
from UsuarioR
end;

execute listar_correo2