USE ms_dynamicsDB;

--ddl create table [class]:
CREATE TABLE Students (
    StudentId INT PRIMARY KEY,
    Email VARCHAR(100) UNIQUE,
    Age INT CHECK (Age >= 18),
    CourseId INT
);

-- DML
INSERT INTO Students VALUES (1, 'rahul@gmail.com', 20, 101);
INSERT INTO Students VALUES (2, 'neha@gmail.com', 22, 102);
INSERT INTO Students VALUES (3, 'amit@gmail.com', 19, 101);

select * from Students;

--Aggregate functions
--Sum, Average, length etc
--total no of students
SELECT COUNT(*) AS TotalStudents FROM Students;
--Average or Age
SELECT AVG(Age) AS AverageAge FROM Students;

--Scalar function
SELECT StudentId, LEN (Email) as EmailLength,
GETDATE() AS currentDate
FROM Students;

SELECT * FROM Students;
--Grouping
SELECT CourseId, COUNT(*) AS StudentCount
FROm Students
GROUP BY CourseId;

SELECT COUNT(*) AS TotalStudents FROM Students;

-- Transactions
BEGIN TRANSACTION
    UPDATE Students
    SET AGE = AGE + 1
    WHERE CourseId = 101;

ROLLBACK;

BEGIN TRANSACTION
    UPDATE Students
    SET AGE = AGE + 1
    WHERE CourseId = 101;

COMMIT; 

--savepoint
BEGIN TRANSACTION;
UPDATE Students SET Age = 25 WHERE StudentId = 2;
SAVE TRANSACTION S1;

UPDATE Students SET Age = 30 WHERE StudentId = 1;
ROLLBACK TRANSACTION S1;
COMMIT;

--Access control Grant and Revoke
GRANT SELECT , INSERT ON Students to User1;
REVOKE INSERT ON Students FROM User1;

--DDL Alter
ALTER table Students
ADD Phone VARCHAR(50);

SELECT * FROM Students; 

CREATE FUNCTION dbo.fn_DisplayStudent_Table()
returns TABLE
AS
RETURN
(
SELECT StudentID, EMail, Age, CourseID FROM Students
);

SELECT * FROM dbo.fn_DisplayStudent_Table();

CREATE FUNCTION dbo.GET_STUDENTByCourseID( @CourseID INT)
Returns TABLE
AS
RETURN
(
SELECT StudentID, Email, Age FROM Students
WHERE CourseId = @CourseID
);

SELECT * FROM dbo.fn_DisplayStudent_Table();
SELECT * FROM Dbo.GET_STUDENTByCourseID (101);

--Foreign Key implementation
--parent table
CREATE TABLE Courses(
    CourseId INT Primary KEY,
    CourseName VARCHAR(100) NOT NULL,
    DurationMonths INT CHECK (DurationMonths>0)
);

insert into courses values (101,'fullstack dev using .net',6);
insert into courses values (102,'Data engineering using Azure',8);
insert into courses values (103,'block chain development',9);
insert into courses values (104,'cloud and devops',8);

select * from Courses;


CREATE TABLE WiproUniversity -- child table
(
StudentId INT PRIMARY KEY,
Email VARCHAR(100) UNIQUE,
Age INT CHECK (Age >= 18),
CourseId INT
CONSTRAINT FK_Students_Courses
FOREIGN KEY (CourseID)
REFERENCES Courses (CourseID)
);

INSERT INTO wiproUniversity VALUES (1, 'rahul@gmail.com', 20, 101);
INSERT INTO wiproUniversity VALUES (2, 'neha@gmail.com', 22, 102);
INSERT INTO wiproUniversity VALUES (3, 'amit@gmail.com', 19, 101);
INSERT INTO wiproUniversity VALUES (3, 'amit@gmail.com', 19, 109);

--to delete course (ex fromcgt)


--joins
-- Courses( Master table )
-- Students ( transaction Table)
-- Trainers( Self Join use cases)

CREATE TABLE MyCourses (
    CourseId INT PRIMARY KEY,
    CourseName VARCHAR(100)
);

CREATE TABLE My_Students (
    StudentId INT PRIMARY KEY,
    StudentName VARCHAR(50),
    CourseId INT
);

CREATE TABLE Trainers (
    TrainerId INT PRIMARY KEY,
    TrainerName VARCHAR(50),
    ManagerId INT
);

INSERT INTO MyCourses (CourseId, CourseName)
VALUES
(101, 'SQL Basics'),
(102, 'C# .NET Fundamentals'),
(103, 'ASP.NET Core'),
(104, 'React JS'),
(105, 'Cybersecurity Fundamentals');

INSERT INTO My_Students (StudentId, StudentName, CourseId)
VALUES
(1, 'Amit', 101),
(2, 'Priya', 102),
(3, 'Rahul', 103),
(4, 'Sneha', 104),
(5, 'John', 101),
(6, 'Kiran', 102),
(7, 'Neha', 104),
(8, 'Varun', 105),
(9, 'Meena', NULL),   -- not enrolled
(10, 'Suresh', NULL); -- not enrolled

INSERT INTO Trainers (TrainerId, TrainerName, ManagerId)
VALUES
(1, 'Ravi', NULL),    -- top level manager
(2, 'Anita', 1),
(3, 'Karthik', 1),
(4, 'Divya', 2),
(5, 'Sanjay', 2),
(6, 'Naveen', 3);

select * from MyCourses,My_Students,Trainers;

--inner join 
select s.StudentId,s.StudentName,c.coursename
from My_Students s
inner join MyCourses c
on s.CourseId = c.CourseId;

SELECT s.StudentId, s.StudentName, c.CourseName
FROM My_Students s
LEFT JOIN MyCourses c
ON s.CourseId = c.CourseId;

SELECT s.StudentId, s.StudentName, c.CourseName
FROM My_Students s
RIGHT JOIN MyCourses c
ON s.CourseId = c.CourseId;

SELECT s.StudentId, s.StudentName, c.CourseName
FROM My_Students s
FULL OUTER JOIN MyCourses c
ON s.CourseId = c.CourseId;

--cross join
select s.studentname, c.coursename
from My_Students s
cross join MyCourses c;

--self join
SELECT 
    t.TrainerId,
    t.TrainerName AS Trainer,
    m.TrainerName AS Manager
FROM Trainers t
LEFT JOIN Trainers m
ON t.ManagerId = m.TrainerId;