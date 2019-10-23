SELECT S.Name 
FROM  Students AS S INNER JOIN Friends AS F on S.ID = F.ID
               INNER JOIN Packages AS P1 on S.ID = P1.ID
               INNER JOIN Packages AS P2 on F.Friend_ID = P2.ID  
WHERE 
    P1.Salary < P2.Salary
ORDER BY P2.Salary
