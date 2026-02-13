# 🔐 Student Management API – Role-Based Authentication & Authorization

A secure ASP.NET Core Web API implementing JWT authentication and role-based authorization (Admin/User) using clean layered architecture with Controllers, Services, DTOs, and Entity Framework Core.

---

## 🚀 Features

- ✅ JWT Authentication
- ✅ Role-Based Authorization (Admin / User)
- ✅ Secure Password Hashing (ASP.NET Identity PasswordHasher)
- ✅ Layered Architecture (Controller → Service → DTO → Entity)
- ✅ Entity Framework Core with SQL Server
- ✅ RESTful API Design
- ✅ Protected Endpoints with Role Restrictions
- ✅ Clean Dependency Injection Setup

---

## 🏗 Architecture

This project follows a clean layered architecture:

Controllers → Services → Data (DbContext) → SQL Server
↓
DTOs


### Folder Structure

📦 Dotnet_API_11_
┣ 📂 Controllers
┃ ┣ 📄 AuthController.cs
┃ ┗ 📄 StudentController.cs
┣ 📂 Services
┃ ┣ 📂 AuthService
┃ ┗ 📂 StudentService
┣ 📂 Dtos
┃ ┣ 📂 UserDto
┃ ┗ 📂 StudentDto
┣ 📂 Entities
┃ ┣ 📄 User.cs
┃ ┗ 📄 Student.cs
┣ 📂 Data
┃ ┗ 📄 StudentAuthDbContext.cs
┗ 📄 Program.cs


---

## 🔑 Authentication & Authorization

### 🔐 JWT Authentication
- Users receive a JWT token upon successful login.
- Token contains:
  - Username
  - User ID
  - Role Claim

### 👑 Role-Based Authorization

| Role  | Permissions |
|--------|------------|
| User   | View students |
| Admin  | Create & Delete students |

Example:

```csharp
[Authorize] // Logged-in users only

[Authorize(Roles = "Admin")] // Admin only

[AllowAnonymous] // Public access
🧑‍💻 API Endpoints
🔓 Auth Endpoints
Method	Endpoint	Description
POST	/api/auth/register	Register new user
POST	/api/auth/login	Login and get JWT
🎓 Student Endpoints
Method	Endpoint	Access
GET	/api/student/GetAllStudents	Public
GET	/api/student/{id}	Public
POST	/api/student	Admin Only
DELETE	/api/student/{id}	Admin Only
🛠 Technologies Used
ASP.NET Core Web API

Entity Framework Core

SQL Server

JWT Bearer Authentication

Dependency Injection

Role-Based Authorization

Scalar / OpenAPI for testing

⚙️ Configuration
appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=StudentAuthDB;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "AppSettings": {
    "Token": "YOUR_SUPER_SECRET_KEY",
    "Issuer": "StudentAuthAPI",
    "Audience": "StudentAuthUsers"
  }
}
🔄 How It Works
User registers → Assigned default role = User

Admin user can be seeded or created securely

User logs in → Receives JWT token

Token must be sent in request header:

Authorization: Bearer <your_token_here>
Middleware validates:

Token signature

Expiration

Issuer & Audience

Role claims

🧪 Testing the API
Use:

Swagger / OpenAPI

Postman

Scalar API reference

Steps:

Register user

Login

Copy JWT token

Add to Authorization header

Access protected endpoints

🔐 Security Highlights
Passwords stored as hashed values

Role-based access control

Secure token validation

No raw password storage

Middleware-based authentication pipeline

📌 Future Improvements
Refresh Token implementation

Policy-based authorization

Role management panel

Pagination & filtering

Logging & global exception handling

Docker support

👨‍💻 Author
Developed as part of learning secure backend development using ASP.NET Core and modern authentication practices.

