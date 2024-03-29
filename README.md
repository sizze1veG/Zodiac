<h1 align="center">Нет названия</h1>

[<img src='https://cdn.jsdelivr.net/npm/simple-icons@3.0.1/icons/github.svg' alt='github' height='40'>](https://github.com/sizze1veG)  [<img src='https://cdn.jsdelivr.net/npm/simple-icons@3.0.1/icons/instagram.svg' alt='instagram' height='40'>](https://www.instagram.com/sizze1veG/)  [<img src='https://cdn.jsdelivr.net/npm/simple-icons@3.0.1/icons/icloud.svg' alt='website' height='40'>](https://vk.com/sizze1veg)  

<h2>Задание</h2>
Описать структуру, содержащую следующие поля:

- Фамилия, имя;
- номер телефона;
- день рождения (массив из трёх чисел);
- знак Зодиака.

Написать программу, которая выполняет следующие действия:
- вводит с клавиатуры данные в массив, состоящий из восьми элементов; записи должны быть упорядочены по датам дней рождения;
- выводит на экран информации о человеке, чья фамилия введена с клавиатуры;
- если такого нет, выдать на дисплей соответствующее сообщение;
- выводит на экран информации о людях, родившихся под знаком, наименование которого введено с клавиатуры.

<h2>Интерфейс</h2>

- Главное окно программы

<picture>
  <img src="https://github.com/sizze1veG/zodiac/blob/main/screenshots/Screenshot_1.png">
</picture>

На главном окне программы находится полный список людей из базы данных и 4 кнопки.

Чтобы добавить новые данные, нужно ввести в соответствующие строки имя,
номер телефона и дату рождения. Программа проверит правильность введённых данных. 
После она сама определяет знак зодиака и добавляет данные в таблицу и базу данных. 
Имя должно состоять только из букв и быть длиной от 6 до 40 символов. Также имя и фамилия не должны повторяться. 
Номер телефона должен состоять из 11 цифр. Дата дня рождения должна состоять из 10 символов, 
среди которых две точки, а остальные цифры. При этом дата рождения не может быть больше текущей даты, которая установлена на компьютере.

Для удаления данных нужно выбрать строку с данными, которые желаем удалить и нажать соответствующую кнопку.

- Поиск по имени

<picture>
  <img src="https://github.com/sizze1veG/zodiac/blob/main/screenshots/Screenshot_2.png">
</picture>

Чтобы узнать информацию о человеке по его имени, нужно ввести в соответствующую строку его имя и фамилию, 
затем нажать на кнопку «найти». Программа пройдется по списку всех людей, которые есть в базе данных, если она найдёт совпадение, 
то откроется окно в котором будут написаны сведения об этом человеке. Если совпадение не будет найдено, то программа сообщит о том, 
что такого человека нет.

- Поиск по знаку зодиака

<picture>
  <img src="https://github.com/sizze1veG/zodiac/blob/main/screenshots/Screenshot_3.png">
</picture>

Чтобы найти всех людей, которые имеют один и тот же знак зодиака, нужно ввести этот знак зодиака в поле ввода и нажать на кнопку «найти». 
Программа пройдется по списку и будет брать только тех людей, чей знак зодиака будет совпадать с введенным.
Затем программа поместит этих людей в таблицу на открывшемся окне.
