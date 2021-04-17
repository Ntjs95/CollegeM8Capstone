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
