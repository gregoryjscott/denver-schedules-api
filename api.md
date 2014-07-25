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
* POST /reminders/email/send
* POST /reminders/sms/send
* POST /reminders/yo/send
* GET /schedules/streets/sweeping
* GET /schedules/holidays
* GET /status
* Other possibilities
  * GET /reminders/email/send (you want to know when sends have happened)
  * GET /reminders/email (one per user, would have reminder and email attributes)
  * GET /notifications/email (one per notification, would have notification attributes and email attributes that match /reminders/email)
  * DELETE /reminders/email (POST data would have to contain sms # and physical address)

## Other potential routes (brainstorming)

* GET /schedules/streets/1/sweeping/1
* GET /reminders/email/trigger
* GET /schedules/streets/plowing
* GET /schedules/streets/closing
* GET /schedules/school/high/football (no need for historical - can't remind for past events)
* GET /schedules/reccenters/yoga

## Other potential schedules (more brainstorming)

>Going with all singular resources in these examples as an experiment.

* District/Community based routes
  * Every department divides up cities into different regions
  * GET /district/23/schedule/reminder
  * GET /community/capital-hill/reminder
  * you could allow any GET route to contain the district or community prefix
* Denver Days, things that improve community
* Neighborhood meetings
  * GET /neighborhood/hillside/meeting
* Trash pickup
  * GET /schedule/pickup/trash
* Large item pickup
* Overflow pickup
* Recycling pickup
  * GET /schedule/pickup/recyling
* Composting
  * GET /schedule/pickup/compost
* Street closing (are these just attributes of a "closing" resource? Maybe it is associated to another event/schedule)
  * E.g.
    * Sewer fixing
    * Special events, marathon
    * Construction
    * /schedule/repair/
* Outages (could have used this API endpoint recently...)
  * /schedule/outage/sewer
  * /schedule/outage/water
  * AND/OR
  * /schedule/water/status
  * /schedule/sewer/status
  * /schedule/power/status
* Police/Crime meetings
* Public Hearings
  * /schedule/hearing ("public" can just be a query parameter/attribute)

## Questions

* What if two cities (think small towns) wanted to share an API implementation?
* Can you change POST /reminders from reminding only once to be a subscription without breaking the API?
* What are the time constraints on an API? Is a new version per year too much?

## Actions

* Only allow streetsweep.co to POST reminders
