# csharp-assignment4
PROG8146 Software Development Techniques Assignment 4



## Validations
### Regex used for the email:
```php
$regex= "/^(\w{3,}(\.)?)+@([a-z0-9]+\.)+[a-z0-9]+$/i";
```

#### positive emails
john.doe@gmail.com
test@test.com
Jdoe1234@conestogac.on.ca
john_doe@gmail.com

#### negative emails
john@gma_il.com
x@test.com
xy@test.com
