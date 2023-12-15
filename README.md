# School Management System

Welcome to the School Management System repository. This system provides a web-based interface to manage teachers in a school setting. Below, you'll find details about the features, controllers, models, and usage instructions.

## Features

### Teacher Management

#### View Teachers

- **URL:** `/Teacher/Index`
- Displays a paginated list of all teachers.
- Each entry includes the teacher's full name, employee number, and salary.

#### View Teacher Details

- **URL:** `/Teacher/Show/{teacherId}`
- Shows detailed information about a specific teacher.
- Includes first and last name, employee number, salary, and hire date.

#### Add New Teacher

- **URL:** `/Teacher/Add`
- Allows administrators to add a new teacher to the system.
- Collects information such as first name, last name, employee number, salary, and hire date.
- Performs client-side validation for mandatory fields and positive salary.
- Server-side validation ensures all required information is provided before adding the teacher to the system.

#### Update Teacher

- **URL:** `/Teacher/Update/{teacherId}`
- Enables administrators to update information for an existing teacher.
- Collects updated information such as first name, last name, employee number, salary, and hire date.
- Performs client-side and server-side validation to ensure data integrity.

#### Delete Teacher

- **URL:** `/Teacher/Delete/{teacherId}`
- Permanently removes a teacher from the system.
- Requires confirmation before deletion.

### API Endpoints

#### List Teachers (API)

- **URL:** `/api/TeacherData/ListTeachers/{searchKey?}`
- Provides a JSON array of teachers based on the optional search key.
- Used for dynamic content loading and search functionality.

#### Find Teacher (API)

- **URL:** `/api/TeacherData/FindTeacher/{teacherId}`
- Retrieves detailed information about a specific teacher in JSON format.

#### Add Teacher (API)

- **URL:** `/api/TeacherData/AddTeacher`
- Adds a new teacher to the system via API.
- Requires a JSON payload with teacher details.
- Performs server-side validation to ensure the integrity of the data.

#### Update Teacher (API)

- **URL:** `/api/TeacherData/UpdateTeacher/{teacherId}`
- Updates information for an existing teacher via API.
- Requires a JSON payload with updated teacher details.
- Performs server-side validation to ensure data integrity.

#### Delete Teacher (API)

- **URL:** `/api/TeacherData/DeleteTeacher/{teacherId}`
- Deletes a teacher from the system via API.
- Requires teacher ID in the URL.

## Models

### Teacher Model

- **Fields:**
  - `teacherid`: Unique identifier for the teacher.
  - `teacherfname`: First name of the teacher.
  - `teacherlname`: Last name of the teacher.
  - `employeenumber`: Unique employee number for the teacher.
  - `salary`: Salary of the teacher.
  - `hiredate`: Date when the teacher was hired.

## Validation

### Client-Side Validation

- Implemented using JavaScript on the Add Teacher and Update Teacher pages.
- Validates mandatory fields and ensures the salary is a positive number.

### Server-Side Validation

- Implemented in the API controllers (`TeacherDataController`).
- Ensures that all required information is provided before processing requests.
- Guarantees the integrity of the data in the system.

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
