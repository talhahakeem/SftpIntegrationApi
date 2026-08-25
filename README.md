# SFTP Integration API      
   
An ASP.NET Core 8 Web API that integrates with an SFTP server to securely upload and retrieve files using SSH.NET.

## Features

- Secure SFTP connection using SSH.NET
- Upload files to an SFTP server
- Retrieve files from an SFTP server
- Configuration through appsettings.json
- RESTful API endpoints
- Dependency Injection
- Clean Architecture (Controller → Service → Interface)

## Technologies Used

- ASP.NET Core 8 Web API
- C#
- SSH.NET
- Swagger (OpenAPI)
- Dependency Injection

## Project Structure

```
SftpIntegrationApi
│
├── Controllers
│   └── SftpController.cs
│
├── Interfaces
│   └── ISftpService.cs
│
├── Models
│   └── SftpSettings.cs
│
├── Services
│   └── SftpService.cs
│
├── appsettings.json
└── Program.cs
```

## API Endpoints

### Upload File

```
POST /api/Sftp/upload
```

Uploads a file from the client to the configured SFTP server.

---

### Get File

```
GET /api/Sftp/file/{fileName}
```

Downloads the requested file from the configured SFTP server.

---

## Configuration

Update the following values in **appsettings.json**.

```json
"SftpSettings": {
  "Host": "your-host",
  "Port": 22,
  "Username": "your-username",
  "Password": "your-password",
  "RemotePath": "/"
}
```

## Workflow

```
Client
   │
   ▼
Upload API
   │
   ▼
SFTP Server

----------------------

Client
   │
   ▼
Get File API
   │
   ▼
SFTP Server
```

## Current Functionality

- Upload files to an SFTP server.
- Retrieve files from an SFTP server.
- Configurable host, port, username, password, and remote path.
- Tested using a free SFTP test server.

## Future Improvements

- Multiple file upload
- Multiple file download
- Delete files
- Rename files
- List available files
- Azure Blob Storage Integration
- Authentication & Authorization
- Logging and Exception Handling

## Author

**Muhammad Talha Hakeem**

.NET Developer
