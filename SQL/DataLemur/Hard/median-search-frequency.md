<img width="672" alt="image" src="https://github.com/htta17/leetcode/assets/12803690/9c9d20a4-2d54-4f82-b7f0-9252fbc8a1c4">
<img width="666" alt="image" src="https://github.com/htta17/leetcode/assets/12803690/d22e57ec-e095-4989-8e36-eb99b7d3b899">

## Solution

```sql
WITH cte AS (
    SELECT *,
    SUM(num_users) OVER(ORDER BY searches) as running_sum,
    SUM(num_users) OVER() as usersum,
    LAG(searches) OVER(ORDER BY searches) as prev_searches
    FROM search_frequency
)

SELECT 
    CASE
        WHEN COUNT(*) = 1 THEN max(searches)
        ELSE ROUND((max(searches) + max(prev_searches)) * 1.0 / 2, 1)
    END as median_searches
FROM cte
WHERE usersum / 2.0 BETWEEN (running_sum - num_users) AND running_sum;
```

<img width="680" alt="image" src="https://github.com/htta17/leetcode/assets/12803690/869371ce-e319-4819-aa92-adf5cd094b96">
<img width="664" alt="image" src="https://github.com/htta17/leetcode/assets/12803690/b1044e36-97db-4d12-b681-de3b48ea4bf1">
<img width="677" alt="image" src="https://github.com/htta17/leetcode/assets/12803690/0e3ef83c-1bda-41fe-a5bd-b9c368edcbe3">




