BEGIN;


CREATE TABLE IF NOT EXISTS public."Airport"
(
    "Id" serial NOT NULL,
    "Code" character varying(8) NOT NULL,
    "Name" text NOT NULL,
    PRIMARY KEY ("Id"),
    CONSTRAINT "UX__Code" UNIQUE ("Code")
);

CREATE TABLE IF NOT EXISTS public."Carrier"
(
    "Id" serial NOT NULL,
    "Name" text NOT NULL,
    PRIMARY KEY ("Id"),
    CONSTRAINT "UX__Name" UNIQUE ("Name")
);

CREATE TABLE IF NOT EXISTS public."Airport_Carrier"
(
    "Airport_Id" integer NOT NULL,
    "Carrier_Id" integer NOT NULL,
    PRIMARY KEY ("Airport_Id", "Carrier_Id")
);

CREATE TABLE IF NOT EXISTS public."Flight"
(
    "Id" serial NOT NULL,
    "Cancelled" integer NOT NULL,
    "Delayed" integer NOT NULL,
    "Diverted" integer NOT NULL,
    "OnTime" integer NOT NULL,
    "Total" integer NOT NULL,
    "AirportId" integer NOT NULL,
    PRIMARY KEY ("Id")
);

ALTER TABLE IF EXISTS public."Airport_Carrier"
    ADD FOREIGN KEY ("Airport_Id")
    REFERENCES public."Airport" ("Id") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS public."Airport_Carrier"
    ADD FOREIGN KEY ("Carrier_Id")
    REFERENCES public."Carrier" ("Id") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS public."Flight"
    ADD CONSTRAINT "FK__AirportId_Airport" FOREIGN KEY ("AirportId")
    REFERENCES public."Airport" ("Id") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;

END;