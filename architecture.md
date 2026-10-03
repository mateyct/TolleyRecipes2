# Architecture
## Database Schema
All tables will have an Id.

#### Top-level recipe
- Title:string
- Prep time:minutes(int)
- Cook time:minutes(int)
- Calories:int?
- Servings:int?
- Updated:date
- user Id (Author)
- Rating:float
- category:string(enum)
- userIsAuthor:bool
  - used if added by a user that is not the author, false if credit needs to be given to another person
- authorName:string?

#### Component
- Title:string?
- Prep time:minutes(int)?
- Cook time:minutes(int)?
- recipe Id

#### Ingredient
- amount:int
- fraction:int?
- measurement:string?
- item:string
- component Id

#### Instruction
- ordinal:int
- instruction:string
- component Id

#### Tag
- name:string

#### Recipe Tag
- recipe Id
- tag Id

#### User
- username:string
- firstName:string
- lastName:string
- role:string(enum) (admin, user)
- profilePic:url?

#### Rating
- user Id
- score:int
  - out of 10, will appear as 5 stars
- recipe Id
- title:string
- review:string