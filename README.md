# SportStoreCore
> Solution SportStoreCore contains two ASP.NET Core projects. They were created during learning ASP.NET Core from book Adam Freeman "Pro ASP.NET
Core MVC". 

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Features](#features)
* [Status](#status)
* [Contact](#contact)

## General info
First project "SportStoreCore" contain simple web application of Sport Store. User can select items from cateogry, add them to the cart and checkout the order.
Application also contain Admin panel, where administrator can Add/Edit/Delete products.<br>
"Lesson" project contains lessons of individual areas of ASP.NET Core e.g Filters, Identity, Model binding/validations. Each area is a chapter from book, where features are described in details. This will help me to create own applications and I consider this project as a backup of knowledge, where I can look in moments of crisis. :)

## Technologies
* ASP.NET Core - 2.1.1
* EntityFramework - version 6.2.0
* JQuery - version 3.3.1
* Boostrap - version 3.3.7

## Features
SportStoreCore:
* Dependency injection of repository
* EF Code First model with DB migration
* Category pages with pagination
* Adding/Removing items from Cart
* Instance of Cart is saved in Session file
* Form validation in checkout
* Administration panel for CRUD items in shop
* Custom Error page
<br>
Lessons:
* Routing - creating and registering a simple route, defining default values, using attribute routing, customizing the routing system, working with areas
* Controllers and Actions - creating POCO controllers, using the controller base class, producing a response (using the context object, HTML response, contents of files, errors and HTTP codes)
* Dependency Injection - configuring the service provider, understanding service life cycles (Transient, Scoped, Singleton)
* Filters - using and creating authorization, action, result, exception filters.
* API Controllers - creating API controllers, getting/sending JSON data with HTTP Get/Post/Put/Delete methods.
* Views - creating a custom View Engine, working with the Razor Engine, adding dynamic content to a Razor View.
* View Components - creating a View Component (POCO, deriving from the Base Class, Asynchronous), creating Hybrid Controller/View Component classes.
* Tag Helpers - creating and registering Tag Helpers, creating shorthand elements, prepending and appending content and elements, getting View Context data and using dependency injection, suppressing the output element. Working with Form Tag Helpers (form/input/label/select elements). Using the other built-in Tag Helpers (Hosting Environment, JavaScript and CSS Tag Helpers, Anchor and Image elements). Using Data Cache.
* Model Binding - binding simple/complex types, array and collections. Specifying a Model Binding source (headers, body, form).
* Model Validation - server-side validation (Property-Level, Model-Level Validation), client-side validation, remote validation.
* Identity - authenticating users, creating roles, policies, adding custom data to User.
 
## Status
Project is _finished_.

## Contact
Created by [Janusz Marek](https://https://www.linkedin.com/in/janusz-marek/) - feel free to contact me!
