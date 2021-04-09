# ProductAPI

### To Create The Database run on PM console
> update-database

### Adding Dummy Data
- Go to **Server Explorer**
- Right-Click on **Data Connections**
- in **Add Connections** add **(localdb)mssqllocaldb** as server name
- from select or enter a database name select **ecomm_db** and test connection
- now Expand the connected database until **Product** table 
- right-click on **Product** and select **show table data**
- add necessary data for testing

### Routes and Data

Search By ProductID [GET]
> Ex. http://localhost:51943/searchProductById/1
Here "1" is the product ID

Search By ProductName [GET]
> Ex. http://localhost:51943/searchProductByName/Toy
Here "Toy" is the product Name

Add Rating [POST]
> Ex. http://localhost:51943/addProductRating/1/4
Here "1" is the product ID
and "4" is the Rating
