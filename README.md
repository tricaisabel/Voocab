# Voocab
This is an application with the main purpose of managing words (basically a digital dictionary) where the definitions of the words are added by the users.
Words can receive likes and new words and meanings can be added by the user.

## Pages and Features ##
All of the values that are intoduced by the user are validated using an Error Provider

### The Welcome Page ###
<img width="321" alt="1" src="https://user-images.githubusercontent.com/72613613/127297076-638ccf38-9b2a-40de-9a7d-d157cdac1b24.PNG">

* user name input
* if the usernamed has been intoduced before the welcoming message is "Welcome Back"
* if the username is new the message is just "Welcome"
    
### The Main Page (Form 1) ###
<img width="880" alt="5" src="https://user-images.githubusercontent.com/72613613/127297212-d9070894-4130-4eea-8ed6-aa1fdeebd25a.PNG">

* a bar where you can search words
* number of searches for each word is auto-incremented after one search
* after every press of any key suggested results are shown
* the words and likes are displayed directly from a local SQLite database using a DataGridView

<img width="327" alt="3" src="https://user-images.githubusercontent.com/72613613/127297337-805e0823-298b-4cf2-a22b-26f37973874a.PNG">

* you can add new words using a secondary form (Form 2)
* changes made to the words are automatically updated in the database
* you can like one of the definitions of one word
* multiple definitions of one word are ordered by the number of likes
* the word-explination component is a user-defined control
* the menu allows the user to:
    * export the words in text and xml format
    * open the Analytics Page (Vizualizare Date)

### The Analytics Page (Form 3) ###
<img width="883" alt="7" src="https://user-images.githubusercontent.com/72613613/127297378-1d2e8a5e-f6b7-49f9-a458-f63fb4d50053.PNG">

* displays a pie chart the shows the ratio between words with/without explanations
* displays a scatter-plot the shows the relation between the number of likes and the number of searches for each word
* the scatter-plot is made from scratch using the Graphics class and geometry formulas in relation with the values of the input variables
* both figures update at every click of the Analytics Page
<img width="905" alt="8" src="https://user-images.githubusercontent.com/72613613/127297407-a2d35285-cac3-428d-b7e2-4478ecf14055.PNG">

* you can drag and drop one of the figures to the Print Area and you can Print Preview them

## How to open ##
1. Download the whole project
2. Unzip it
3. Either open:
    * `Voocab->Voocab.sln in Visual Studio and Run`
    
    *` Voocab->obj->Debug->Voocab.exe`
3. Enjoy! 



                                


