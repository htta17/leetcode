![image](https://github.com/htta17/leetcode/assets/12803690/39ce173e-462c-49bf-965b-2ceb568fd13a)
![image](https://github.com/htta17/leetcode/assets/12803690/8c61fbe1-bfb1-42d2-b7fd-12eb4d8d5ebc)
```sql
SELECT user_id ,DATE_PART('day',MAX(post_date) - MIN(post_date)) AS days_between
FROM posts
WHERE DATE_PART('year', post_date) = 2021
GROUP BY user_id
HAVING COUNT(user_id)>1;
```
