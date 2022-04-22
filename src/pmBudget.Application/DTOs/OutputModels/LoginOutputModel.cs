namespace pmBudget.Application.DTOs.OutputModels
{
    public class LoginOutputModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public AuthenticatedUserOutputModel User { get; set; }
    }

    public class AuthenticatedUserOutputModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
