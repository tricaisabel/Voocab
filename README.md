# Voocab
This is an application with the main purpose of managing words (basically an online dictionary) where the definitions of the words are added by the users.
Words can receive likes and new words and meanings can be added by the user.

# Pages and Features
The Welcome Page
-user name input
    
The Main Page (Form 1)
-a bar where you can search words
-number of searches for each word is auto-incremented after one search
    -after every press of any key suggested results are shown
    -the words and likes are displayed directly from a local SQLite database using a DataGridView
    -you can add new words using a secondary form (Form 2)
    -changes made to the words are automatically updated in the database
    -you can like one of the definitions of one word
    -multiple definitions of one word are ordered by the number of likes
    -the word-explination component is a user-defined control
    -the menu allows the user to: export the words in text and xml format
                                : open the Analytics Page (Vizualizare Date)

The Analytics Page (Form 3)
    -displays a pie chart the shows the ratio between words with/without explanations
    -displays a scatter-plot the shows the relation between the number of likes and the number of searches for each word
    -the scatter-plot is made from scratch using the Graphics class and geometry formulas in relation with the values of the input variables
    -both figures update at every click of the Analytics Page
    -you can drag and drop one of the figures to the Print Area and you can Print Preview them
                                


