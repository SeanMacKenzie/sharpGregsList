CREATE TABLE macproperties (
    id int NOT NULL AUTO_INCREMENT,
    title VARCHAR(255),
    type VARCHAR(255),
    descript VARCHAR(255),
    size int,
    contact VARCHAR(255),
    img VARCHAR(255),
    price DECIMAL(40, 2),
    PRIMARY KEY(id)
)

