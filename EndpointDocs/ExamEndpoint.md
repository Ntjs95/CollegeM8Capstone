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