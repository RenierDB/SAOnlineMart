DELETE FROM product;

INSERT INTO product (product_name, product_desc, product_price) VALUES 
('Product 1', 'this is a desc', 10),
('Product 2', 'this is a desc', 20),
('Product 3', 'this is a desc', 30),
('Product 4', 'this is a desc', 40),
('Product 5', 'this is a desc', 50);

SELECT product_id, product_name, product_desc, product_price FROM product