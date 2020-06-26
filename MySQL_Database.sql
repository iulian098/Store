create database store;

use store;

create user 'user'@'localhost' identified by '123456';
create user 'admin'@'localhost' identified by '123456';


grant insert, select on store.users to 'user'@'localhost';
grant select on store.items to 'user'@'localhost';
grant select, insert on store.orders to 'user'@'localhost';
grant all privileges on *.* to 'admin'@'localhost';

flush privileges;

create table orders(

	id INT NOT NULL AUTO_INCREMENT,
	userid INT NOT NULL,
	itemid text,
	PRIMARY KEY(id)

);

create table admins(

	id INT NOT NULL auto_increment,
	username VARCHAR(30),
	PRIMARY KEY(id)

);

create table users(

	id int not null auto_increment,
	username varchar(30),
	password varchar(30),
	email varchar(50),
	address varchar(50),
	ban bit,
	primary key(id)

);

create table items(

	id int not null auto_increment,
	name varchar(30),
	price int,
	image text,
	quantity int,
	primary key(id)

);

insert into users VALUES(1,"admin","admin","null", "null");
insert into admins VALUES(1,"admin");

