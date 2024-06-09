#!/bin/bash

echo "### INITIALIZING ###"
exit | sqlplus -S SYSTEM/PASSPASS@localhost @/tmp/scripts/create_user.sql
exit | sqlplus -S MYUSER/PASSPASS@localhost @/tmp/scripts/create_database.sql

