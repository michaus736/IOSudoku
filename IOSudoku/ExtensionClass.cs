namespace IOSudoku
{
    public static class ExtensionClass
    {
        public static bool isLogged(this HttpContext context)
        {
            return context.User is not null && context.User.Identity is not null && context.User.Identity.IsAuthenticated;
        }
    }
}
