#!/bin/bash

CONTAINER=pg-container
DB_USER=postgres
DB_NAME=autoAtbDb
BACKUP_DIR=/data/atb/backups
TIMESTAMP=$(date +"%Y%m%d_%H%M%S")
FILENAME="${BACKUP_DIR}/${DB_NAME}_${TIMESTAMP}.sql.gz"

mkdir -p $BACKUP_DIR

docker exec $CONTAINER pg_dump -U $DB_USER $DB_NAME | gzip > $FILENAME

find $BACKUP_DIR -type f -name "*.sql.gz" -mtime +7 -delete
