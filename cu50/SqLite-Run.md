## SQLite Run

    $ $Env:ASPNETCORE_ENVIRONMENT = "Development"
    $ dotnet run
    info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
        Entity Framework Core 5.0.8 initialized 'SchoolContext' using provider 'Microsoft.EntityFrameworkCore.Sqlite' with options: None
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (10ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
        PRAGMA journal_mode = 'wal';
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
        CREATE TABLE "Instructor" (
            "ID" INTEGER NOT NULL CONSTRAINT "PK_Instructor" PRIMARY KEY AUTOINCREMENT,
            "HireDate" TEXT NOT NULL,
            "LastName" TEXT NOT NULL,
            "FirstName" TEXT NOT NULL
        );
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
        CREATE TABLE "Student" (
            "ID" INTEGER NOT NULL CONSTRAINT "PK_Student" PRIMARY KEY AUTOINCREMENT,
            "EnrollmentDate" TEXT NOT NULL,
            "LastName" TEXT NOT NULL,
            "FirstName" TEXT NOT NULL
        );
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
        CREATE TABLE "Departments" (
            "DepartmentID" INTEGER NOT NULL CONSTRAINT "PK_Departments" PRIMARY KEY AUTOINCREMENT,
            "Name" TEXT NULL,
            "Budget" money NOT NULL,
            "StartDate" TEXT NOT NULL,
            "InstructorID" INTEGER NULL,
            "ConcurrencyToken" TEXT NOT NULL,
            CONSTRAINT "FK_Departments_Instructor_InstructorID" FOREIGN KEY ("InstructorID") REFERENCES "Instructor" ("ID") ON DELETE RESTRICT
        );
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
        CREATE TABLE "OfficeAssignments" (
            "InstructorID" INTEGER NOT NULL CONSTRAINT "PK_OfficeAssignments" PRIMARY KEY,
            "Location" TEXT NULL,
            CONSTRAINT "FK_OfficeAssignments_Instructor_InstructorID" FOREIGN KEY ("InstructorID") REFERENCES "Instructor" ("ID") ON DELETE CASCADE
        );
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
        CREATE TABLE "Course" (
            "CourseID" INTEGER NOT NULL CONSTRAINT "PK_Course" PRIMARY KEY,
            "Title" TEXT NULL,
            "Credits" INTEGER NOT NULL,
            "DepartmentID" INTEGER NOT NULL,
            CONSTRAINT "FK_Course_Departments_DepartmentID" FOREIGN KEY ("DepartmentID") REFERENCES "Departments" ("DepartmentID") ON DELETE CASCADE
        );
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
        CREATE TABLE "CourseInstructor" (
            "CoursesCourseID" INTEGER NOT NULL,
            "InstructorsID" INTEGER NOT NULL,
            CONSTRAINT "PK_CourseInstructor" PRIMARY KEY ("CoursesCourseID", "InstructorsID"),
            CONSTRAINT "FK_CourseInstructor_Course_CoursesCourseID" FOREIGN KEY ("CoursesCourseID") REFERENCES "Course" ("CourseID") ON DELETE CASCADE,
            CONSTRAINT "FK_CourseInstructor_Instructor_InstructorsID" FOREIGN KEY ("InstructorsID") REFERENCES "Instructor" ("ID") ON DELETE CASCADE
        );
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
        CREATE TABLE "Enrollments" (
            "EnrollmentID" INTEGER NOT NULL CONSTRAINT "PK_Enrollments" PRIMARY KEY AUTOINCREMENT,
            "CourseID" INTEGER NOT NULL,
            "StudentID" INTEGER NOT NULL,
            "Grade" INTEGER NULL,
            CONSTRAINT "FK_Enrollments_Course_CourseID" FOREIGN KEY ("CourseID") REFERENCES "Course" ("CourseID") ON DELETE CASCADE,
            CONSTRAINT "FK_Enrollments_Student_StudentID" FOREIGN KEY ("StudentID") REFERENCES "Student" ("ID") ON DELETE CASCADE
        );
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
        CREATE INDEX "IX_Course_DepartmentID" ON "Course" ("DepartmentID");
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
        CREATE INDEX "IX_CourseInstructor_InstructorsID" ON "CourseInstructor" ("InstructorsID");
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
        CREATE INDEX "IX_Departments_InstructorID" ON "Departments" ("InstructorID");
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
        CREATE INDEX "IX_Enrollments_CourseID" ON "Enrollments" ("CourseID");
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
        CREATE INDEX "IX_Enrollments_StudentID" ON "Enrollments" ("StudentID");
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
        SELECT EXISTS (
            SELECT 1
            FROM "Student" AS "s")
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (2ms) [Parameters=[@p0='?' (Size = 4), @p1='?', @p2='?' (Size = 8)], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Instructor" ("FirstName", "HireDate", "LastName")
        VALUES (@p0, @p1, @p2);
        SELECT "ID"
        FROM "Instructor"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?' (Size = 5), @p1='?', @p2='?' (Size = 5)], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Instructor" ("FirstName", "HireDate", "LastName")
        VALUES (@p0, @p1, @p2);
        SELECT "ID"
        FROM "Instructor"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?' (Size = 7), @p1='?', @p2='?' (Size = 6)], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Instructor" ("FirstName", "HireDate", "LastName")
        VALUES (@p0, @p1, @p2);
        SELECT "ID"
        FROM "Instructor"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?' (Size = 5), @p1='?', @p2='?' (Size = 5)], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Instructor" ("FirstName", "HireDate", "LastName")
        VALUES (@p0, @p1, @p2);
        SELECT "ID"
        FROM "Instructor"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?' (Size = 3), @p1='?', @p2='?' (Size = 11)], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Instructor" ("FirstName", "HireDate", "LastName")
        VALUES (@p0, @p1, @p2);
        SELECT "ID"
        FROM "Instructor"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?' (Size = 6), @p2='?' (Size = 9)], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Student" ("EnrollmentDate", "FirstName", "LastName")
        VALUES (@p0, @p1, @p2);
        SELECT "ID"
        FROM "Student"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?' (Size = 8), @p2='?' (Size = 6)], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Student" ("EnrollmentDate", "FirstName", "LastName")
        VALUES (@p0, @p1, @p2);
        SELECT "ID"
        FROM "Student"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?' (Size = 6), @p2='?' (Size = 5)], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Student" ("EnrollmentDate", "FirstName", "LastName")
        VALUES (@p0, @p1, @p2);
        SELECT "ID"
        FROM "Student"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?' (Size = 5), @p2='?' (Size = 9)], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Student" ("EnrollmentDate", "FirstName", "LastName")
        VALUES (@p0, @p1, @p2);
        SELECT "ID"
        FROM "Student"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?' (Size = 3), @p2='?' (Size = 2)], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Student" ("EnrollmentDate", "FirstName", "LastName")
        VALUES (@p0, @p1, @p2);
        SELECT "ID"
        FROM "Student"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?' (Size = 5), @p2='?' (Size = 7)], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Student" ("EnrollmentDate", "FirstName", "LastName")
        VALUES (@p0, @p1, @p2);
        SELECT "ID"
        FROM "Student"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p3='?', @p4='?', @p5='?', @p6='?' (Size = 11), @p7='?'], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Departments" ("Budget", "ConcurrencyToken", "InstructorID", "Name", "StartDate")
        VALUES (@p3, @p4, @p5, @p6, @p7);
        SELECT "DepartmentID"
        FROM "Departments"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?', @p2='?', @p3='?' (Size = 11), @p4='?'], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Departments" ("Budget", "ConcurrencyToken", "InstructorID", "Name", "StartDate")
        VALUES (@p0, @p1, @p2, @p3, @p4);
        SELECT "DepartmentID"
        FROM "Departments"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?', @p2='?', @p3='?' (Size = 9), @p4='?'], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Departments" ("Budget", "ConcurrencyToken", "InstructorID", "Name", "StartDate")
        VALUES (@p0, @p1, @p2, @p3, @p4);
        SELECT "DepartmentID"
        FROM "Departments"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?', @p2='?', @p3='?' (Size = 7), @p4='?'], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Departments" ("Budget", "ConcurrencyToken", "InstructorID", "Name", "StartDate")
        VALUES (@p0, @p1, @p2, @p3, @p4);
        SELECT "DepartmentID"
        FROM "Departments"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?' (Size = 8)], CommandType='Text', CommandTimeout='30']
        INSERT INTO "OfficeAssignments" ("InstructorID", "Location")
        VALUES (@p0, @p1);
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?' (Size = 8)], CommandType='Text', CommandTimeout='30']
        INSERT INTO "OfficeAssignments" ("InstructorID", "Location")
        VALUES (@p0, @p1);
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?' (Size = 12)], CommandType='Text', CommandTimeout='30']
        INSERT INTO "OfficeAssignments" ("InstructorID", "Location")
        VALUES (@p0, @p1);
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p2='?', @p3='?', @p4='?', @p5='?' (Size = 8)], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Course" ("CourseID", "Credits", "DepartmentID", "Title")
        VALUES (@p2, @p3, @p4, @p5);
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?', @p2='?', @p3='?' (Size = 12)], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Course" ("CourseID", "Credits", "DepartmentID", "Title")
        VALUES (@p0, @p1, @p2, @p3);
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?', @p2='?', @p3='?' (Size = 9)], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Course" ("CourseID", "Credits", "DepartmentID", "Title")
        VALUES (@p0, @p1, @p2, @p3);
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?', @p2='?', @p3='?' (Size = 14)], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Course" ("CourseID", "Credits", "DepartmentID", "Title")
        VALUES (@p0, @p1, @p2, @p3);
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?', @p2='?', @p3='?' (Size = 14)], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Course" ("CourseID", "Credits", "DepartmentID", "Title")
        VALUES (@p0, @p1, @p2, @p3);
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?', @p2='?', @p3='?' (Size = 11)], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Course" ("CourseID", "Credits", "DepartmentID", "Title")
        VALUES (@p0, @p1, @p2, @p3);
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?', @p2='?', @p3='?' (Size = 10)], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Course" ("CourseID", "Credits", "DepartmentID", "Title")
        VALUES (@p0, @p1, @p2, @p3);
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p4='?', @p5='?'], CommandType='Text', CommandTimeout='30']
        INSERT INTO "CourseInstructor" ("CoursesCourseID", "InstructorsID")
        VALUES (@p4, @p5);
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?'], CommandType='Text', CommandTimeout='30']
        INSERT INTO "CourseInstructor" ("CoursesCourseID", "InstructorsID")
        VALUES (@p0, @p1);
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?'], CommandType='Text', CommandTimeout='30']
        INSERT INTO "CourseInstructor" ("CoursesCourseID", "InstructorsID")
        VALUES (@p0, @p1);
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?'], CommandType='Text', CommandTimeout='30']
        INSERT INTO "CourseInstructor" ("CoursesCourseID", "InstructorsID")
        VALUES (@p0, @p1);
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?'], CommandType='Text', CommandTimeout='30']
        INSERT INTO "CourseInstructor" ("CoursesCourseID", "InstructorsID")
        VALUES (@p0, @p1);
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?'], CommandType='Text', CommandTimeout='30']
        INSERT INTO "CourseInstructor" ("CoursesCourseID", "InstructorsID")
        VALUES (@p0, @p1);
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?'], CommandType='Text', CommandTimeout='30']
        INSERT INTO "CourseInstructor" ("CoursesCourseID", "InstructorsID")
        VALUES (@p0, @p1);
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?'], CommandType='Text', CommandTimeout='30']
        INSERT INTO "CourseInstructor" ("CoursesCourseID", "InstructorsID")
        VALUES (@p0, @p1);
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?', @p2='?'], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Enrollments" ("CourseID", "Grade", "StudentID")
        VALUES (@p0, @p1, @p2);
        SELECT "EnrollmentID"
        FROM "Enrollments"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?', @p2='?'], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Enrollments" ("CourseID", "Grade", "StudentID")
        VALUES (@p0, @p1, @p2);
        SELECT "EnrollmentID"
        FROM "Enrollments"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?', @p2='?'], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Enrollments" ("CourseID", "Grade", "StudentID")
        VALUES (@p0, @p1, @p2);
        SELECT "EnrollmentID"
        FROM "Enrollments"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?', @p2='?'], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Enrollments" ("CourseID", "Grade", "StudentID")
        VALUES (@p0, @p1, @p2);
        SELECT "EnrollmentID"
        FROM "Enrollments"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?', @p2='?'], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Enrollments" ("CourseID", "Grade", "StudentID")
        VALUES (@p0, @p1, @p2);
        SELECT "EnrollmentID"
        FROM "Enrollments"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?', @p2='?'], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Enrollments" ("CourseID", "Grade", "StudentID")
        VALUES (@p0, @p1, @p2);
        SELECT "EnrollmentID"
        FROM "Enrollments"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?', @p2='?'], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Enrollments" ("CourseID", "Grade", "StudentID")
        VALUES (@p0, @p1, @p2);
        SELECT "EnrollmentID"
        FROM "Enrollments"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?', @p2='?'], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Enrollments" ("CourseID", "Grade", "StudentID")
        VALUES (@p0, @p1, @p2);
        SELECT "EnrollmentID"
        FROM "Enrollments"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?', @p2='?'], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Enrollments" ("CourseID", "Grade", "StudentID")
        VALUES (@p0, @p1, @p2);
        SELECT "EnrollmentID"
        FROM "Enrollments"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?', @p2='?'], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Enrollments" ("CourseID", "Grade", "StudentID")
        VALUES (@p0, @p1, @p2);
        SELECT "EnrollmentID"
        FROM "Enrollments"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        Executed DbCommand (0ms) [Parameters=[@p0='?', @p1='?', @p2='?'], CommandType='Text', CommandTimeout='30']
        INSERT INTO "Enrollments" ("CourseID", "Grade", "StudentID")
        VALUES (@p0, @p1, @p2);
        SELECT "EnrollmentID"
        FROM "Enrollments"
        WHERE changes() = 1 AND "rowid" = last_insert_rowid();
    info: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager[63]
        User profile is available. Using 'C:\Users\atiq\AppData\Local\ASP.NET\DataProtection-Keys' as key repository and Windows DPAPI to encrypt keys at rest.
    info: Microsoft.Hosting.Lifetime[0]
        Now listening on: https://localhost:5001
    info: Microsoft.Hosting.Lifetime[0]
        Now listening on: http://localhost:5000
    info: Microsoft.Hosting.Lifetime[0]
        Application started. Press Ctrl+C to shut down.
    info: Microsoft.Hosting.Lifetime[0]
        Hosting environment: Development
    info: Microsoft.Hosting.Lifetime[0]
        Content root path: D:\git_ws\aspnetcore\cu50
