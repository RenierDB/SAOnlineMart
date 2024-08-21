DELETE FROM account;

INSERT INTO account (account_name, account_email, account_password) VALUES 
('Renier de Bruin', 'rdbemail@gmail.com', 'rdb101$#'),
('User 2', 'user2@gmail.com', 'user2$#'),
('User 3', 'user3@gmail.com', 'user3$#');

SELECT * FROM account WHERE account_email = 'rdbemail@gmail.com' AND account_password = 'rdb101$#'