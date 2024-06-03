/* ============================== */
-- SELECCION DE BASE DE DATOS
/* ============================== */

use sitio_web_udb;
go

/* ============================== */
-- INSERTS 
/* ============================== */

-- usuario

insert into usuario (
	usuario, 
	password
)
values (
	'admin', 
	'admin'
);

-- noticia

insert into noticia (
	titulo, 
	descripcion, 
	fecha_crea
)
values (
	'Fundacion Kazma y UDB', 
	'Fundacion Kazma y UDB realizan primer encuentro de becarios, el cual tiene como proposito conocer las inquietudes de los estudiantes beneficiados en el programa.',
	dateadd(day, -5, getdate())
);

-- facultad

insert into facultad(
	nombre, 
	descripcion
)
values (
	'Facultad de Ingenieria', 
	'La Facultad est� organizada en seis escuelas que administran nueve carreras legalmente constituidas que abarcan las diversas �reas de la ingenier�a.'
);

insert into facultad(
	nombre, 
	descripcion
)
values (
	'Facultad de Ciencias y Humanidades', 
	'La Facultad de Ciencias y Humanidades comenz� a desarrollarse desde la creaci�n de la Universidad, en mayo de 1985, impartiendo sus c�tedras en el edificio Don R�a.'
);

-- carrera

insert into carrera(
	nombre, 
	descripcion, 
	id_facultad
)
values (
	'Ingenier�a en Ciencias de la Computaci�n', 
	'Desarrollar software multiplataforma basado en normas t�cnicas internacionales y mejores pr�cticas reconocidas por la industria; considerando la comunicaci�n de datos y la gobernanza de las tecnolog�as de informaci�n, para mejorar la productividad y contribuir en el desarrollo socioecon�mico del pa�s.',
	1
);

insert into carrera(
	nombre, 
	descripcion, 
	id_facultad
)
values (
	'T�cnico en Ingenier�a en Computaci�n', 
	'Preparar profesionales con competencias tecnol�gicas capaces de construir soluciones inform�ticas, a trav�s de la elecci�n, integraci�n y desarrollo de las diversas tecnolog�as de desarrollo de software. Contribuir a la continuidad de procesos de desarrollo econ�mico en El Salvador mediante la participaci�n directa de los profesionales de T�cnico en Ingenier�a en Computaci�n.',
	1
);

insert into carrera(
	nombre, 
	descripcion, 
	id_facultad
)
values (
	'Licenciatura en Ciencias de la Comunicaci�n', 
	'Formar profesionales que manejen con efectividad y eficacia los distintos recursos tecnol�gicos que utilice, esto para que produzcan mensajes �ticos que no atenten contra la dignidad del ser humano, no inciten a la destrucci�n del medio ambiente y todos los recursos naturales. Al contrario, que con un toque creativo y con criterio cr�tico, pueda hacer uso efectivo de todos los medios, recursos y estrategias de comunicaci�n existentes. As� mismo, tenga una base de formaci�n que incite al emprendedurismo para atender necesidades que se presente de parte de cualquier organizaci�n tanto a nivel nacional como internacional.',
	2
);

insert into carrera(
	nombre, 
	descripcion, 
	id_facultad
)
values (
	'T�cnico en Multimedia', 
	'Formar profesionales que manejen con efectividad y eficacia los distintos recursos tecnol�gicos que se le presentan, esto para que produzcan mensajes �ticos que no atenten contra la dignidad del ser humano, no inciten a la destrucci�n del medio ambiente y todos los recursos naturales. Al contrario, que con un toque creativo y con criterio cr�tico, pueda hacer uso efectivo de todos los medios, recursos y estrategias de comunicaci�n existentes. As� mismo, tenga una base de formaci�n que incite al emprendedurismo para atender necesidades que se presente de parte de cualquier organizaci�n tanto a nivel nacional como internacional.',
	2
);
