# Food ordering web application

### Views

+ [ ] PageLayout.cshtml - *shared page layout among pages*
    * [ ] display basket size and sum in a header
+ [ ] Index.cshtml - *main site*
    * [x] basic structure
    * [ ] display categories and link them to FoodList.cshtml
    * [x] display first 10 of the most popular items 
+ [ ] FoodList.cshtml - *lists foods in a category*
    * [ ] display a list of foods (with price, name and details tags)
    * [ ] filter by string containment
    * [ ] mark vegetarian and spicy foods
    * [ ] add foods to basket (until exceeding 20 000)
+ [ ] Basket.cshtml - *display contents and details of current basket*
    * [ ] display items list with prices and sum of prices
    * [ ] let users remove items from the list
+ [ ] Order.cshtml - *a form to place an order*
    * [ ] order form (name, address, phone)
    * [ ] client-side validation
    * [ ] server-side validation
    * [ ] submit form and insert into database
    * [ ] cancel order