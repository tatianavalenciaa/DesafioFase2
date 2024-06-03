/* ============================== */
-- CREACION DE BASE DE DATOS
/* ============================== */

drop database if exists sitio_web_udb;
create database sitio_web_udb;
go

use sitio_web_udb;
go

/* ============================== */
-- CREACION DE TABLAS
/* ============================== */

/* --------------------------------
Tabla: usuario
-------------------------------- */

drop table if exists usuario;
create table usuario (
	id_usuario int primary key identity(1,1),
	usuario varchar(100) not null,
	password varchar(100) not null,
	fecha_crea datetime not null default getdate(),
	fecha_modi datetime not null default getdate(),
	activo char(1) default 'S'
);

drop table if exists informacion;
create table informacion (
	id_informacion int primary key identity(1,1),
	informacion varchar(1000) not null,
	url_video varchar(500) not null,
	user_crea int not null default 1,
	fecha_crea datetime not null default getdate(),
	user_modi int not null default 1,
	fecha_modi datetime not null default getdate(),
	activo char(1) default 'S',
);

drop table if exists noticia;
create table noticia (
	id_noticia int primary key identity(1,1),
	titulo varchar(100) not null,
	descripcion varchar(1000) not null,
	user_crea int not null default 1,
	fecha_crea datetime not null default getdate(),
	user_modi int not null default 1,
	fecha_modi datetime not null default getdate(),
	activo char(1) default 'S',
);

drop table if exists facultad;
create table facultad (
	id_facultad int primary key identity(1,1),
	nombre varchar(100) not null,
	descripcion varchar(1000) not null,
	user_crea int not null default 1,
	fecha_crea datetime not null default getdate(),
	user_modi int not null default 1,
	fecha_modi datetime not null default getdate(),
	activo char(1) default 'S',
);

drop table if exists carrera;
create table carrera (
	id_carrera int primary key identity(1,1),
	nombre varchar(100) not null,
	descripcion varchar(1000) not null,
	id_facultad int not null, 
	user_crea int  not null default 1,
	fecha_crea datetime not null default getdate(),
	user_modi int  not null default 1,
	fecha_modi datetime not null default getdate(),
	constraint fk_car_fac foreign key (id_facultad) references facultad(id_facultad),
	activo char(1) default 'S',
);

drop table if exists tipo_consulta;
create table tipo_consulta (
	id_tipo_consulta int primary key identity(1,1),
	nombre varchar(100)  not null,
	user_crea int  not null default 1,
	fecha_crea datetime not null default getdate(),
	user_modi int  not null default 1,
	fecha_modi datetime not null default getdate(),
	activo char(1) default 'S',
);

drop table if exists consulta;
create table consulta (
	id_consulta int primary key identity(1,1),
	id_tipo_consulta int  not null,
	email varchar(100) not null,
	consulta varchar(1000) not null, 
	fecha_crea datetime not null default getdate()
	constraint fk_con_tic foreign key (id_tipo_consulta) references tipo_consulta(id_tipo_consulta),
);

