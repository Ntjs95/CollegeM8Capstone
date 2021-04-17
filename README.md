# CollegeM8

# User Endpoint

### GET User

`GET /api/User/{id}`

**Required:**

`id=[guid]`

**Optional:**

`expand=[boolean]`

Success Response `200 OK`

Examples:

`GET /api/User/877c19c4-b387-40a8-af8e-00523c2c7ede`

```json
{
  "userId": "877c19c4-b387-40a8-af8e-00523c2c7ede",
  "username": "JDUsername",
  "firstName": "John",
  "lastName": "Dough",
  "schoolName": "School Name",
  "programName": "Program Name",
  "emailAddress": "email@domain.com",
  "birthDate": "2000-01-01T00:00:00"
}
```

`GET /api/User/877c19c4-b387-40a8-af8e-00523c2c7ede?expand=true`

```json
{
  "userId": "877c19c4-b387-40a8-af8e-00523c2c7ede",
  "username": "JDUsername",
  "firstName": "John",
  "lastName": "Dough",
  "schoolName": "School Name",
  "programName": "Program Name",
  "emailAddress": "email@domain.com",
  "birthDate": "2000-01-01T00:00:00",
  "sleep": {
    "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
    "hoursWeekday": 10,
    "hoursWeekend": 9,
    "wakeTimeWeekday": "0001-01-01T06:30:00",
    "wakeTimeWeekend": "0001-01-01T07:45:00"
  },
  "terms": [
    {
      "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
      "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
      "startDate": "2021-01-01T00:00:00",
      "endDate": "2021-05-01T00:00:00",
      "classes": [
        {
          "classId": "369a7541-0f11-4267-aabb-0572e5156516",
          "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
          "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
          "courseCode": "Course Code",
          "className": "Class Name",
          "startTime": "0001-01-01T21:43:00",
          "endTime": "0001-01-01T21:49:00",
          "monday": false,
          "tuesday": false,
          "wednesday": true,
          "thursday": false,
          "friday": false,
          "saturday": false,
          "sunday": false,
          "exams": [
            {
              "examId": "c494c6ff-88df-4747-b2b0-c195cebed29a",
              "classId": "369a7541-0f11-4267-aabb-0572e5156516",
              "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
              "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
              "startTime": "2021-04-07T19:28:00",
              "endTime": "2021-04-07T19:32:00"
            }
          ],
          "assignments": [
            {
              "assignmentId": "357f49f0-7ded-430a-bf4b-354fd69f9a99",
              "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
              "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
              "classId": "369a7541-0f11-4267-aabb-0572e5156516",
              "releaseDate": "2021-04-05T00:00:00",
              "dueDate": "2021-04-30T00:00:00",
              "gradeWeight": 25,
              "hoursToComplete": 2
            }
          ]
        }
      ]
    }
  ]
}
```

Error Response `400 Bad Request`

```
User Does Not Exist
```

### POST User

`POST /api/User`

**Required Body Data:**

```json
{
  "username": "JDUsername",
  "password": "12345678",
  "firstName": "John",
  "lastName": "Dough",
  "schoolName": "School Name",
  "programName": "Program Name",
  "emailAddress": "email@domain.com",
  "birthDate": "2000-01-01T00:00:00"
}
```

Success Response `200 OK`

Response structure:

```json
{
  "userId": "877c19c4-b387-40a8-af8e-00523c2c7ede",
  "username": "JDUsername",
  "firstName": "John",
  "lastName": "Dough",
  "schoolName": "School Name",
  "programName": "Program Name",
  "emailAddress": "email@domain.com",
  "birthDate": "2000-01-01T00:00:00"
}
```

Error Response `400 Bad Request`

`User Already Exists`

### PUT User

`PUT /api/User`

**Required Body Data:**

```json
{
  "userId": "877c19c4-b387-40a8-af8e-00523c2c7ede",
  "username": "JDUsername",
  "firstName": "John2",
  "lastName": "Dough",
  "schoolName": "School Name",
  "programName": "Program Name",
  "emailAddress": "email@domain.com",
  "birthDate": "2000-01-01T00:00:00"
}
```

Success Response `200 OK`

Response structure:

```json
{
  "userId": "877c19c4-b387-40a8-af8e-00523c2c7ede",
  "username": "JDUsername",
  "firstName": "John2",
  "lastName": "Dough",
  "schoolName": "School Name",
  "programName": "Program Name",
  "emailAddress": "email@domain.com",
  "birthDate": "2000-01-01T00:00:00"
}
```

