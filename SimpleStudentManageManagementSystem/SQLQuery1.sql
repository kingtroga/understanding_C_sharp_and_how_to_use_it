
CREATE TABLE students(
    id INT NOT NULL PRIMARY KEY IDENTITY,
    name VARCHAR (100) NOT NULL,
    matric_no VARCHAR (11) NOT NULL,
    level  VARCHAR(3) NOT NULL,
    program VARCHAR (100) NOT NULL,
    department VARCHAR (100) NOT NULL,
    college VARCHAR(100) NOT NULL,
    date_added DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);



INSERT INTO students (name, matric_no, level, program, department, college)
VALUES
('Ayebatariwalate Yekorogha', '19010301043', '300', 'CSC', 'Computer Science and Math', 'CBAS'),
('John Doe', '19010301044', '200','MTH', 'Computer Science and Math', 'CBAS'),
('Peter Parker', '19010301045','400', 'CSC', 'Computer Science and Math', 'CBAS'),
('Mary Jane', '19010301046', '400', 'MSC', 'Mass Communication', 'CHMS'),
('Jane Doe', '19010301047', '200', 'MTH', 'Computer Science and Math', 'CBAS'),
('Alice Wonderland', '19010301048', '100', 'MSC', 'Mass Communication', 'CHMS')