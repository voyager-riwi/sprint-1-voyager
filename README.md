# Console-Based Library System
# Description
A library management system developed in C# that allows for the administration of books, users, loans, reviews, and statistics from a console interface. The program implements a complete CRUD system with robust validations and advanced analytical functionalities.

# Main Features
## Book Management

- *Book Registration:* Title, author, category, publication year, and availability status
  
- *Full Listing:* Detailed visualization of all books

- *Updating:* Modification of any field for an existing book

- *Deletion:* Removal of books from the system

- *Advanced Search:* Filtering by title, author, or category with partial matching

## User Management

- *User Registration:* Full name, numeric ID, and email address

- *Robust Validations:* Verification of email format, name validation, and unique IDs

- *User Lookup:* Listing of all registered users

- *Data Updating:* Modification of personal information

- *Secure Deletion:* Removal with user confirmation

## Loan System

- *Book Loan:* Assignment of available books to registered users

- *Availability Control:* Automatic verification of book status

- *Duplicate Prevention:* A user cannot borrow the same book twice

- *Book Return:* Registration of returns with automatic status updates

- *Loan History:* Tracking of loan and return dates

# Reviews and Ratings System

- *Book Rating:* Scoring system from 0.0 to 5.0

- *Text Reviews:* Detailed comments with a 500-character limit

- *Rating Statistics:* Average, maximum, and minimum rating per book

- *Duplicate Prevention:* A user can only rate a book once

- *Review Lookup:* Viewing of comments per book

# Statistics Module

- *General Statistics:* Count of books, users, loans, and reviews

- *Most Borrowed Book:* Popularity ranking with a top 5

- *Best Rated Books:* Ranking by average rating

- *Most Active Users:* Statistics on loans and reviews per user

- *Availability Metrics:* Percentage of available books

# System Requirements

- *.NET 6.0* or higher

- *Operating System:* Windows, Linux, or macOS

- *Memory:* Minimum 4MB RAM

- *Storage:* 1MB of free space

# Installation and Execution

## Prerequisites

### Verify .NET version
dotnet --version

## Compilation

### Compile the project
dotnet build

## Execution

### Run the program
dotnet run

# Program Structure

## Global Variables

- *books:* List of books with structure [title, author, category, year, availability]

- *usuarios:* List of users with structure [name, ID, email]

- *prestamos:* List of loans with structure [user_ID, book_title, loan_date, return_date]

- *reseñas:* List of reviews with structure [book_title, user_ID, rating, text_review]

## Main Functions

## Book Management

- AgregarLibro(): Registration of new books with validations

- ListarLibros(): Display all books

- ActualizarLibro(): Modification of existing data

- EliminarLibro(): Removal of books from the system

- BuscarLibros(): Filtering by multiple criteria

## User Management

- RegistrarUsuario(): Creation of new users

- ConsultarUsuarios(): Listing of registered users

- ActualizarUsuario(): Modification of user data

- EliminarUsuario(): Removal of users

- ValidarNombre(), ValidarId(), ValidarCorreo(): Validation functions

## Loan System

- PrestarLibro(): Assignment of books to users

- DevolverLibro(): Registration of returns

- MostrarLibrosPrestados(): Listing of active loans

- UsuarioTieneLibroPrestado(): Verification of duplicate loans

## Reviews System

- CalificarLibro(): Assignment of numeric ratings

- EscribirReseña(): Creation of text reviews

- VerCalificaciones(): Consultation of rating statistics

- VerReseñas(): Visualization of comments

## Statistics

- MostrarEstadisticasGenerales(): General system metrics

- MostrarLibroMasPrestado(): Popularity ranking

- MostrarLibrosMasCalificados(): Ranking by rating

- MostrarEstadisticasUsuarios(): User activity statistics

## Implemented Validations

## Books

- Publication Year: Valid range between 1000 and current year

- Mandatory Fields: Title, author, and category cannot be empty

- Availability Status: Boolean values (available/not available)

## Users

- Full Name: Minimum first and last name, only letters and spaces

- ID: Numbers only, must be unique in the system

- Email: Valid format according to RFC standards

## Loans

- Availability: Only available books can be loaned

- Uniqueness: A user cannot borrow the same book twice

- Existence: User and book must exist in the system

## Reviews

- Ratings: Range from 0.0 to 5.0 with one decimal place

- Text Reviews: Maximum 500 characters, cannot be empty

- Uniqueness: A user can only rate a book once

## System Navigation

## Main Menu
### BIBLIOTECA
1. Libros
2. Usuarios
3. Préstamos
4. Reseñas
5. Estadísticas
6. Salir

# Submenus

Each main module contains specific submenus for its CRUD operations and additional functionalities.

# Error Handling

- Input Validation: Verification of data types and valid ranges

- Exception Handling: Use of TryParse() for secure conversions

- Informative Messages: Clear feedback to the user about errors

- Error Recovery: The system continues to function after input errors

# Technical Features

## Optimizations

- LINQ: Extensive use for efficient queries and filtering

- Lambda Expressions: More compact and readable code

- Helper Functions: Code reuse to avoid duplication

- Inline Validations: Verifications integrated into the main flow

# Data Structure

- Generic Lists: Use of List<T> for dynamic storage

- String Arrays: Simple structure for user and loan data

- Dynamic Objects: List<object> for flexibility in book data

# Current Limitations

- Persistence: Data is lost when the program closes

- Concurrency: Does not support multiple simultaneous users

- Interface: Console-only, no graphical interface

- Capacity: Limited by available system memory

# Suggested Future Improvements

- Data Persistence: Implement saving to files or a database

- Graphical Interface: Development of an application with a GUI

- Authentication System: User login and roles

- Advanced Reports: Generation of PDF reports

- Notifications: Alert system for overdue loans

- Advanced Search: Multiple filters and search by dates

- Developed as part of Sprint 1 of the Voyager project.

# Version History

- v1.0.0: Initial implementation with basic book and user management

- v1.1.0: Added loans and returns system

- v1.2.0: Implemented reviews and ratings system

- v1.3.0: Added advanced statistics module

- v1.4.0: Code optimization and interface improvements

  # Coders:

- Jeronimo Gutierrez
- Brahiam Ruiz
- Juan David Barrera
- Diego Zuluaga

  # Team:
  Voyager
