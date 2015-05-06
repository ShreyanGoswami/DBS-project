select time,C_Name from timetable natural join teacher,teaches,course where teacher.T_ID=teaches.T_ID and teaches.C_ID=course.C_ID;
-------------------------
select day, max(firstclass) as 'First-Class',
max(secondclass) as 'Second-Class',
max(thirdclass) as 'Third-Class',
max(fourthclass) as 'Fourth-Class',
max(fifthclass) as 'Fifth-Class' from
(select day,sec,
if(time = '9:00:00', c_name, '--') as firstclass,
if(time = '11:00:00', c_name, '--') as secondclass,
if(time = '14:00:00', c_name, '--') as thirdclass,
if(time = '16:00:00', c_name, '--') as fourthclass,
if(time = '18:00:00', c_name, '--') as fifthclass from
(SELECT day,time,c_name,sec,sem FROM timetable as tt
inner join teaches as t on tt.t_id = t.t_id
inner join course as c on t.c_id = c.c_id where sem=1) as a) as b
where sec ='A'
group by day
ORDER BY day

For teacher

select day, max(firstclass) as 'First-Class', 
max(secondclass) as 'Second-Class', 
max(thirdclass) as 'Third-Class', 
max(fourthclass) as 'Fourth-Class', 
max(fifthclass) as 'Fifth-Class' 
from 
(select day,sec,t_id, 
if(time = '9:00:00', sec, '--') as firstclass, 
if(time = '11:00:00', sec, '--') as secondclass, 
if(time = '14:00:00', sec, '--') as thirdclass, 
if(time = '16:00:00', sec, '--') as fourthclass, 
if(time = '18:00:00', sec, '--') as fifthclass 
from 
(SELECT day,time,c_name,tt.t_id, sec FROM timetable as tt 
inner join teaches as t on tt.t_id = t.t_id 
inner join course as c on t.c_id = c.c_id) as a) as b 
where t_id = 2 
group by day ORDER BY FIELD(day, 'Monday', 'Tuesday', 'Wednesday', 'Thursday','Friday','Saturday');

Function:
DELIMITER $$
CREATE FUNCTION max_marks (EX_ID int) 
RETURNS integer
DETERMINISTIC
BEGIN 
  DECLARE dist integer;
  select max(marks) into dist
  from result where result.Ex_ID=EX_ID;
  RETURN dist;
END$$
DELIMITER ;
