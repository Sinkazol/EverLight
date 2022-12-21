A Mindig Fényes kft köztéri lámpák szervizelését végzi. Jelentősen növekvő bevételüknek köszönhetően
 sikerült beszerezniük egy számítógépet, amit webszerverként szeretnének üzemeltetni, ezen keresztül 
várják a meghibásodások bejelentését, de ezt a gépet használják a kollégák nap elején az elvégzendő 
munkák lekérdezéséhez illetve a titkárnő a havi statisztikákat is itt készíti majd el.
Web modul 
A közvilágítással kapcsolatos problémát regisztráció nélkül bárki jelezhet egy egyszerű webes űrlap kitöltésével.
Ehhez elegendő egy címet megadnia. Elküldése után a számítógépen található adatbázisban rögzítésre kerül a beérkezett cím, 
és a beérkezés időpontja (ez utóbbit a rendszer automatikusan generálja). A beküldő visszajelzést kap a sikeres bejelentésről.

Console1 modul
Munkakezdéskor a szervízes kollégák egy egyszerű szöveges felületen keresztül tudják lekérdezni a 
még el nem végzett munkák listáját. A munkalista vagy irányítószámok alapján, vagy budapesti cím esetén
 kerület szerint válogatva is elérhető. (Pl. ha a munkás a 3333-as irányítószámot adja meg, akkor Terpes 
településről érkezett hibák listáját kapja, ha viszont 106-ot ad meg lekérdezésként, akkor az összes VI. 
kerületi hiba megjelenik: 1061, 1062, 1063... )Ha a lekérdezéshez 100 alatti értéket írunk, akkor pedig 
azoknak a feladatoknak listáját kapjuk, amik az adott értéknél régebben kerültek be az adatbázisba. 
(Pl. a 66 beírása esetén a mai dátumhoz képest 67, 68, 69... nappal korábban érkezett hibák listája jelenik meg.)

Console2 modul
A nap végén a munka lezárásakor ki kell választani az elvégzet javítás típusát (izzócsere, lámpabúra, vezeték javítás...) 
A javítás dátuma automatikusan rögzül. Ekkor kell tárolni a munkát végző kolléga azonosítóját is.

UI modul
Az adatok feldolgozásáért felelős munkatárs az alábbi lekérdezéseket tudja elvégezni grafikus felületen:
-Egy munkatárs által elvégzett munkák listája
-Egy adott hónapban elvégzett összes munka
-Feladatok típusa szerint csoportosított lista
A megjelenített adatokat ki lehet exportálni egy külön fájlba is.
