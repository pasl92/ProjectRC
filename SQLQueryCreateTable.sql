create table klienci(
id_klienci int primary key,
imie varchar (30),
nazwisko varchar (30),
nr_tel int
);

create table produkty(
id_produktu int primary key,
cena money,
koszt_zakup money,
nazwa varchar (40),
);

create table zamowienia(
id_zamowienia int primary key,
id_produktu int foreign key references produkty(id_produktu),
id_klienta int foreign key references klienci(id_klienci),
rabat decimal(2,2),
data_zakupu datetime,
);

create table dostawa(
id_dostawa int primary key,
nazwa varchar (40),
cena money,
);
