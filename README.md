# Курсовая работа по языку C#
* __Database__ - _MySQL_

Схема данных:


 ![alt text](https://github.com/Nanord/Ponchland/blob/master/image.png)

* Используемые аттерны:
  1. __Model-View-Controller (MVC, «Модель-Представление-Контроллер», «Модель-Вид-Контроллер»)__ — схема разделения данных приложения, пользовательского интерфейса и управляющей логики на три отдельных компонента: модель, представление и контроллер — таким образом, что модификация каждого компонента может осуществляться независимо. 
  ![alt text](https://2.downloader.disk.yandex.ru/disk/a7f5664e4480c1ed9204b546d3b63670fe8b8e612785848dc8e59aa9df06bb2f/5aba58ec/thWzUDf9_o8v107oSjX4fHr-cFteAmSybd67aw_cdKFeD1950U4kDKg1G3TZjVJh5WVP_ny2wPs1faP2DQJtAQ%3D%3D?uid=109501488&filename=Снимок3.PNG&disposition=inline&hash=&limit=0&content_type=image%2Fpng&fsize=113693&hid=bc443e6d42a66f07733810a119f26624&media_type=image&tknv=v2&etag=0ffb78a6f0275c166263ea3eedb48431)
  2. __Одиночка (Singleton, Синглтон)__ - порождающий паттерн, который гарантирует, что для определенного класса будет создан только один объект, а также предоставит к этому объекту точку доступа.
  3. __Шаблонный метод (Template Method)__ определяет общий алгоритм поведения подклассов, позволяя им переопределить отдельные шаги этого алгоритма без изменения его структуры.
  ![alt text](https://1.downloader.disk.yandex.ru/disk/4ec2f7d2f55acd0a300448977104ad94c0bc827025b95b75820cb61939ff9943/5aba5930/thWzUDf9_o8v107oSjX4fAYRBBKHge9LNpKP8--S_KqMMBQVuF1yYZNHHLv96s6O6SCwb_cplSS-L24tuv-j8g%3D%3D?uid=109501488&filename=Снимок2.PNG&disposition=inline&hash=&limit=0&content_type=image%2Fpng&fsize=31850&hid=112b6363a5d58e1637ba4551a3b23005&media_type=image&tknv=v2&etag=78123c09f4877ddb5c34043d3117c7f1)
  4. __Паттерн Стратегия (Strategy)__ представляет шаблон проектирования, который определяет набор алгоритмов, инкапсулирует каждый из них и обеспечивает их взаимозаменяемость. В зависимости от ситуации мы можем легко заменить один используемый алгоритм другим. При этом замена алгоритма происходит независимо от объекта, который использует данный алгоритм.
  ![alt txt](https://4.downloader.disk.yandex.ru/disk/5327cdd193828ff640dce58601295761e16deb76872232887f6bc7554119fd27/5aba5971/thWzUDf9_o8v107oSjX4fJqsOJnrVjl4tcG2p4VAEH-EF1smeU4cMVj8lysAzu5zafUjj50lVNclAplxtTUuYA%3D%3D?uid=109501488&filename=Снимок.PNG&disposition=inline&hash=&limit=0&content_type=image%2Fpng&fsize=56753&hid=8ce5d22fa748f074fd758b3748888614&media_type=image&tknv=v2&etag=6fa50d8e79acf8f1d7472fcf1c775060)
