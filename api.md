# API

## Current

* POST /reminders (POST data contains sms, email, etc. and physical address)
* POST /reminders/notify (in add-twilio)
* POST /reminders/triggers (in email-triggers branch)
* GET /reminderTypes
* GET /schedules/streetsweeping
* GET /schedules/holidays
* GET /status

## Proposed

* POST /reminders/email
* POST /reminders/sms
* POST /reminders/yo
* POST /reminders/email/trigger
* POST /reminders/sms/trigger
* POST /reminders/yo/trigger
* GET /schedules/streets/sweeping
* GET /schedules/holidays
* GET /status

* GET /reminders/email (one per user)
* GET /notifications/email (one per notification)
* DELETE /reminders/email (POST data would have to contain sms # and physical address)

## Other potential routes (brainstorming)

* GET /schedules/streets/1/sweeping/1
* GET /reminders/email/triggers
* GET /schedules/streets/plowing
* GET /schedules/streets/closing
* GET /schedules/school/high/2014/football
* GET /schedules/reccenters/yoga

## Other potential schedules (more brainstorming)

* District based routes
* Community based routes
* Denver Days, things that improve community
* Neighborhood meetings
* Trash pickup
* Large item pickup
* Overflow pickup
* Recycling pickup
* Composting
* Street closing
  * Sewer fixing
  * Special events, marathon
  * Construction
* Police/Crime meetings
* Public Hearings

## Questions

* What if two cities (think small towns) wanted to share an API implementation?
* Can you change POST /reminders from reminding only once to be a subscription without breaking the API?
* What are the time constraints on an API? Is a new version per year too much?

## Actions

* Only allow streetsweep.co to POST reminders
