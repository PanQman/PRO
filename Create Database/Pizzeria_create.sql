-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2019-12-22 13:16:21.502

-- tables
-- Table: User
CREATE TABLE "User" (
    id int  NOT NULL,
    id_uprawnien int  NOT NULL,
    CONSTRAINT User_pk PRIMARY KEY  (id)
);

-- Table: dodatek
CREATE TABLE dodatek (
    id int  NOT NULL,
    nazwa_dodatku varchar(255)  NOT NULL,
    CONSTRAINT dodatek_pk PRIMARY KEY  (id)
);

-- Table: dostawa
CREATE TABLE dostawa (
    id int  NOT NULL,
    adres varchar(255)  NOT NULL,
    cena_dostawy money  NOT NULL,
    czas_dostawy date  NOT NULL,
    miejsce_dostawcy varchar(255)  NOT NULL,
    CONSTRAINT dostawa_pk PRIMARY KEY  (id)
);

-- Table: klient
CREATE TABLE klient (
    id int  NOT NULL,
    czyStudent bit  NOT NULL,
    czyRodzina bit  NOT NULL,
    CONSTRAINT klient_pk PRIMARY KEY  (id)
);

-- Table: pizza
CREATE TABLE pizza (
    id int  NOT NULL,
    nazwa_pizzy varchar(255)  NOT NULL,
    skladnik_id int  NOT NULL,
    sos_id int  NOT NULL,
    cena_pizzy money  NOT NULL,
    CONSTRAINT pizza_pk PRIMARY KEY  (id)
);

-- Table: platnosc
CREATE TABLE platnosc (
    id int  NOT NULL,
    czyKarta bit  NOT NULL,
    czyGotowka bit  NOT NULL,
    CONSTRAINT platnosc_pk PRIMARY KEY  (id)
);

-- Table: promocja
CREATE TABLE promocja (
    id int  NOT NULL,
    nazwa_promocji varchar(255)  NOT NULL,
    wartosc_promocji float(255)  NOT NULL,
    CONSTRAINT promocja_pk PRIMARY KEY  (id)
);

-- Table: skladnik
CREATE TABLE skladnik (
    id int  NOT NULL,
    nazwa_skladnika varchar(255)  NOT NULL,
    CONSTRAINT skladnik_pk PRIMARY KEY  (id)
);

-- Table: sos
CREATE TABLE sos (
    id int  NOT NULL,
    nazwa_sosu varchar(255)  NOT NULL,
    CONSTRAINT sos_pk PRIMARY KEY  (id)
);

-- Table: uprawnienia
CREATE TABLE uprawnienia (
    id int  NOT NULL,
    uprawnienia varchar(255)  NOT NULL,
    CONSTRAINT uprawnienia_pk PRIMARY KEY  (id)
);

-- Table: zamowienie
CREATE TABLE zamowienie (
    id int  NOT NULL,
    nazwa varchar(255)  NOT NULL,
    dodatek_id int  NOT NULL,
    promocja_id int  NOT NULL,
    klient_id int  NOT NULL,
    dostawa_id int  NOT NULL,
    pizza_id int  NOT NULL,
    platnosc_id int  NOT NULL,
    cena_zamowienia money  NOT NULL,
    CONSTRAINT zamowienie_pk PRIMARY KEY  (id)
);

-- foreign keys
-- Reference: pizza_sos (table: pizza)
ALTER TABLE pizza ADD CONSTRAINT pizza_sos
    FOREIGN KEY (sos_id)
    REFERENCES sos (id);

-- Reference: skladnik_pizza (table: pizza)
ALTER TABLE pizza ADD CONSTRAINT skladnik_pizza
    FOREIGN KEY (skladnik_id)
    REFERENCES skladnik (id);

-- Reference: uprawnienia_User (table: User)
ALTER TABLE "User" ADD CONSTRAINT uprawnienia_User
    FOREIGN KEY (id_uprawnien)
    REFERENCES uprawnienia (id);

-- Reference: zamowienie_dodatek (table: zamowienie)
ALTER TABLE zamowienie ADD CONSTRAINT zamowienie_dodatek
    FOREIGN KEY (dodatek_id)
    REFERENCES dodatek (id);

-- Reference: zamowienie_dostawa (table: zamowienie)
ALTER TABLE zamowienie ADD CONSTRAINT zamowienie_dostawa
    FOREIGN KEY (dostawa_id)
    REFERENCES dostawa (id);

-- Reference: zamowienie_klient (table: zamowienie)
ALTER TABLE zamowienie ADD CONSTRAINT zamowienie_klient
    FOREIGN KEY (klient_id)
    REFERENCES klient (id);

-- Reference: zamowienie_pizza (table: zamowienie)
ALTER TABLE zamowienie ADD CONSTRAINT zamowienie_pizza
    FOREIGN KEY (pizza_id)
    REFERENCES pizza (id);

-- Reference: zamowienie_platnosc (table: zamowienie)
ALTER TABLE zamowienie ADD CONSTRAINT zamowienie_platnosc
    FOREIGN KEY (platnosc_id)
    REFERENCES platnosc (id);

-- Reference: zamowienie_promocja (table: zamowienie)
ALTER TABLE zamowienie ADD CONSTRAINT zamowienie_promocja
    FOREIGN KEY (promocja_id)
    REFERENCES promocja (id);

-- End of file.

