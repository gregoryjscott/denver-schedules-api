# API Round 2

## Current

* `POST /authenticate`
* `POST /reminders/email`
* `POST /reminders/sms`
* `POST /reminders/email/send`
* `POST /reminders/sms/send`
* `GET /schedules/streetssweeping`
* `GET /schedules/holidays`
* `GET /status`

## Proposed

* `GET /` (new)
  - links to `/authenticate`, `doc`, `/reminders`, `/send`, `/schedules`, and `/status` resources
  - JSON would be
  ```
  {
    "_links": {
      "self": "/"
      "authenticate": "/authenticate",
      "doc": "/doc",
      "reminders": "/reminders",
      "send": "/send",
      "schedules": "/schedules",
      "status": "/status"
    }
  }
  ```
  - should `/index.html` and `/index.json` be treated differently?
    - JSON representation of the `/` resource would be hypermedia links
    - HTML representation would include instructions for hitting the JSON links, especially `/doc`
    - .index vs. .json or Accept headers could be used
* `POST /authenticate`
* `GET /reminders` (new)
  - links to `/reminders/email` and `/reminders/sms` resources
* `POST /reminders/email`
* `POST /reminders/sms`
* `GET /schedules` (new)
  - links to `/schedules/streets`, `/schedules/holidays` resources
* `GET /schedules/streets`
  - link to `/schedules/streets/sweeping` resource
* `GET /schedules/streets/sweeping`
* `GET /schedules/holidays`
* `GET /send` (new)
  - links to `/send/email/reminders`, `/send/sms/reminders` resources
* `POST /send/email/reminders` (renamed)
  - might consider swapping _email_ and _reminders_, i.e. `send/reminders/email`
    - not as readable but matches up with `/reminders/email` resource
* `POST /send/sms/reminders` (renamed)
  - see `/send/email/reminders` comments
* `GET /status`

### Swagger (documentation)

Follow the pattern of `/doc/{resource}`

* `GET /doc`
* `GET /doc/authenticate`
* `GET /doc/reminders`
* `GET /doc/reminders/email`
* etc.

Would the API return the Swagger specs (JSON) for `/doc.json` and the actual documentation generated from the Swagger specs at `/doc.html` or `/doc`?
