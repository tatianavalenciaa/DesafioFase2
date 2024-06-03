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
	'La Facultad está organizada en seis escuelas que administran nueve carreras legalmente constituidas que abarcan las diversas áreas de la ingeniería.'
);

insert into facultad(
	nombre, 
	descripcion
)
values (
	'Facultad de Ciencias y Humanidades', 
	'La Facultad de Ciencias y Humanidades comenzó a desarrollarse desde la creación de la Universidad, en mayo de 1985, impartiendo sus cátedras en el edificio Don Rúa.'
);

-- carrera

insert into carrera(
	nombre, 
	descripcion, 
	id_facultad
)
values (
	'Ingeniería en Ciencias de la Computación', 
	'Desarrollar software multiplataforma basado en normas técnicas internacionales y mejores prácticas reconocidas por la industria; considerando la comunicación de datos y la gobernanza de las tecnologías de información, para mejorar la productividad y contribuir en el desarrollo socioeconómico del país.',
	1
);

insert into carrera(
	nombre, 
	descripcion, 
	id_facultad
)
values (
	'Técnico en Ingeniería en Computación', 
	'Preparar profesionales con competencias tecnológicas capaces de construir soluciones informáticas, a través de la elección, integración y desarrollo de las diversas tecnologías de desarrollo de software. Contribuir a la continuidad de procesos de desarrollo económico en El Salvador mediante la participación directa de los profesionales de Técnico en Ingeniería en Computación.',
	1
);

insert into carrera(
	nombre, 
	descripcion, 
	id_facultad
)
values (
	'Licenciatura en Ciencias de la Comunicación', 
	'Formar profesionales que manejen con efectividad y eficacia los distintos recursos tecnológicos que utilice, esto para que produzcan mensajes éticos que no atenten contra la dignidad del ser humano, no inciten a la destrucción del medio ambiente y todos los recursos naturales. Al contrario, que con un toque creativo y con criterio crítico, pueda hacer uso efectivo de todos los medios, recursos y estrategias de comunicación existentes. Así mismo, tenga una base de formación que incite al emprendedurismo para atender necesidades que se presente de parte de cualquier organización tanto a nivel nacional como internacional.',
	2
);

insert into carrera(
	nombre, 
	descripcion, 
	id_facultad
)
values (
	'Técnico en Multimedia', 
	'Formar profesionales que manejen con efectividad y eficacia los distintos recursos tecnológicos que se le presentan, esto para que produzcan mensajes éticos que no atenten contra la dignidad del ser humano, no inciten a la destrucción del medio ambiente y todos los recursos naturales. Al contrario, que con un toque creativo y con criterio crítico, pueda hacer uso efectivo de todos los medios, recursos y estrategias de comunicación existentes. Así mismo, tenga una base de formación que incite al emprendedurismo para atender necesidades que se presente de parte de cualquier organización tanto a nivel nacional como internacional.',
	2
);
