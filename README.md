# Chat Room Power Diary Challenge


### Intro

Chat Room Api allows us to save each user interaction into the system, and is possible to view all history based on aggregation level, hourly or minutely. 
For future features and improvements , the solution provides an scalable and flexbible archicteture.


### Application

The application was written in .NET 7 framework using C# as a programming language and Web Api for API framework. The architecture is based on
CQS (Command Query Seggregation), it brings to our system more flexibility and testability, once we have only one handler for each command or query.
For demo purposes we are using a InMemory data storage in our ChatEventRepository.


### Use Cases


User can:

- enter the room
- leave the room
- high five another user
- comment
- view the current day aggregated minute per minute or hourly

### Run
- .NET 7 must be installed.
- Into a base directory run:

``` dotnet run --project PowerDiaryChallenge.Api/PowerDiaryChallenge.Api.csproj ``

Access swagger api page: http://localhost:5244/swagger/index.html

### Endpoints

Enter Room


```POST /Chat/enter-room```

Leave Room

```POST /Chat/leave-room```


Comment

```POST /Chat/comment```


High Five

```POST /Chat/high-five```


View history minute per minute

```GET /Chat/minutely```


View history hourly

```/Chat/hourly```


### Improvements


Of course the source code need some adjustments, what we can do for future improvements is:

- Create a separate builder for our messages, if the demand of type views increases.


