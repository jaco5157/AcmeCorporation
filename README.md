# Acme Corporation

This homework was done for Umbraco. This document describes to test and run the solution using Docker.


## Testing
Before testing the solution, we need a database running on localhost
```
docker run -d \
  --name database-throwaway \
  -p 3306:3306 \
  -e MYSQL_ALLOW_EMPTY_PASSWORD=yes \
  mysql:8.0.28 \
  --default-authentication-plugin=mysql_native_password
```

Proceed to run the tests in the ``TestService`` project.

## Running
To run the solution with docker-compose, simply use
```
docker-compose up
```

The solution can now be accessed at:
```
http://localhost:51001/
```

## Serials
Serial numbers were generated using generated using [randomcodegenerator](https://www.randomcodegenerator.com/en/generate-serial-numbers). 

Following is the first 10 entries of ``serials.csv``, which is located in the root folder of this project
 - AC649733
 - AC663579
 - AC447486
 - AC546973
 - AC659722
 - AC363642
 - AC278374
 - AC934735
 - AC563426
 - AC846957