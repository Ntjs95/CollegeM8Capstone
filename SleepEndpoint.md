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