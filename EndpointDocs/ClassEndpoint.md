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