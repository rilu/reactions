reactions
=========
Scriptcs script that downloads all posts from DevOps Reactions (http://devopsreactions.tumblr.com), puts the posts in a nice reveal.js (http://lab.hakim.se/reveal-js) presentation and finally self hosts it with Nancy (http://nancyfx.org).


Howto
-----
Needs a windows box (until mono support comes along for scriptcs):

install Chocolatey from  ```http://chocolatey.org/``` if you don't have it already.

run ```cinst git``` if you don't have git

run ```cinst scriptcs``` if you don't have scriptcs

run ```git clone https://github.com/rilu/reactions.git``` to some nice place on your harddrive

run ```cd [the place on your harddrive where the repository you just cloned resides]```

run ```scriptcs -install``` downloads the nuget packages

run ```scriptcs download.csx``` to download/update all posts from devopsreacations

run ```scriptcs start.csx``` as administrator

type  ```localhost:1337``` in your browser

enjoy!
