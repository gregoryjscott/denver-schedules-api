# API

## Current

* POST /reminders
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

## Other ideas

* GET /schedules/streets/1/sweeping/1
* GET /reminders/email/triggers
* GET /schedules/streets/plowing
* GET /schedules/streets/closing
* GET /schedules/school/high/2014/football
* GET /schedules/reccenters/yoga


## Random schedule things

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

## Actions

* Only allow streetsweep.co to POST reminders