Error Response `400 Bad Request`

### POST User Login

`POST /api/User/Login`

**Required Body Data:**

```json
{
  "username": "JDUsername",
  "password": "1235678"
}
```

Success Response `200 OK`

Examples:

`POST /api/User/Login`

```json
{
  "userId": "877c19c4-b387-40a8-af8e-00523c2c7ede",
  "username": "JDUsername",
  "firstName": "John",
  "lastName": "Dough",
  "schoolName": "School Name",
  "programName": "Program Name",
  "emailAddress": "email@domain.com",
  "birthDate": "2000-01-01T00:00:00"
}
```

Error Response `400 Bad Request`

`Login attempt failed`

### POST User Password Change

`POST /api/User/ChangePassword`

**Required Body Data:**

```json
{
  "username": "JDUsername",
  "oldPassword": "12345678",
  "newPassword": "ABCDEFGH"
}
```

Success Response `200 OK`

Examples:

`POST /api/User`

```json
{
  "userId": "877c19c4-b387-40a8-af8e-00523c2c7ede",
  "username": "JDUsername",
  "firstName": "John",
  "lastName": "Dough",
  "schoolName": "School Name",
  "programName": "Program Name",
  "emailAddress": "email@domain.com",
  "birthDate": "2000-01-01T00:00:00"
}
```

Error Response `400 Bad Request`

`Login attempt failed`

### GET User's Next Event

`GET /api/User/NextEvent/{id}`

**Required:**

`id=[guid]`

Success Response `200 OK`

Examples:

`GET /api/User/NextEvent/877c19c4-b387-40a8-af8e-00523c2c7ede`

```json
{
  "title": "Exam Soon!",
  "description": "The exam for Macro-Economics is approaching!",
  "dateStr": "Saturday, 17 April 2021",
  "timeStr": "08:30 AM"
}
```

---

# Sleep Endpoint

### GET Sleep

`GET /api/Sleep/{userId}`

**Required:**

`userId=[guid]`

Success Response `200 OK`

Examples:

`GET /api/Sleep/877c19c4-b387-40a8-af8e-00523c2c7ede`

```json
{
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "hoursWeekday": 10,
  "hoursWeekend": 9,
  "wakeTimeWeekday": "0001-01-01T06:30:00",
  "wakeTimeWeekend": "0001-01-01T07:45:00"
}
```

Error Response `400 Bad Request`

```
No sleep data found for this user
```

### PUT Sleep

`PUT /api/Sleep`

**Required Body Data:**

```json
{
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "hoursWeekday": 10,
  "hoursWeekend": 9,
  "wakeTimeWeekday": "0001-01-01T06:30:00",
  "wakeTimeWeekend": "0001-01-01T07:45:00"
}
```

Success Response `200 OK`

Response structure:

```json
{
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "hoursWeekday": 10,
  "hoursWeekend": 9,
  "wakeTimeWeekday": "0001-01-01T06:30:00",
  "wakeTimeWeekend": "0001-01-01T07:45:00"
}
```

Error Response `400 Bad Request`

`No sleep data found for this user.`

# Term Endpoint

### GET Term

`GET /api/Term/{id}`

**Required:**

`id=[guid]`

Success Response `200 OK`

Examples:

`GET /api/Term/cc6dad52-c706-4244-a2dc-01a60404a9ee`

```json
{
  "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "startDate": "2021-01-01T00:00:00",
  "endDate": "2021-05-01T00:00:00"
}
```

Error Response `400 Bad Request`

```
Could not find term
```

### GET Terms by User Id

`GET /api/Term/User/{UserId}`

**Required:**

`UserId=[guid]`

Success Response `200 OK`

Examples:

`GET /api/Term/User/877c19c4-b387-40a8-af8e-00523c2c4ede`

```json
[
  {
    "termId": "05761bc4-5f3b-41f7-89b8-732fd97b0dde",
    "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
    "startDate": "2034-03-01T00:00:00",
    "endDate": "2034-04-01T00:00:00"
  },
  {
    "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
    "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
    "startDate": "2021-01-01T00:00:00",
    "endDate": "2021-05-01T00:00:00"
  }
]
```

Error Response `400 Bad Request`

```
Could not find terms
```

### POST Term

