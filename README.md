# Multi-Level Security (MLS) Simulation – Python Version

## Description
This Python program simulates a Multi-Level Security system with 4 levels of clearance:
- `1` - Public
- `2` - Limited
- `3` - Secret
- `4` - Top Secret

The program:
- Creates 4 users, each with a different security clearance.
- Generates 50 files, each randomly assigned a security level.
- Authenticates a user via username and password.
- Displays only the files accessible based on the user's clearance.

## Concept
This project follows the **Bell-LaPadula model**:
- A user can **read files** at their level or **lower**.
- A user **cannot access files** above their clearance level.

## How to Run
1. Make sure Python 3 is installed.
2. Run the script:
   ```bash
   python mls_simulation.py



---

## **README: C# .NET Console App Version**


# Multi-Level Security (MLS) Simulation – C# .NET Version

## Description
This C# console app simulates a Multi-Level Security (MLS) system with 4 user clearance levels:
- `1` - Public
- `2` - Limited
- `3` - Secret
- `4` - Top Secret

It includes:
- User and File class models
- Credential-based login
- Clearance-based file access
- Random generation of 50 secured files

## Security Model
Implements **Bell-LaPadula (no read up)**:
- Users can access files with security levels **less than or equal** to their own.

## How to Run

### Option 1: Run with Visual Studio
1. Open the project folder
2. Build and run the `Program.cs` file

### Option 2: Run with CLI
> Prerequisites: [.NET SDK](https://dotnet.microsoft.com/en-us/download)

```bash
cd MyApp
dotnet run


