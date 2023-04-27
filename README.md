# Chat Room Power Diary Challenge


### Intro

Chat Room Api allows us to save each user interaction into the system, and is possible to view all history based on aggregation level, hourly or minutely. 
For future feature and improvements , the solution provides an scalable archicteture.


### Application

The application was written in .NET 7 frameworking using C# as a programming language and Web Api for API framework. The architecture is based on
CQS (Command Query Seggregation), it brings to our system more flexibility and testability, once we have only one handler for each command or query.
For demo purposes we are using a InMemory data storage in our ChatEventRepository.


### Use Cases


User can:

- enter the room
- leaver the room
- high five another user
- comment
- view the current day aggregated minute per minute or hourly

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


View history houyly

```/Chat/hourly```


