# ToDo API

- [ToDo API](#buber-breakfast-api)
  - [Create ToDo](#create-breakfast)
    - [Create ToDo Request](#create-breakfast-request)
 
 # Create ToDo

### Create ToDo Request

```js
POST /todo
```

```json
{
    "title": "Make up your bed",
    "description": "Every morning you need to make up your bed",
    "startDateTime": "2024-03-08T08:00:00",
    "endDateTime": "2025-04-08T11:00:00",
    "priority" : [
        "low"
    ],
    "tags": [
        "bed",
        "sleep",
        "mood",
        "order"
    ]
}
```

### Create ToDo Response

```js
201 Created
```

```yml
Location: {{host}}/todo/{{id}}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "title": "Make up your bed",
    "description": "Every morning you need to make up your bed",
    "startDateTime": "2024-03-08T08:00:00",
    "endDateTime": "2025-04-08T11:00:00",
    "priority" : [
        "low"
    ],
    "tags": [
        "bed",
        "sleep",
        "mood",
        "order"
    ]
}
```

## Get ToDo

### Get ToDo Request

```js
GET /todo/{{id}}
```

### Get ToDo Response

```js
200 Ok
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "title": "Make up your bed",
    "description": "Every morning you need to make up your bed",
    "startDateTime": "2024-03-08T08:00:00",
    "endDateTime": "2025-04-08T11:00:00",
    "lastModifiedDateTime": "2024-03-08T12:00:00",
    "priority" : [
        "low"
    ],
    "tags": [
        "bed",
        "sleep",
        "mood",
        "order"
    ]
}
```

## Update ToDo

### Update ToDo Request

```js
PUT /todo/{{id}}
```

```json
{
    "title": "Make up your bed",
    "description": "Every morning you need to make up your bed",
    "startDateTime": "2024-03-08T08:00:00",
    "endDateTime": "2025-04-08T11:00:00",
    "lastModifiedDateTime": "2024-03-08T12:00:00",
    "priority" : [
        "low"
    ],
    "tags": [
        "bed",
        "sleep",
        "mood",
        "order"
    ]
}
```

### Update ToDo Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/todo/{{id}}
```

## Delete ToDo

### Delete ToDo Request

```js
DELETE /todo/{{id}}
```

### Delete ToDo Response

```js
204 No Content
```