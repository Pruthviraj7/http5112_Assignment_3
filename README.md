# Assignment 3 - School Management System

## Overview

This repository contains the source code for a School Management System, which includes controllers, data controllers, and models for managing students, classes, and teachers.

## Controllers

### 1. ClassController

- **Description:** Manages actions related to classes.
- **Actions:**
  - `Index`: Displays the index view for the Class controller.
  - `List`: Displays a list of classes based on the provided search key.
  - `Show`: Displays the details of a specific class.

### 2. ClassDataController

- **Description:** ApiController for managing class data, including listing classes and retrieving class details.
- **Actions:**
  - `ListClasses`: Retrieves a list of classes based on the provided search key.
  - `FindClass`: Retrieves the details of a specific class.

### 3. StudentController

- **Description:** Manages actions related to students.
- **Actions:**
  - `Index`: Displays the index view for the Student controller.
  - `List`: Displays a list of students based on the provided search key.
  - `Show`: Displays details of a specific student.

### 4. StudentDataController

- **Description:** ApiController for managing student data, including listing students and retrieving student details.
- **Actions:**
  - `ListStudents`: Retrieves a list of students based on the provided search key.
  - `FindStudent`: Retrieves details of a specific student.

### 5. TeacherController

- **Description:** Manages actions related to teachers.
- **Actions:**
  - `Index`: Displays the index view for the Teacher controller.
  - `List`: Displays a list of teachers based on the provided search key.
  - `Show`: Displays details of a specific teacher.

### 6. TeacherDataController

- **Description:** ApiController for managing teacher data, including listing teachers and retrieving teacher details.
- **Actions:**
  - `ListTeachers`: Retrieves a list of teachers based on the provided search key.
  - `FindTeacher`: Retrieves details of a specific teacher.

## Models

### 1. Class Model

- **Fields:**
  - `classid`: Unique identifier for the class.
  - `classname`: Name of the class.
  - `classcode`: Code associated with the class.
  - `teacherid`: ID of the teacher assigned to the class.

### 2. Student Model

- **Fields:**
  - `studentid`: Unique identifier for the student.
  - `studentfname`: First name of the student.
  - `studentlname`: Last name of the student.
  - `studentnumber`: Unique student number.
  - `enroldate`: Enrollment date of the student.

### 3. Teacher Model

- **Fields:**
  - `teacherid`: Unique identifier for the teacher.
  - `teacherfname`: First name of the teacher.
  - `teacherlname`: Last name of the teacher.
  - `employeenumber`: Unique employee number for the teacher.
  - `salary`: Salary of the teacher.
  - `ClassId`: ID of the associated class (nullable).

## Database Context

### SchoolDbContext

- **Description:** Manages the connection to the MySQL database.
- **Credentials:** Modify the `User`, `Password`, `Database`, `Server`, and `Port` properties for your local database.
- **Method:**
  - `AccessDatabase`: Returns a connection to the school database.

## Usage

1. Clone the repository.
2. Configure the database connection in `SchoolDbContext`.
3. Run the application.
