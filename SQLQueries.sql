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
insert into course values(201,'Math2','ENG',2);

Teaches:
insert into teaches values(1,101);
insert into teaches values(2,103);
insert into teaches values(3,104);
insert into teaches values(1,201);

Teacher finance:
insert into teacher_finance values (1,30000, 5)
insert into teacher_finance values (2,40000, 3)
insert into teacher_finance values (3,35000,4)



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

Exam:
insert into exam values ('1011','101','2015-04-21','1');
insert into exam values ('1031',103','2015-04-22',2);

Result
insert into result values(1234,1,70);
insert into result values(1108,1,75);


