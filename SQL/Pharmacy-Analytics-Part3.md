<img width="721" alt="image" src="https://github.com/htta17/leetcode/assets/12803690/bc2aa322-4147-4611-9697-99c9c79bbc65">
<img width="685" alt="image" src="https://github.com/htta17/leetcode/assets/12803690/6d2fa71a-6176-47d9-8390-8db604d33bf7">

** Solution 1
```SQL
SELECT 
  manufacturer, 
  CONCAT( '$', ROUND(SUM(total_sales) / 1000000), ' million') AS sales_mil 
FROM pharmacy_sales 
GROUP BY manufacturer 
ORDER BY SUM(total_sales) DESC;
```

** Solution 2
```SQL
WITH drug_sales AS (
  SELECT 
    manufacturer, 
    SUM(total_sales) as sales 
  FROM pharmacy_sales 
  GROUP BY manufacturer
) 

SELECT 
  manufacturer, 
  ('$' || ROUND(sales / 1000000) || ' million') AS sales_mil 
FROM drug_sales 
ORDER BY sales DESC;
```
