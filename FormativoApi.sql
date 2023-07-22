
create database ApiLogin;

use ApiLogin;



create table usuario(
correo varchar(30),
contraseña varchar (30),
);

select * from usuario;

insert into usuario(correo,contraseña)values('santi.3015@gmail.com','123456');


create procedure usar_correo(
@correo varchar (30),
@contraseña varchar (30)
)
as
begin
insert into usuario(correo,contraseña)
values (@correo,@contraseña) 
end;

execute usar_correo 'luis.3015@gmail.com','123455';