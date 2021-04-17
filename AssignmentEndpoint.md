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