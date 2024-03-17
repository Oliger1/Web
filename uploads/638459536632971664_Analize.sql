SELECT t1.Father AS GrandFather, t2.Son AS GrandSon
FROM Family t1 join family t2 ON t1.son = t2.father


