
# 🖼️ AnnotationsAPI

A secure and extensible RESTful API for managing image annotations. Built with ASP.NET Core and Entity Framework Core, this application supports authenticated users, image uploads, annotation management, and role-based access control. Ideal for machine learning data labeling and review systems.

---

## 🚀 Features

- 🔐 JWT-based authentication with support for user roles
- 🧾 User registration and login
- 🖼 Image upload and management
- ✏️ Create, update, and delete annotations tied to images
- 🔍 Filtered and paginated responses for scalable data handling
- 🧼 Clean DTO-based request/response models with validation
- 🧠 Solid architecture with service, repository, and Unit of Work patterns
- 🐬 MySQL integration using Pomelo.EntityFrameworkCore.MySql
- 📜 AutoMapper-based model mapping for cleaner logic separation

---

## 🛠️ Technologies Used

- **ASP.NET Core 8**
- **Entity Framework Core**
- **Pomelo.EntityFrameworkCore.MySql**
- **AutoMapper**
- **JWT**
- **C#**

---

## 📁 Project Structure

```
AnnotationsAPI/
├── Controllers/           # API controllers for authentication, images, and annotations
├── Data/                  # EF DbContext and seed configuration
├── Dtos/                  # Request and response models
│   ├── ImageDtos/
│   ├── UserDtos/
├── Entities/              # Domain models (User, Image, Annotation)
├── Mapping/               # AutoMapper extension methods
├── Migrations/            # EF Core migrations
├── Properties/            # Launch configuration
├── Repositories/          # Abstractions and implementations
│   ├── UserRepositories/
├── Responses/             # Generic API response classes
├── Services/              # Business logic layers
│   ├── AnnotationServices/
│   ├── ImageServices/
│   ├── UserServices/
├── appsettings.json       # Configuration settings
├── Program.cs             # App entry point
└── README.md              # Project documentation
```

---

## 🧪 Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/AnnotationsAPI.git
   cd AnnotationsAPI
   ```

2. Configure the database connection string in `appsettings.json` or use user secrets.

3. Apply migrations:
   ```bash
   dotnet ef database update
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

5. Access the API documentation via Swagger:
   ```
   https://localhost:{port}/swagger
   ```

---

## 🔐 Authentication

- `POST /api/auth/register` – Register a new user
- `POST /api/auth/login` – Authenticate and receive a JWT token

---

## 📬 API Endpoints

### 🔐 Authentication
- `POST /api/auth/register` – Register new users
- `POST /api/auth/login` – Login and receive JWT

### 🖼 Images (Authenticated Users)
- `POST /api/images` – Upload a new image
- `GET /api/images` – Get user images
- `DELETE /api/images/{id}` – Delete image (and related annotations)

### ✏️ Annotations (Authenticated Users)
- `GET /api/annotations/{imageId}` – Get annotations for an image
- `POST /api/annotations` – Create a new annotation
- `PUT /api/annotations/{id}` – Update annotation
- `DELETE /api/annotations/{id}` – Delete annotation

> 🔐 All endpoints (except `/auth`) require `Authorization: Bearer <token>`

---

## 🧼 DTO Validation

All incoming request models include data annotations like `[Required]`, `[StringLength]`, and `[Range]`.

Example:
```csharp
public class AnnotationDto
{
    [Required]
    public int ImageId { get; set; }

    [Required]
    public string Label { get; set; }

    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
}
```

---

## 🧪 Testing

Use Swagger UI or [Postman](https://www.postman.com/) to test endpoints. All invalid inputs are handled with appropriate 400 responses.

---

## 📄 License

Licensed under the [MIT License](LICENSE).

---

## 📫 Contact

Created by [Omar Khaled](https://github.com/OmarKhaled1504)
