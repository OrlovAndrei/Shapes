# Ответ на 3 вопрос

Между таблицами продукты и категории существует связь многие ко многим,
следовательно должна существовать промежуточная таблица, пусть она будет называться Product_Category.

Тогда запрос будет выглядеть как-то так:

```
SELECT Product.name AS product_name , Category.name AS category_name   
FROM Product 
LEFT JOIN Product_Category
ON Product.id = Product_Category.product 
LEFT JOIN Category
ON Product_Category.category = Category.id 
```
