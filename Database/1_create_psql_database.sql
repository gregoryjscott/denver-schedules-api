--drop database denver_schedules_development;
--drop user denver_schedules

-- Create User
create user denver_schedules with password 'denver_schedules';

-- Database: denver_schedules_development
create database denver_schedules_development
       ENCODING = 'UTF8'
       TABLESPACE = pg_default
       LC_COLLATE = 'en_US.UTF-8'
       LC_CTYPE = 'en_US.UTF-8'
       CONNECTION LIMIT = -1;
grant connnect, temporary on database denver_schedules_development to public;

-- Grant Permissions
grant all on database denver_schedules_development to denver_schedules;

-- Add PostGIS extension
\c denver_schedules_development;
create extension postgis; 