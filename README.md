# iTunes Search Coding Challenge

## Scenario: 
The average response times for a system have been steadily increasing. The flow of the system is thus:

1. The user clicks on an ad
2. The user is redirected to a web handler with the id of the ad in the query string
3. The web handler checks to make sure the ad id is in the query string then looks up the destination url form the database
4. The click is recorded in the database with the ad id, the user’s ip, useragent and timestamp
5. The user is redirected to the destination page

* Why do you think the system’s response time is slowing down? (Identify the bottlenecks of the system)


> **There could be many reasons why it is slowing down, ranging from server load to poor design, or even a lack of caching where necessary. Since response times have been steadily increasing, it's likely a combination of harware and things like caching results and DB components. Depending on how this is being used and implemented, it could be better to handle the tracking asynchronously, behind the scenes with JavaScript, for example, too.** 


* Which of the bottlenecks would you address first? Why?


> **If the issue is simply an overloaded server, the easy fix may be just throwing more hardware at it (but fundamentally that is only a temporary fix). Caching should be a pretty easy hit as well, depending on what is already in place for the database and such. It would be a lot more work to implement a new system of managing tracking, of course, but that would be an ideal option.**


* What would you do to address these bottlenecks?

> **It's always a good idea to determine if the server/infrastructure is simply working too hard, and an easy place to start. Next I would look at how caching is implemented and make changes as available. As resources are available, I would implement a new tracking system as described above.**

## Demonstration:
This is a chance to show off some of your development and UX skills.

* Please build an app (either a mobile optimized C# MVC web application or native iOS app) that allows a user to search iTunes. After searching, display the results and allow a user to click to the corresponding iTunes page. You can search iTunes by using the iTunes Search API
here: [https://affiliate.itunes.apple.com/resources/documentation/itunes-store-web-service-search-api/](https://affiliate.itunes.apple.com/resources/documentation/itunes-store-web-service-search-api/)

* Please include a server side component that tracks how many clicks per result are made within the app and a create a view that displays the count of clicks

* When the user clicks on a search result, the app should redirect to the album/video/app in the itunes store

* If creating an app, the client does not need to be in the app store, but we should be able to install the client and test on one of our test devices, e.g. by installing the apk directly, through a program like test flight, etc.


## Final Thoughts:
My implementation of this challenge went through a few variations before landing here. The data that is returned with each request can vary depending on the media type, and ideally I would have preferred to implement separate views for each so as to include things like album artwork or app screenshots where relevant. This would have added some additional complexity to the tracking as well, as I would have preferred to make every item both linkable and trackable. 

The search results ended up fairly basic in order to provide a decent crossover of data between media types. The tracking implemented was equally simplified for consistency sake, but essentially provides a JQuery event handler that detects when a link in the results is clicked. Each link has a unique ID attached that contains relevant data for tracking, and is retrieved accordingly. I also tracked the text value of that link primarily for reporting purposes, but there are many other ways this could have been represented in a larger-scale tracking project. 

The database design for this doesn't have any major complexity because the data is fairly basic, but ideally it could include many relationships for the data types being tracked, as well as additional user data like user agent and IP address. 
