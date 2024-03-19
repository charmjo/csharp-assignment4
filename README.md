# csharp-assignment4
PROG8146 Software Development Techniques Assignment 4



## Validations
### Regex used for the email:
```php
$regex= "/^(\w{3,}(\.)?)+@([a-z0-9]+\.)+[a-z0-9]+$/i";
```

#### positive emails
john.doe@gmail.com \n
test@test.com \n
Jdoe1234@conestogac.on.ca \n
john_doe@gmail.com

#### negative emails
john@gma_il.com \n
x@test.com \n
xy@test.com
