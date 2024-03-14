Create a folder with .sln file:

dotnet new sln -o sln_name 

cd sln_name

dotnet new classlib -o classlib_name

dotnet new webapi -o webapi_name

Now everything is created by detached. We need to add projects to our solution:

Hint: Start typing with * and then when the name of your project is unique press TAB. This will autocomplete the name of the project.

dotnet sln add *ToDoC.. *ToDoA..

Super Hint: If you want to add just all the projects use this:

dotnet sln add (ls -r **/*.csproj)

Why we name our class lib project as Contracts:

https://hvalls.dev/posts/ensuring-rest-contract-compliance


How to create an empty file (like touch in nix)

An easy way to replace the touch command on a windows command line like cmd would be:

type nul > your_file.txt

This will create 0 bytes in the your_file.txt file.

This would also be a good solution to use in windows batch files.

Another way of doing it is by using the echo command:

echo.> your_file.txt


---------------------------------

When you create a new webapi project it has some boilerplate code in Program.cs.

You can read about this bolierplate code here:

https://blog.devgenius.io/what-is-addendpointsapiexplorer-in-asp-net-core-6-64ba52d15979

Most of it related to the minimal API paradigm that is new to aspnet.


https://dev.to/arminafa/mastering-api-design-patterns-in-net-7-leverage-the-power-of-net-7-to-create-efficient-scalable-and-robust-apis-1a60

----------------------------------

Now when we have all projects set we also want to reference dependencies (build layers)

To do that you need to use this command:

dotnet add (project_where) reference (project_from)

project_where - is the project where you want to have a reference

project_from - is the project which will be accessible from project_where

--------------------------------

Now how to run specific project in your solution?

dotnet run --project *ToDoA..

You can also chekc how to set a default project to run (wasn't really possible using dotnet commands.) Probably using project starter configuration.

--------------------------------

ToDO:

Check dotnet watch:

dotnet watch is a tool that runs a .NET Core CLI command when source files change. For example, a file change can trigger compilation, test execution, or deployment.

https://learn.microsoft.com/en-us/aspnet/core/tutorials/dotnet-watch?view=aspnetcore-8.0


Shortcut:

Select several occurances and change at the same time

https://stackoverflow.com/questions/46539714/select-all-occurrences-of-selected-word-in-vscode

ctrl + shit + L  

Ctrl + D

Ctrl + K + D
-------------------------------
Errors and solutions:

If you don't add controllers in the program.cs file you get this error:

Building...
Unhandled exception. System.InvalidOperationException: Unable to find the required services. Please add all the required services by calling 'IServiceCollection.AddControllers' inside the call to 'ConfigureServices(...)' in the application startup code.
   at Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.EnsureControllerServices(IEndpointRouteBuilder endpoints)
   at Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllers(IEndpointRouteBuilder endpoints)
   at Program.<Main>$(String[] args) in C:\Users\Besitzer\Code\dotnetprojects\ToDoRest\ToDoApi\Program.cs:line 5

==============================

If you create a requst in Requests folder and it works but doesn't return the expected
json body (json is empty {}), then it means that your class type mapping is not correctly done. Check the names and times correctly and USE Constructor declaration of mapped field!! It is sort of an automatic injection mapping of fields.

==============================

If you have a model that is used in the http requests be careful with the number of fields
you modify and expected to be returned to the client.

For example

In the api controller method I expected this record:

public record UpdateToDoRequest
(
    Guid Id,
    string Title,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Priority,
    List<string> Tags
);

but the model object that I returned to the clinet as a response was this:

public record ToDoResponse
(
    Guid Id,
    string Title,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    DateTime LastModifiedDateTime,
    List<string> Priority,
    List<string> Tags
);

There is a difference in one field: LastModifiedDateTime. And this difference doesn't break the code and thows any errors. It just returns a response of the previousely created object which is very misleading.
==============================

If you see this kind of errors but the code looks correct:

C:\Users\Besitzer\Code\dotnetprojects\ToDoRest\ToDoApi\Controllers\ToDoController.cs(43,13): error CS1503: Argument 7: cannot convert from 'System.Collections.Generic.List<string>' to 'string'  
[C:\Users\Besitzer\Code\dotnetprojects\ToDoRest\ToDoApi\ToDoApi.csproj]
C:\Users\Besitzer\Code\dotnetprojects\ToDoRest\ToDoApi\Controllers\ToDoController.cs(62,13): error CS1503: Argument 7: cannot convert from 'System.Collections.Generic.List<string>' to 'string'  
[C:\Users\Besitzer\Code\dotnetprojects\ToDoRest\ToDoApi\ToDoApi.csproj]

Try to retype the type like this;

Retype ToDoResponse

        ToDoResponse response = new ToDoResponse(
            todo.Id,
            todo.Title,
            todo.Description,
            todo.StartDateTime,
            todo.EndDateTime,
            todo.LastModifiedDateTime,
            todo.Priority,
            todo.Tags
        );

Or 
        var response = new ToDoResponse(
            todo.Id,
            todo.Title,
            todo.Description,
            todo.StartDateTime,
            todo.EndDateTime,
            todo.LastModifiedDateTime,
            todo.Priority,
            todo.Tags
        );

and build again. Probably there is a typechecking issue in the vs code attached compiler.

==============================

If you see this kind of error it means that you forgot to inject your service.

fail: Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware[1]
      An unhandled exception has occurred while executing the request.
      System.InvalidOperationException: Unable to resolve service for type 'ToDoApi.Services.IToDoService' while attempting to activate 'ToDoApi.Controllers.ToDoController'.
         at Microsoft.Extensions.DependencyInjection.ActivatorUtilities.ThrowHelperUnableToResolveService(Type type, Type requiredBy)
         at lambda_method4(Closure, IServiceProvider, Object[])
         at Microsoft.AspNetCore.Mvc.Controllers.ControllerFactoryProvider.<>c__DisplayClass6_0.<CreateControllerFactory>g__CreateController|0(ControllerContext controllerContext)
         at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
         at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()
      --- End of stack trace from previous location ---
         at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeFilterPipelineAsync>g__Awaited|20_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
         at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
         at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
         at Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)
         at Microsoft.AspNetCore.Authentication.AuthenticationMiddleware.Invoke(HttpContext context)
         at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddlewareImpl.Invoke(HttpContext context)

===================================
Sometimes when you make http request you make see this kind of error:

System.Collections.Generic.KeyNotFoundException: The given key 'b7b5d0a4-03c0-4b7d-995a-d50267f5b871' was not present in the dictionary.
   at System.Collections.Generic.Dictionary`2.get_Item(TKey key)
   at ToDoApi.Services.ToDoService.GetToDo(Guid id) in C:\Users\Besitzer\Code\dotnetprojects\ToDoRest\ToDoApi\Services\ToDoService.cs:line 20
   at ToDoApi.Controllers.ToDoController.GetToDo(Guid id) in C:\Users\Besitzer\Code\dotnetprojects\ToDoRest\ToDoApi\Controllers\ToDoController.cs:line 52
   at lambda_method6(Closure, Object, Object[])
   at Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor.SyncActionResultExecutor.Execute(ActionContext actionContext, IActionResultTypeMapper mapper, ObjectMethodExecutor executor, Object controller, Object[] arguments)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeActionMethodAsync()
   at Microsoft.AspNetCore.Mvc.Infrastruc

For rest api it's bad practice to propagate and show the actual error. And for
security reasons it's also not recommended to show the actual stack trace of the error
because it may reveal the internals of the system to the malicious people.

It's better to have a standalone erorr handler endpoint.