CREATE TABLE MacAutos {
    id int NOT NULL AUTO_INCREMENT,
    title VARCHAR(255),
    make VARCHAR(255),
    model VARCHAR(255),
    descript VARCHAR(255),
    contact VARCHAR(255),
    img VARCHAR(255),
    price DECIMAL(40, 2),
    PRIMARY KEY(id)
}