![image](https://github.com/htta17/leetcode/assets/12803690/1f9358e4-0320-4f6a-8915-253fd0399c56)
![image](https://github.com/htta17/leetcode/assets/12803690/1c270b3b-a790-4e9d-97be-71443a3a40eb)
![image](https://github.com/htta17/leetcode/assets/12803690/ed2ddd6b-5611-403c-a922-32fa75a6f939)
## Use row_number()
![image](https://github.com/htta17/leetcode/assets/12803690/44f4c226-3cc1-47af-8c57-27e27c6ddd1c)
## Use Subquery with HAVING
```SQL
SELECT COUNT(DISTINCT company_id) AS co_w_duplicate_job
FROM (
    SELECT company_id
    FROM job_listings
    GROUP BY company_id, title, description
    HAVING COUNT(job_id) > 1
) AS subquery
```
