DROP TABLE IF EXISTS order_product;
DROP TABLE IF EXISTS account;
DROP TABLE IF EXISTS product;
DROP TABLE IF EXISTS orders;

CREATE TABLE account (
	account_id INT IDENTITY(1,1),
	account_name VARCHAR(255),
	account_email VARCHAR(255),
	account_password VARCHAR(255),
	PRIMARY KEY (account_id)
);

CREATE TABLE product (
	product_id INT IDENTITY(1,1),
	product_name VARCHAR(255),
	product_desc VARCHAR(255),
	product_price DECIMAL(10,2),
	PRIMARY KEY (product_id)
);

CREATE TABLE orders (
	order_id INT IDENTITY(1,1),
	first_name varchar(255),
	last_name varchar(255),
	telephone varchar(14),
	order_date DATE,
	shipping_address varchar(255),
	post_code varchar(10),
	country varchar(255),
	PRIMARY KEY (order_id)
);	

CREATE TABLE order_product (
	order_id INT,
	product_id INT,
	quantity INT,
	PRIMARY KEY (order_id, product_id),
	FOREIGN KEY (order_id) REFERENCES orders(order_id),
	FOREIGN KEY (product_id) REFERENCES product(product_id)
);