-- 10. feladat:
CREATE DATABASE gitarmuveszek DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci

-- 12. feladat:
DELETE FROM stilus WHERE stilusNev = "swing"

-- 13. feladat:
SELECT COUNT(id) AS "Darab" FROM zenekar;

-- 14. feladat:
SELECT DISTINCT muvesz.nemzetiseg FROM muvesz WHERE muvesz.nemzetiseg IS NOT NULL ORDER BY muvesz.nemzetiseg ASC;

-- 15. feladat:
SELECT stilus.stilusNev AS 'stilus', COUNT(muvesz.id) AS 'muveszekSzama' FROM muvesz INNER JOIN stilus ON muvesz.stilusID=stilus.id GROUP BY stilus.stilusNev ORDER BY muveszekSzama DESC;

-- 16. feladat:
SELECT zenekar.zenekarNev, muvesz.muveszNev FROM muvesz INNER JOIN kapcsolo ON muvesz.id=kapcsolo.muveszID INNER JOIN zenekar ON zenekar.id=kapcsolo.zenekarID WHERE zenekar.zenekarNev LIKE "% % %" ORDER BY zenekar.zenekarNev;
