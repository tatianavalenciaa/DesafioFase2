/* ============================== */
-- SELECCION DE BASE DE DATOS
/* ============================== */

use sitio_web_udb;
go

/* ============================== */
-- PROCEDIMIENTOS ALMACENADOS
/* ============================== */

-- -----------------------------
-- usuario
-- -----------------------------

-- sp_obtener_usuario

create or alter procedure sp_obtener_pelicula( 
	@id int
)
as
begin
	select 
		* 
	from 
		usuario usu
	where 
		id_usuario = @id
end;

go

-- -----------------------------
-- usuario
-- -----------------------------

-- sp_obtener_usuario

create or alter procedure sp_obtener_usuario(
	@usuario varchar(100),
	@password varchar(100)
)
as
begin
	select 
		* 
	from 
		usuario
	where 
		1 = 1
		and usuario = @usuario
		and password = @password
end;

go

-- -----------------------------
-- noticia
-- -----------------------------

-- sp_obtener_noticias_desc

create or alter procedure sp_obtener_noticias_desc
as
begin
	select 
		* 
	from 
		noticia
	where 
		1 = 1
		and activo = 'S'
	order by 
		fecha_crea desc
end;

go

-- sp_obtener_noticias

create or alter procedure sp_obtener_noticias
as
begin
	select 
		* 
	from 
		noticia
	where 
		1 = 1
		and activo = 'S'
end;

go

create or alter procedure sp_obtener_noticia(
	@id_noticia int
)
as
begin
	select 
		* 
	from 
		noticia
	where 
		1 = 1
		and id_noticia = @id_noticia
		and activo = 'S'
end;

go

-- sp_registrar_noticia

create or alter procedure sp_registrar_noticia(
	@titulo varchar(100),
	@descripcion varchar(1000)
)
as
begin
	insert into noticia
		(titulo, descripcion)
	values
		(@titulo, @descripcion)
	;
end;

go

-- sp_modificar_noticia

create or alter procedure sp_modificar_noticia(
	@id_noticia int,
	@titulo varchar(100),
	@descripcion varchar(1000)
)
as 
begin
	update 
		noticia
	set
		titulo = @titulo,
		descripcion = @descripcion,
		fecha_modi = getdate()
	where 
		1 = 1
		and id_noticia = @id_noticia
	;
end;

go 

-- sp_act_ina_noticia

create or alter procedure sp_act_ina_noticia(
	@id_noticia int
)
as 
begin	
	declare @activo_actual char(1);
	declare @activo_nuevo char(1);
	
	select 
		@activo_actual = activo 
	from 
		noticia
	where 
		1 = 1
		and id_noticia = @id_noticia;
	
	if (@activo_actual = 'S') begin
		set @activo_nuevo = 'N';
	end
	else begin 
		set @activo_nuevo = 'S';
	end ;
	
	update 
		noticia
	set
		activo = @activo_nuevo
	where 
		1 = 1
		and id_noticia = @id_noticia
	;
end;

go

-- -----------------------------
-- facultad
-- -----------------------------

-- sp_obtener_facultades

create or alter procedure sp_obtener_facultades
as
begin
	select 
		* 
	from 
		facultad
	where 
		1 = 1
		and activo = 'S'
end;

go

create or alter procedure sp_obtener_facultad(
	@id_facultad int
)
as
begin
	select 
		* 
	from 
		facultad
	where 
		1 = 1
		and id_facultad = @id_facultad
		and activo = 'S'
end;

go

-- sp_registrar_facultad

create or alter procedure sp_registrar_facultad(
	@nombre varchar(100),
	@descripcion varchar(1000)
)
as
begin
	insert into facultad
		(nombre, descripcion)
	values
		(@nombre, @descripcion)
	;
end;

go

-- sp_modificar_facultad

create or alter procedure sp_modificar_facultad(
	@id_facultad int,
	@nombre varchar(100),
	@descripcion varchar(1000)
)
as 
begin
	update 
		facultad
	set
		nombre = @nombre,
		descripcion = @descripcion,
		fecha_modi = getdate()
	where 
		1 = 1
		and id_facultad = @id_facultad
	;
end;

go 

-- sp_act_ina_facultad

create or alter procedure sp_act_ina_facultad(
	@id_facultad int
)
as 
begin	
	declare @activo_actual char(1);
	declare @activo_nuevo char(1);
	
	select 
		@activo_actual = activo 
	from 
		facultad
	where 
		1 = 1
		and id_facultad = @id_facultad;
	
	if (@activo_actual = 'S') begin
		set @activo_nuevo = 'N';
	end
	else begin 
		set @activo_nuevo = 'S';
	end ;
	
	update 
		facultad
	set
		activo = @activo_nuevo
	where 
		1 = 1
		and id_facultad = @id_facultad
	;
end;

go

-- -----------------------------
-- carrera
-- -----------------------------

-- sp_obtener_carreras_x_fac

create or alter procedure sp_obtener_carreras_x_fac(
	@id_facultad int
)
as
begin
	select 
		* 
	from 
		carrera
	where 
		1 = 1
		and id_facultad = @id_facultad 
		and activo = 'S'
end;

go

-- sp_obtener_carreras

create or alter procedure sp_obtener_carrerass
as
begin
	select 
		c.id_carrera,
		c.nombre,
		c.descripcion, 
		f.nombre as facultad
	from 
		carrera c
		join facultad f 
			on f.id_facultad = c.id_facultad
	where 
		1 = 1
		and c.activo = 'S'
end;

go