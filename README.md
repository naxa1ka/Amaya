# AmayaSoftTest  
  
**Тестовое задание на Unity Developer в компанию AmayaSoft**  
  
## Геймплей  
  
Цель игры: выбрать правильный вариант ответа, соответствующий заданию.  
  
### Игровой процесс по шагам  
  
* В игре 3 уровня сложности  
  
1-й уровень - Легкий    
  
![image](https://user-images.githubusercontent.com/36508387/121701003-ab545e80-cafa-11eb-821a-1e480a60ecfe.png)    
  
2-й уровень - Средний  
  
![image](https://user-images.githubusercontent.com/36508387/121701161-d343c200-cafa-11eb-91f1-ff08634247dc.png)    
  
3-й уровень - Тяжелый  
  
![image](https://user-images.githubusercontent.com/36508387/121701236-e35ba180-cafa-11eb-8763-0c77a7e3bf45.png)    
  
* При запуске сцены:  
  
  1. Через bounce эффект появляются ячейки с объектами  
  2. Через **FadeIn** эффект появляется текст с заданием, выбрать правильный вариант ответа  
  
![BounceEffect](https://user-images.githubusercontent.com/36508387/121702540-2d915280-cafc-11eb-951d-19473d39e883.gif)  
  
* При тапе на неправильный ответ:  
  
  1. Объект внутри карточки дергается туда-сюда (easeInBounce)  
  
![easyInBounce](https://user-images.githubusercontent.com/36508387/121703540-261e7900-cafd-11eb-9290-1e358f186ada.gif)  
  
* При тапе на правильный ответ:  
  
  1. bounce объекта внутри карточки  
  2. Появляются партиклы звездочки  
  
![RightAnswer](https://user-images.githubusercontent.com/36508387/121706102-81ea0180-caff-11eb-82f9-cbd1baae7b54.gif)    
  
* При окончании всех уровней:  
  
  1. В центре экрана появляется кнопка **Restart**, нажав на нее можно начать игру заново с легкого уровня  
  2. Должно эффектом **FadeIn/FadeOut** появиться затемнение экрана, но она не должна перекрывать кнопку **Restart**  
  3. Все элементы в игре не должны быть кликабельны  
  
![GameEnd](https://user-images.githubusercontent.com/36508387/121707321-a2ff2200-cb00-11eb-8ca8-d63313e5178f.gif)    
  
* При нажатии кнопки **Restart**:    
  
  1. Должен через эффект **FadeIn/FadeOut** появиться загрузочный экран (черная текстура). Игровые объекты исчезают.
  2. Все должно начинаться с пункта /"При запуске сцены/"
  
![RestartGame](https://user-images.githubusercontent.com/36508387/121709008-4b61b600-cb02-11eb-9a4c-1bb4045f6cb8.gif)  
  
### Условия генерации данных    
  
* При смене уровня    
  
  1. Правильный ответ выбирается случайным образом. Он не повторяется в рамках сессии, где сессия - запущенный *Play Mode*  
  2. Эффект появления ячеек не происходит. Старые объекты в ячейках удаляются, появляются мгновенно новые. Новые ячейки тоже появляются мгновенно  
  3. Мгновенно меняется текст задания  
  4. При смене уровня может подставится один из двух видов визуализации данных (цифры или буквы). Цель задания меняется в зависимости от объектов. Данная конфигурация должна быть максимально простой и понятной, чтобы потом наборы данных можно было менять без участия разработчика  
  
* Во время генерации уровня учитывать, что правильный вариант овтета только один    
  
* В коде не должно быть разделения на букву/цифру. Механика должна работать с любыми объектами, вне зависимости от того что это. Код одинаковый для обоих случаев, различаются только наборы данных и визуальная составляющая    
  
* Префаб ячейки должен быть единственным в проекте  
  
* Gameplay не должен разделяться на разные сцены, все должно работать на одной сцене  
