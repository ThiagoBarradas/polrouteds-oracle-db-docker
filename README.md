## Getting Started

- 1: Clone this repo
- 2: Download and unzip the follow file:
  - https://drive.google.com/file/d/1xySvkzljUMJGVDaTw1Y6fXZnXu9ngzgV/view?usp=sharing
- 3: Put dirs `data` and `csv` into the cloned project.
- 4: Run Oracle DB with this command and wait a few moments to initialize. 
   - `docker-compose up -d`
- 5: Open shell to execute queries:
   - `docker exec -it --user=oracle oracle-partitions sqlplus MYUSER/PASSPASS@localhost`

### Oracle SQL Developer 

You can use official Oracle SQL Developer tool (native or vscode extension). Please, see the follow link to download and install:
- https://www.oracle.com/database/sqldeveloper/technologies/download/

- authentication type: `Default`
- role: `Default`
- user: `MYUSER`
- pass: `PASSPASS`
- host: `localhost`
- port: `1521`
- connection type: `Basic`
- type: `SID`
- sid: `xe`

### Initializing Database Schema and Importing Data

Don't worry. All data are already imported and you only need to run previous command. If you want to import again or understand the used code, you can.

Exists a dotnet project to import data. You can found in ./importer, but it has no docker configuration yet. With oracle-partitions running, you need to execute the follow command and wait some minutes (maybe hours).

`docker exec -it --user=oracle oracle-partitions bash /tmp/scripts/setup.sh`

## Database Tables

- `PolRouteDS_crime`
- `PolRouteDS_segment`
- `PolRouteDS_time`
- `PolRouteDS_vertice`
- `PolRouteDS_neighborhood`
- `PolRouteDS_district`

## Datasource - PolRouteDS CSV

Dataset with São Paulo state crime map called PolRoute-DS (https://doi.org/10.5753/jidm.2022.2355). 

PolRoute-DS can be downloaded in: https://osf.io/mxrgu/. 

#### Files
- *crime.csv* (262,9 MB): Contains crimes total by type, segment, and date/hour. _segment_id_ reffers to the city segment and _time_id_ to the moment that the crime happens. 
- *segment.csv* (45,7 MB): Contains street segments from a city. Each row has an initial vertex, final vertex, flag indicating if the street is one-way or two-way and a size.
- *vertice.csv* (3,9 MB): Contains graph vertex from a city. Each vertex has a district, neighborhood and zone.
- *district.csv* (5 MB): Contains the districts from a city, its name and its spacial geometry.
- *neighborhood.csv* (2 MB): Contains the neighborhoods from a city, its name and its spacial geometry.
- *time.csv* (850 KB): Contains the moments considered for final criminal analysis.

