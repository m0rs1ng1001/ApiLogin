
create database ApiLogin;

use ApiLogin;



create table usuario(
correo varchar(30),
contraseņa varchar (30),
);

select * from usuario;

insert into usuario(correo,contraseņa)values('santi.3015@gmail.com','123456');


create procedure usar_correo(
@correo varchar (30),
@contraseņa varchar (30)
)
as
begin
insert into usuario(correo,contraseņa)
values (@correo,@contraseņa) 
end;

execute usar_correo 'luis.3015@gmail.com','123455';