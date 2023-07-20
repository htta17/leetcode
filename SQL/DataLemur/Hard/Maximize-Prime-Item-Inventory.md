<img width="722" alt="image" src="https://github.com/htta17/leetcode/assets/12803690/d2001942-e30d-48d2-a0cf-b89f3bd8260a">
<img width="488" alt="image" src="https://github.com/htta17/leetcode/assets/12803690/d82527a5-4a39-4d59-878f-d1cd74950b5f">
<img width="279" alt="image" src="https://github.com/htta17/leetcode/assets/12803690/6d4accd6-bd59-4347-95f1-df480b6429a5">
<img width="727" alt="image" src="https://github.com/htta17/leetcode/assets/12803690/0f086d91-6822-4f16-b772-f952d74743e5">
<img width="718" alt="image" src="https://github.com/htta17/leetcode/assets/12803690/4e8dcd64-d637-4f0f-9e3d-b2880f857f2a">
<img width="710" alt="image" src="https://github.com/htta17/leetcode/assets/12803690/e57bef2c-a3b6-45b2-8d3d-38941762a476">
<img width="731" alt="image" src="https://github.com/htta17/leetcode/assets/12803690/425abc55-1b63-42e0-a59d-536582f3aa9f">

```sql
WITH summary AS (  
  SELECT  
    item_type,  
    SUM(square_footage) AS total_sqft,  
    COUNT(*) AS item_count  
  FROM inventory  
  GROUP BY item_type
),
prime_occupied_area AS (  
  SELECT  
    item_type,
    total_sqft,
    FLOOR(500000/total_sqft) AS prime_item_combination_count,
    (FLOOR(500000/total_sqft) * item_count) AS prime_item_count
  FROM summary  
  WHERE item_type = 'prime_eligible'
)

SELECT
  item_type,
  CASE 
    WHEN item_type = 'prime_eligible' 
      THEN (FLOOR(500000/total_sqft) * item_count)
    WHEN item_type = 'not_prime' 
      THEN FLOOR((500000 - 
        (SELECT FLOOR(500000/total_sqft) * total_sqft FROM prime_occupied_area))  
        / total_sqft)  
        * item_count
  END AS item_count
FROM summary
ORDER BY item_type DESC;
```
<img width="253" alt="image" src="https://github.com/htta17/leetcode/assets/12803690/cf4050d0-b15c-44ab-8f1f-bbbb3dfb14e9">

# Method #2: Using FILTER and UNION ALL operator

```sql
WITH summary AS (
SELECT 
  SUM(square_footage) FILTER (WHERE item_type = 'prime_eligible') AS prime_sq_ft,
  COUNT(item_id) FILTER (WHERE item_type = 'prime_eligible') AS prime_item_count,
  SUM(square_footage) FILTER (WHERE item_type = 'not_prime') AS not_prime_sq_ft,
  COUNT(item_id) FILTER (WHERE item_type = 'not_prime') AS not_prime_item_count
FROM inventory
),
prime_occupied_area AS (
SELECT
  FLOOR(500000/prime_sq_ft)*prime_sq_ft AS max_prime_area
FROM summary
)

SELECT 
  'prime_eligible' AS item_type,
  FLOOR(500000/prime_sq_ft)*prime_item_count AS item_count
FROM summary

UNION ALL

SELECT 
  'not_prime' AS item_type,
  FLOOR((500000-(SELECT max_prime_area FROM prime_occupied_area)) 
    / not_prime_sq_ft) * not_prime_item_count AS item_count
FROM summary;
```


