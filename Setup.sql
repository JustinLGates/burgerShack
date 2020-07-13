USE burgerrepo;

-- MySql : MongoDb => Table : Collection

-- CREATE COLLECTION
-- CREATE TABLE combos
-- (
--     id INT AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL UNIQUE,
--     description VARCHAR(255),
--     price DECIMAL(6, 2) NOT NULL,

--     PRIMARY KEY (id)
-- );

-- GET ALL
-- SELECT * FROM burgers;

-- GET BY ID
-- SELECT * FROM burgers WHERE id = 2;

-- CREATE 
-- INSERT INTO burgers 
-- (name, price, description)
-- VALUES
-- ("Mark Deluxe", 8.98, "Only the freshest ... long pork");


-- EDIT 
-- UPDATE burgers
-- SET 
--     description = "Its extra Cheesy!!!",
--     price = 5.99
-- WHERE id = 4;

-- DELETE
-- DELETE FROM burgers WHERE id = 4;



-- DANGER ZONE
-- DELETE FROM burgers; -- DELETES ALL DATA IN TABLE
DROP TABLE fries; -- DESTROYS WHOLE TABLE
-- DROP DATABASE burgershack713; -- DESTROYS WHOLE DATABASE






-- CREATE TABLE combos
-- (
--     id INT NOT NULL AUTO_INCREMENT,
--     price DECIMAL(6, 2) DEFAULT 9.00,
--     burgerId INT NOT NULL,

--     PRIMARY KEY (id),

--     FOREIGN KEY (burgerId)
--         REFERENCES burgers (id)
--         ON DELETE CASCADE
-- );

-- INSERT INTO combos 
-- (price, burgerId) 
-- VALUES
-- (10.67, 3) 

-- SELECT * FROM combos
 -- JOIN 