# services-school
A .NET 7 Minimal API for Courses, and Student

//app.MapPost(HelloWorldEndpoints.ApiPostUser, ([FromBody] object personJson) =>
//{
//    var person = JsonConvert.DeserializeObject<dynamic>(personJson.ToString()!)!;
//    return ApiResponseDto<dynamic>.Create(new
//    {
//        UserId = $"{person.id}",
//        Message = $"Hello {person.name}, Welcome to Minimal API World !!"
//    });
//});