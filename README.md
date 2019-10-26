# BlogPost

To run the App Please follow the following instructions :

1 - Edit the connection string in 
   * Blog.Web appsettings.json
   * Blog.Security appsettings.json
   * Blog.Security/Infrastructure/DBContext/PersistedGrantDbContextFactory.cs

2 - Update Database Migrations As Follow :
  
  * For Blog.Web => Set Blog.DataModel as StartUp Project => From Command Line Update-Database 
  * For Blog.Security => Set Blog.Security.Infrastructure as a StartUp Project => From Command Line 
      Update-Database -Context BlogIdentityDbContext
      Update-Database -Context PersistedGrantDbContext
      
3 - Get Token For JWT from /connect/token [Post] [ContentType: application/x-www-form-urlencoded] with the following Body
    * client_id=Blog
    * client_secret=BlogSecret
    * grant_type=password
    * username=user1@email.com
    * password=P@ssw0rd

4 - Send the JWT Returned from step 3 with each Api Call as Authorization Header Bearer

* run Blog.Web => /index.html to check all the Apis using Swagger 
* run Blog.Web => /Notification/PostNotification to check Notification when adding a Blog Post
    