`POST /api/Term`

**Required Body Data:**

```json
{
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "startDate": "2022-03-01",
  "endDate": "2022-04-01"
}
```

Success Response `200 OK`

Response structure:

```json
{
  "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "startDate": "2022-03-01T00:00:00",
  "endDate": "2022-04-01T00:00:00"
}
```

Error Response `400 Bad Request`

`Terms cannot overlap.`

### PUT Term

`PUT /api/Term`

**Required Body Data:**

```json
{
  "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "startDate": "2022-03-02",
  "endDate": "2022-04-01"
}
```

Success Response `200 OK`

Response structure:

```json
{
  "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "startDate": "2022-03-02T00:00:00",
  "endDate": "2022-04-01T00:00:00"
}
```

Error Response `400 Bad Request`

`Terms cannot overlap.`

### DELETE Term

`DELETE /api/Term/{id}`

**Required:**

`id=[guid]`

Success Response `200 OK`

Response structure:

```json
true
```

Error Response `400 Bad Request`

`Error deleting term.`

# Class Endpoint

### GET Class

`GET /api/Class/{id}`

**Required:**

`id=[guid]`

Success Response `200 OK`

Examples:

`GET /api/Class/369a7541-0f11-4267-aabb-0572e5156516`

```json
{
  "classId": "369a7541-0f11-4267-aabb-0572e5156516",
  "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "courseCode": "Course Code",
  "className": "Class Name",
  "startTime": "0001-01-01T21:43:00",
  "endTime": "0001-01-01T21:49:00",
  "monday": false,
  "tuesday": false,
  "wednesday": true,
  "thursday": false,
  "friday": false,
  "saturday": false,
  "sunday": false
}
```

Error Response `400 Bad Request`

```
Could not find class
```

### GET Classes by User Id

`GET /api/Class/User/{userId}`

**Required:**

`userId=[guid]`

Success Response `200 OK`

Examples:

`GET /api/Class/User/877c19c4-b387-40a8-af8e-00523c2c4ede`

```json
[
  {
    "classId": "0abd6530-f7d3-4847-964c-94512902c3e2",
    "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
    "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
    "courseCode": "ECON 102",
    "className": "Macro-Economics",
    "startTime": "0001-01-01T14:30:00",
    "endTime": "0001-01-01T16:30:00",
    "monday": false,
    "tuesday": true,
    "wednesday": false,
    "thursday": true,
    "friday": false,
    "saturday": false,
    "sunday": false
  },
  {
    "classId": "369a7541-0f11-4267-aabb-0572e5156516",
    "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
    "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
    "courseCode": "Other101",
    "className": "Class",
    "startTime": "0001-01-01T21:43:00",
    "endTime": "0001-01-01T21:49:00",
    "monday": false,
    "tuesday": false,
    "wednesday": true,
    "thursday": false,
    "friday": false,
    "saturday": false,
    "sunday": false
  }
]
```

Error Response `400 Bad Request`

```
Could not find classes
```

### POST Class

`POST /api/Class`

**Required Body Data:**

```json
{
  "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "courseCode": "Course Code",
  "className": "Class Name",
  "startTime": "0001-01-01T21:43:00",
  "endTime": "0001-01-01T21:49:00",
  "monday": false,
  "tuesday": false,
  "wednesday": true,
  "thursday": false,
  "friday": false,
  "saturday": false,
  "sunday": false
}
```

Success Response `200 OK`

Response structure:

```json
{
  "classId": "369a7541-0f11-4267-aabb-0572e5156516",
  "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "courseCode": "Course Code",
  "className": "Class Name",
  "startTime": "0001-01-01T21:43:00",
  "endTime": "0001-01-01T21:49:00",
  "monday": false,
  "tuesday": false,
  "wednesday": true,
  "thursday": false,
  "friday": false,
  "saturday": false,
  "sunday": false
}
```

Error Response `400 Bad Request`

`Error creating class.`

### PUT Class

`PUT /api/Class`

**Required Body Data:**

```json
{
  "classId": "369a7541-0f11-4267-aabb-0572e5156516",
  "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "courseCode": "Course Code",
  "className": "Class Name",
  "startTime": "0001-01-01T21:43:00",
  "endTime": "0001-01-01T21:49:00",
  "monday": true,
  "tuesday": false,
  "wednesday": true,
  "thursday": false,
  "friday": false,
  "saturday": false,
  "sunday": false
}
```

