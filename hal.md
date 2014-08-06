# HAL

http://tools.ietf.org/html/draft-kelly-json-hal-06

This is a first draft of how the API might be presented using the HAL media type.

## GET /reminders/emails/523

The response would include:
- `_links`
  - `self` link to itself
  - `address` - the associated address resource
  - `email` - the associated email resource.
- `remindOn` - property of `/reminders/emails/523`
- `_embedded` includes the associated resources, address and email, in the response. This is optional and clients must look to see if embedded data is present and if it isn't then individual requests to the provided links will be necessary.

```
{
  "_links": {
    "self": { "href": "/reminders/email/523" },
    "address": { "href": "/addresses/89"}
    "email": { "href": "/email/56" }
  },
  "remindOn": "2014-09-01",
  "_embedded": {
    "address": {
      "_links": {
        "self": { "href": "/addresses/89" },
        "reminders": { "href": "/addresses/89/reminders" }
      },
      "longitude": "123.456",
      "latitude": "90.123",
      "accuracy": 0.5
    },
    "email": {
      "_links": {
        "self": { "href": "/email/56" },
        "reminders": { "href": "/email/56/reminders" }
      },
      "to": "someone@example.com"
    }
  }
}
```

## GET /reminders/sms

The response would include:
- `_links`
  - `self` link to itself
  - `next` page of results
  - `find` one by id.
- `_embedded` includes the first page of results
  - The items in the result don't have embedded data.
  - They could, but perhaps convention would be to require individual requests to fetch data more than one layer deep.

```
{
  "_links": {
    "self": { "href": "/reminders/sms" },
    "next": { "href": "/reminders/sms?page=2" },
    "find": { "href": "/reminders/sms{?id}", "templated": true }
  },
  "_embedded": {
    "remindersSms": [
      {
        "_links": {
          "self": { "href": "/reminders/sms/1" },
          "address": { "href": "/addresses/23"}
          "sms": { "href": "/sms/78" }
        },
        "remindOn": "2014-08-01"
      },
      {
        "_links": {
          "self": { "href": "/reminders/sms/2" },
          "address": { "href": "/addresses/23"}
          "sms": { "href": "/sms/78" }
        },
        "remindOn": "2014-07-01"
      }
    ]
  }
}
```