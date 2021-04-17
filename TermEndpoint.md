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