Success Response `200 OK`

Response structure:

```json
{
  "classId": "369a7541-0f11-4267-aabb-0572e5156516",
  "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "courseCode": "Course Code",
  "className": "Class Name",
  "startTime": "0001-01-01T21:43:00",
  "endTime": "0001-01-01T21:49:00",
  "monday": true,
  "tuesday": false,
  "wednesday": true,
  "thursday": false,
  "friday": false,
  "saturday": false,
  "sunday": false
}
```

Error Response `400 Bad Request`

`Error updating class.`

### DELETE Class

`DELETE /api/Class/{id}`

**Required:**

`id=[guid]`

Success Response `200 OK`

Response structure:

```json
true
```

Error Response `400 Bad Request`

`Error deleting class.`

# Assignment Endpoint

### GET Assignment

`GET /api/Assignment/{id}`

**Required:**

`id=[guid]`

Success Response `200 OK`

Examples:

`GET /api/Assignment/357f49f0-7ded-430a-bf4b-354fd69f9a99`

```json
{
  "assignmentId": "357f49f0-7ded-430a-bf4b-354fd69f9a99",
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
  "classId": "369a7541-0f11-4267-aabb-0572e5156516",
  "releaseDate": "2021-04-05T00:00:00",
  "dueDate": "2021-04-30T00:00:00",
  "gradeWeight": 25,
  "hoursToComplete": 2
}
```

Error Response `400 Bad Request`

```
Could not find assignment
```

### GET Assignments by User Id

`GET /api/Assignment/User/{userId}`

**Required:**

`userId=[guid]`

Success Response `200 OK`

Examples:

`GET /api/Assignment/User/877c19c4-b387-40a8-af8e-00523c2c4ede`

```json
[
  {
    "assignmentId": "07999bf6-cf26-4afe-be2a-4ea3103358eb",
    "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
    "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
    "classId": "a2e302a3-c8d8-42ee-9882-4519899e0230",
    "releaseDate": "2021-04-06T00:00:00",
    "dueDate": "2021-04-30T00:00:00",
    "gradeWeight": 36,
    "hoursToComplete": 2
  },
  {
    "assignmentId": "357f49f0-7ded-430a-bf4b-354fd69f9a99",
    "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
    "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
    "classId": "369a7541-0f11-4267-aabb-0572e5156516",
    "releaseDate": "2021-04-05T00:00:00",
    "dueDate": "2021-04-30T00:00:00",
    "gradeWeight": 25,
    "hoursToComplete": 2
  }
]
```

Error Response `400 Bad Request`

```
Could not find assignments
```

### POST Assignment

`POST /api/Assignment`

**Required Body Data:**

```json
{
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
  "classId": "369a7541-0f11-4267-aabb-0572e5156516",
  "releaseDate": "2021-04-05T00:00:00",
  "dueDate": "2021-04-30T00:00:00",
  "gradeWeight": 25,
  "hoursToComplete": 2
}
```

Success Response `200 OK`

Response structure:

```json
{
  "assignmentId": "357f49f0-7ded-430a-bf4b-354fd69f9a99",
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
  "classId": "369a7541-0f11-4267-aabb-0572e5156516",
  "releaseDate": "2021-04-05T00:00:00",
  "dueDate": "2021-04-30T00:00:00",
  "gradeWeight": 25,
  "hoursToComplete": 2
}
```

Error Response `400 Bad Request`

`Error creating assignment.`

### PUT Assignment

`PUT /api/Assignment`

**Required Body Data:**

```json
{
  "assignmentId": "357f49f0-7ded-430a-bf4b-354fd69f9a99",
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
  "classId": "369a7541-0f11-4267-aabb-0572e5156516",
  "releaseDate": "2021-04-05T00:00:00",
  "dueDate": "2021-04-30T00:00:00",
  "gradeWeight": 25,
  "hoursToComplete": 8
}
```

Success Response `200 OK`

Response structure:

```json
{
  "assignmentId": "357f49f0-7ded-430a-bf4b-354fd69f9a99",
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
  "classId": "369a7541-0f11-4267-aabb-0572e5156516",
  "releaseDate": "2021-04-05T00:00:00",
  "dueDate": "2021-04-30T00:00:00",
  "gradeWeight": 25,
  "hoursToComplete": 8
}
```

Error Response `400 Bad Request`

