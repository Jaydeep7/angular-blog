create table Employee
(
Id int primary key identity(1,1),
Name varchar(50),
City varchar(50),
DOB datetime,
Salary numeric(10,2),
DeptId int references Department(deptid)
)

Create table Department
(
DeptId int primary key,
DeptName varchar(50)
)


insert into Department values (1, 'Account')
insert into Department values (2, 'Fix')
insert into Department values (3, 'Reserve')
insert into Department values (4, 'Payroll')

select * from Department
select * from Employee

