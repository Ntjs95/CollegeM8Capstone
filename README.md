# CollegeM8

## User Endpoint

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

`POST/api/User`

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

## Sleep Endpoint

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