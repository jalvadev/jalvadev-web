CREATE TABLE IF NOT EXISTS users (
	id SMALLINT GENERATED ALWAYS AS IDENTITY,
	name VARCHAR(50) NOT NULL,
	surname VARCHAR(250) NOT NULL,
	about TEXT,
	creation_date TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'Europe/Madrid'),
	update_date TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'Europe/Madrid'),
	
	CONSTRAINT pk_users PRIMARY KEY(id)
);

CREATE TABLE IF NOT EXISTS user_contacts (
	id SMALLINT GENERATED ALWAYS AS IDENTITY,
	user_id SMALLINT NOT NULL,
	email VARCHAR(250),
	github VARCHAR(512),
	linkedin VARCHAR(512),
	creation_date TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'Europe/Madrid'),
	update_date TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'Europe/Madrid'),

	CONSTRAINT pk_user_contacts PRIMARY KEY(id),
	CONSTRAINT fk_user_contacts_user FOREIGN KEY (user_id) REFERENCES users(id)
);

CREATE TABLE IF NOT EXISTS user_media_library (
	id INTEGER GENERATED ALWAYS AS IDENTITY,
	user_id SMALLINT NOT NULL,
	image_url VARCHAR(512) NOT NULL,
	creation_date TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'Europe/Madrid'),
	update_date TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'Europe/Madrid'),

	CONSTRAINT pk_user_media_library PRIMARY KEY(id),
	CONSTRAINT fk_user_media_library_user FOREIGN KEY (user_id) REFERENCES users(id)
);


CREATE TABLE IF NOT EXISTS tags(
	id SMALLINT GENERATED ALWAYS AS IDENTITY,
	name VARCHAR(50) NOT NULL,
	creation_date TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'Europe/Madrid'),
	update_date TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'Europe/Madrid'),

	CONSTRAINT pk_tags PRIMARY KEY(id)
);

CREATE TABLE IF NOT EXISTS projects (
	id SMALLINT GENERATED ALWAYS AS IDENTITY,
	user_id SMALLINT NOT NULL,
	name VARCHAR(512) NOT NULL,
	image VARCHAR(512) NOT NULL,
	link VARCHAR(512) NOT NULL,
	creation_date TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'Europe/Madrid'),
	update_date TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'Europe/Madrid'),

	CONSTRAINT pk_projects PRIMARY KEY(id),
	CONSTRAINT fk_projects_user FOREIGN KEY (user_id) REFERENCES users(id)
);

CREATE TABLE IF NOT EXISTS posts (
	id SMALLINT GENERATED ALWAYS AS IDENTITY,
	user_id SMALLINT NOT NULL,
	title VARCHAR(512) NOT NULL,
	content TEXT,
	is_draft BOOLEAN NOT NULL DEFAULT '0',
	creation_date TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'Europe/Madrid'),
	update_date TIMESTAMP WITHOUT TIME ZONE NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'Europe/Madrid'),

	CONSTRAINT pk_posts PRIMARY KEY(id),
	CONSTRAINT fk_posts_users FOREIGN KEY (user_id) REFERENCES users(id)
);

CREATE TABLE IF NOT EXISTS post_tags (
	id INT GENERATED ALWAYS AS IDENTITY,
	post_id SMALLINT NOT NULL,
	tag_id SMALLINT NOT NULL,

	CONSTRAINT pk_post_tags PRIMARY KEY(id),
	CONSTRAINT fk_post_tags_post FOREIGN KEY (post_id) REFERENCES posts(id),
	CONSTRAINT fk_post_tags_tag FOREIGN KEY (tag_id) REFERENCES tags(id)
);