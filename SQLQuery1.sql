CREATE TABLE students (
	id INT NOT NULL PRIMARY KEY IDENTITY,
	name VARCHAR(50) NOT NULL,
	email VARCHAR(50) NOT NULL UNIQUE,
	admission VARCHAR(50) NOT NULL,
	department VARCHAR(50) NULL,
	address VARCHAR(50) NULL,
	created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
);

INSERT INTO students(name, email, admission, department, address) VALUES
	('John Doe', 'john.doe@outlook.com', 'J/20157', 'ICT', 'London'),
	('Mike Simon', 'simon.m@yahoo.com', 'J/20158', 'Medicine', 'New Delhi'),
	('Mark Wilson', 'wilson.mark@gmail.com', 'M/10111', 'ICT', 'Mumbai'),
	('Bobby Jack ', 'jack.b@gmail.com', 'S/20345', 'Mathematics', 'New Delhi'),
	('Cristiano Ronaldo', 'cristiano.ronaldo@spraxa.com', 'S/20350', 'ICT','London'),
	('Mine Mike', 'mine.mike@strem4tech.com', 'M/10200', 'Mathematics','Nairobi');