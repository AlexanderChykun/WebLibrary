# WebLibrary
LibraryApp
A test task for Sitecore.
Application contains of a two projects:
 - Library.Data – business logic, which contains of such folders:
		* Entites – contains a models of library,
		* Abstract – contains an interfaces,
		*Concrete – contains implementation of interfaces,
		*Migrations  - for update data of database when the code of model is changed. 
- Librari.WebUI – user interface, which contains of standart folders of ASP.NET MVC Web Application and added folders, among them are:
		*Models – contains a models of viewing,
		*Views – contains views,
		*Infrastructure – contains an implementation of controller factory and interface of authorization with its implementation,
User Guide
The application is an "online library", where each user can "take" any book. To do this, user has to find needed books, searching by title or by authors and by clicking to “Add to card” add them to user card. After adding needed book user must be at the user card form. If he did’t, go to user card form by clicking “Checkout” button at the top of the form. Then user must check added books(delete if there is a wrong book) and click at “checkout now”. Then user must enter name and email to register and books will send. 
Admin Guide
To get admin rights, you should add at the address field of browser  http://(some localhost)/Admin/index. Then enter user name (admin) and password(admin). 
Admin rights suggest such options:
-	Create, edit, delete a book;
-	Look a history of taken book;
-	Look a list of library users;
How to Install
- Download all files as ZIP (or copy git repository to your Visual Studio)
- Unpack ZIP archive
- Open file WebLibrary.sln at VisualStudio
- By clicking right button to Solution ‘WebLibrary’ at Solution Explorer choose “Enable NuGet package restore” to restore needed packages for the progect.
- Rebuild solution
**** Installation successful ****

