SQL queries for creating the database


inserting values into various tables

User:
insert into user values ('S1108',1108);
insert into user values ('S1105',1105);
insert into user values ('T1','1111');
insert into user values ('T2','2222');
insert into user values ('T3','3333');
insert into user values ('T4','4444');

Student

insert into Student values (1108,'Himanshu','Delhi','1994-11-24',991634762,'himanshu@gmail.com','ENG','B',1);
insert into Student values (1105,'Tanisha','Delhi','1995-6-14',991634762,'tan@gmail.com','ENG','A',1);

Student location
insert into student_location values (1234,'A','abc');
insert into student_location values(1108,'A','abc');
insert into student_location values(1105,'A','abc');

Course:

insert into course values (101,'Math1','ENG', 1);
insert into course values (103,'Physics1','ENG',1);
insert into course values (104,'Chemistry1','ENG',1);
insert into course values (105,'Biology1','Medical',1);

Teaches:
insert into teaches values(1,101);
insert into teaches values(2,103);
insert into teaches values(3,104);


Timetable
insert into timetable values('Monday','02:00:00',2,'A','abc);
insert into timetable values('Monday','16:00:00',3,'A','abc');
insert into timetable values('Monday','18:00:00',1,'A','abc');
insert into timetable values('Teusday','14:00:00',2,'A','abc');

Teacher

insert into teacher values (1,'Teacher1','def','1983-5-15','9864078213','abc');
insert into teacher values (2,'Teacher2','xyz','1982-9-30','9543352100','abc');
insert into teacher values (3,'Teacher3','rsr','1981-11-20','9916694506','abc');
insert into teacher values (4,'Teacher4','jui','1980-2-11','997256149','abc');