`Error updating assignment.`

### DELETE Assignment

`DELETE /api/Assignment/{id}`

**Required:**

`id=[guid]`

Success Response `200 OK`

Response structure:

```json
true
```

Error Response `400 Bad Request`

`Error deleting assignment.`

# Exam Endpoint

### GET Exam

`GET /api/Exam/{id}`

**Required:**

`id=[guid]`

Success Response `200 OK`

Examples:

`GET /api/Exam/c494c6ff-88df-4747-b2b0-c195cebed29a`

```json
{
  "examId": "c494c6ff-88df-4747-b2b0-c195cebed29a",
  "classId": "369a7541-0f11-4267-aabb-0572e5156516",
  "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "startTime": "2021-04-07T19:28:00",
  "endTime": "2021-04-07T19:32:00"
}
```

Error Response `400 Bad Request`

```
Could not find exam
```

### GET Exams by User Id

`GET /api/Exam/User/{userId}`

**Required:**

`userId=[guid]`

Success Response `200 OK`

Examples:

`GET /api/Exam/User/877c19c4-b387-40a8-af8e-00523c2c4ede`

```json
[
  {
    "examId": "35570a50-6a4e-4bbf-aa49-47539ef65356",
    "classId": "0abd6530-f7d3-4847-964c-94512902c3e2",
    "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
    "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
    "startTime": "2021-04-05T13:07:00",
    "endTime": "2021-04-05T14:51:00"
  },
  {
    "examId": "a45c640f-e25a-487d-afec-aef1f42101ff",
    "classId": "0abd6530-f7d3-4847-964c-94512902c3e2",
    "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
    "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
    "startTime": "2021-04-17T08:46:00",
    "endTime": "2021-04-17T10:37:00"
  }
]
```

Error Response `400 Bad Request`

```
Could not find exams
```

### POST Exam

`POST /api/Exam`

**Required Body Data:**

```json
{
  "classId": "369a7541-0f11-4267-aabb-0572e5156516",
  "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "startTime": "2021-04-07T19:28:00",
  "endTime": "2021-04-07T19:32:00"
}
```

Success Response `200 OK`

Response structure:

```json
{
  "examId": "c494c6ff-88df-4747-b2b0-c195cebed29a",
  "classId": "369a7541-0f11-4267-aabb-0572e5156516",
  "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "startTime": "2021-04-07T19:28:00",
  "endTime": "2021-04-07T19:32:00"
}
```

Error Response `400 Bad Request`

`Error creating exam.`

### PUT Exam

`PUT /api/Exam`

**Required Body Data:**

```json
{
  "examId": "c494c6ff-88df-4747-b2b0-c195cebed29a",
  "classId": "369a7541-0f11-4267-aabb-0572e5156516",
  "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "startTime": "2021-04-07T19:28:00",
  "endTime": "2021-04-07T20:32:00"
}
```

Success Response `200 OK`

Response structure:

```json
{
  "examId": "c494c6ff-88df-4747-b2b0-c195cebed29a",
  "classId": "369a7541-0f11-4267-aabb-0572e5156516",
  "termId": "cc6dad52-c706-4244-a2dc-01a60404a9ee",
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "startTime": "2021-04-07T19:28:00",
  "endTime": "2021-04-07T20:32:00"
}
```

Error Response `400 Bad Request`

`Error updating exam.`

### DELETE Exam

`DELETE /api/Exam/{id}`

**Required:**

`id=[guid]`

Success Response `200 OK`

Response structure:

```json
true
```

Error Response `400 Bad Request`

`Error deleting exam.`

# ScheduleItem Endpoint

### GET ScheduleItem

`GET /api/ScheduleItem/{id}`

**Required:**

`id=[guid]`

Success Response `200 OK`

Examples:

`GET /api/ScheduleItem/b66a7180-4666-4165-8686-fb70c77e1be3`

```json
{
  "scheduleItemId": "b66a7180-4666-4165-8686-fb70c77e1be3",
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "title": "EXAM: ECON 102 - Macro-Economics",
  "startTime": "2021-04-17T08:46:00",
  "endTime": "2021-04-17T10:37:00"
}
```

Error Response `400 Bad Request`

```
Could not find schedule item
```

### POST ScheduleItem

`POST /api/ScheduleItem`

**Required Body Data:**

