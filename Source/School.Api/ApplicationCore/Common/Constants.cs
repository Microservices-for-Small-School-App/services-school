namespace School.Api.ApplicationCore.Common
{

    public static class Constants
    {
        public static class HelloWorldRoutes
        {
            public static string Root { get; } = "/";

            public static string HelloWorld { get; } = "/hw";

            public static string Api { get; } = "/api";

            public static string ApiV1 { get; } = "/api/v1";
        }

        public static class UsersRoutes
        {
            public static string Prefix { get; } = "/api/users";

            public static string Root { get; } = "/";

            public static string ActionById { get; } = "/{id}";
        }

        public static class CoursesRoutes
        {
            public static string Prefix { get; } = "/api/courses";

            public static string Root { get; } = "/";

            public static string ActionById { get; } = "/api/courses/{Id}";
        }

        public static class InMemoryDatabase
        {
            public static string Name { get; } = "SchoolDatabase";
        }
    }

}
