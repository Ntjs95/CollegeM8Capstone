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