```json
{
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "title": "EXAM: ECON 102 - Macro-Economics",
  "startTime": "2021-04-17T08:46:00",
  "endTime": "2021-04-17T10:37:00"
}
```

Success Response `200 OK`

Response structure:

```json
{
  "scheduleItemId": "b66a7180-4666-4165-8686-fb70c77e1be3",
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "title": "EXAM: ECON 102 - Macro-Economics",
  "startTime": "2021-04-17T08:46:00",
  "endTime": "2021-04-17T10:37:00"
}
```

Error Response `400 Bad Request`

`Error creating schedule item.`

### PUT ScheduleItem

`POST /api/ScheduleItem`

**Required Body Data:**

```json
{
  "scheduleItemId": "b66a7180-4666-4165-8686-fb70c77e1be3",
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "title": "EXAM: ECON 102 - Macro-Economics",
  "startTime": "2021-04-17T06:46:00",
  "endTime": "2021-04-17T10:37:00"
}
```

Success Response `200 OK`

Response structure:

```json
{
  "scheduleItemId": "b66a7180-4666-4165-8686-fb70c77e1be3",
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "title": "EXAM: ECON 102 - Macro-Economics",
  "startTime": "2021-04-17T06:46:00",
  "endTime": "2021-04-17T10:37:00"
}
```

Error Response `400 Bad Request`

`Error updating schedule item.`

### DELETE ScheduleItem

`DELETE /api/ScheduleItem/{id}`

**Required:**

`id=[guid]`

Success Response `200 OK`

Response structure:

```json
true
```

Error Response `400 Bad Request`

`Error deleting schedule item.`

# Schedule Endpoint

### GET Schedule

`GET /api/Schedule/{userId}`

**Required:**

`userId=[guid]`

Success Response `200 OK`

Examples:

`GET /api/Schedule/877c19c4-b387-40a8-af8e-00523c2c4ede`

```json
{
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "startDate": "0001-01-01T00:00:00",
  "endDate": "0001-01-01T00:00:00",
  "schedule": [
    {
      "scheduleItemId": "b66a7180-4666-4165-8686-fb70c77e1be3",
      "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
      "title": "EXAM: ECON 102 - Macro-Economics",
      "startTime": "2021-04-17T08:46:00",
      "endTime": "2021-04-17T10:37:00"
    },
    {
      "scheduleItemId": "dfe38bbe-c415-45df-ad60-9e10c3d7a8b0",
      "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
      "title": "SLEEP",
      "startTime": "2021-04-17T22:45:00",
      "endTime": "2021-04-18T07:45:00"
    },
    {
      "scheduleItemId": "daee6b19-1cc9-458a-a1d7-6164415050c6",
      "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
      "title": "SLEEP",
      "startTime": "2021-04-18T20:30:00",
      "endTime": "2021-04-19T06:30:00"
    }
  ]
}
```

Error Response `400 Bad Request`

```
Could not find schedule item
```

### POST Schedule

This call triggers the AI algorithm to generate a schedule for the specified user, between the start and end date.

`POST /api/Schedule`

**Required Body Data:**

```json
{
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "startDate": "2021-04-17T00:00:00",
  "endDate": "2021-04-20T00:00:00"
}
```

Success Response `200 OK`

Examples:

`POST /api/Schedule`

```json
{
  "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
  "startDate": "2021-04-17T00:00:00",
  "endDate": "2021-04-20T00:00:00",
  "schedule": [
    {
      "scheduleItemId": "b66a7180-4666-4165-8686-fb70c77e1be3",
      "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
      "title": "EXAM: ECON 102 - Macro-Economics",
      "startTime": "2021-04-17T08:46:00",
      "endTime": "2021-04-17T10:37:00"
    },
    {
      "scheduleItemId": "dfe38bbe-c415-45df-ad60-9e10c3d7a8b0",
      "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
      "title": "SLEEP",
      "startTime": "2021-04-17T22:45:00",
      "endTime": "2021-04-18T07:45:00"
    },
    {
      "scheduleItemId": "daee6b19-1cc9-458a-a1d7-6164415050c6",
      "userId": "877c19c4-b387-40a8-af8e-00523c2c4ede",
      "title": "SLEEP",
      "startTime": "2021-04-18T20:30:00",
      "endTime": "2021-04-19T06:30:00"
    }
  ]
}
```

Error Response `400 Bad Request`

```
Error creating schedule data. Check logs for details.
```
