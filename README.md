# TodoApi
Simple Todo API built in C# and ASP.Net

I got bored and decided to mess around with REST APIs in C#. ASP.Net is an awesome framework, and had very comprehensible documentation.
This API supports CRUD operations and dynamic routes. The pages aren't interactive because there aren't any. I was more focussed on figuring out how backends work rather than learning how to build a frontend for it, so I completely skipped that step 😛

## Installation
1. Clone the repo
```bash
git clone https://github.com/j0of/TodoApi.git
```
2. Open the .sln in your IDE of choice
3. Run it! (The Nuget packages should install themselves automatically... I think)

## Usage
Here is a list of routes that you can request in Postman (or any other HTTP client):
- GET /api/todo : Get all of the TodoItems
- GET /api/todo/1 : Get one TodoItem (substitute 1 with any ID)
- DELETE /api/todo/1 : Remove an existing TodoItem (substitute 1 with any ID)
- POST /api/todo : Add a new TodoItem, based on the request body. Example request body:
```json
{
  "title": "Clean the dishes",
  "completed": false
}
```
(Note: You may not specify an ID here)
- PUT /api/todo/1 : Update an existing TodoItem, based on the request body. (substitute 1 with any ID) Example request body:
```json
{
  "completed": true
}
```
(Note: You may not specify an ID here; leaving the title blank will keep it the same as it was before)
