DROP TABLE PolRouteDS_crime;
DROP TABLE PolRouteDS_segment;
DROP TABLE PolRouteDS_time;
DROP TABLE PolRouteDS_vertice;
DROP TABLE PolRouteDS_neighborhood;
DROP TABLE PolRouteDS_district;

CREATE TABLE PolRouteDS_district
(
    id integer,
    name varchar2(128),
    geometry CLOB   ,
    CONSTRAINT PolRouteDS_district_pk PRIMARY KEY (id)
);

CREATE TABLE PolRouteDS_neighborhood
(
    id integer,
    name varchar2(128),
    geometry CLOB,
    CONSTRAINT PolRouteDS_neighborhood_pk PRIMARY KEY (id)
);

CREATE TABLE PolRouteDS_vertice
(
    id integer,
    label integer,
    district_id integer,
    neighborhood_id integer,
    zone_id integer,
    CONSTRAINT PolRouteDS_vertice_pk PRIMARY KEY (id),
    CONSTRAINT PolRouteDS_vertice_PolRouteDS_district_fk 
        FOREIGN KEY (district_id) REFERENCES PolRouteDS_district(id),
    CONSTRAINT PolRouteDS_vertice_PolRouteDS_neighborhood_fk 
        FOREIGN KEY (neighborhood_id) REFERENCES PolRouteDS_neighborhood(id)
);

CREATE TABLE PolRouteDS_time
(
    id integer,
    period varchar2(128),
    day integer,
    month integer,
    year integer,
    weekday varchar2(128),
    CONSTRAINT PolRouteDS_time_pk PRIMARY KEY (id)
);

CREATE TABLE PolRouteDS_segment
(
    id integer,
    geometry CLOB,
    oneway varchar2(128),
    length float,
    final_vertice_id integer,
    start_vertice_id integer,
    CONSTRAINT PolRouteDS_segment_pk PRIMARY KEY (id),
    CONSTRAINT PolRouteDS_segment_PolRouteDS_vertice_final_fk 
        FOREIGN KEY (final_vertice_id) REFERENCES PolRouteDS_vertice(id),
    CONSTRAINT PolRouteDS_segment_PolRouteDS_vertice_start_fk 
        FOREIGN KEY (start_vertice_id) REFERENCES PolRouteDS_vertice(id)
);

CREATE TABLE PolRouteDS_crime
(
    id integer,
    total_feminicide integer,
    total_homicide integer,
    total_felony_murder integer, 
    total_bodily_harm integer,
    total_theft_cellphone integer,
    total_armed_robbery_cellphone integer,
    total_theft_auto integer,
    total_armed_robbery_auto integer,
    segment_id integer, 
    time_id integer,
    CONSTRAINT PolRouteDS_crime_pk PRIMARY KEY (id),
    CONSTRAINT PolRouteDS_crime_PolRouteDS_segment_fk 
        FOREIGN KEY (segment_id) REFERENCES PolRouteDS_segment(id),
    CONSTRAINT PolRouteDS_crime_PolRouteDS_time_fk 
        FOREIGN KEY (time_id) REFERENCES PolRouteDS_time(id)
);