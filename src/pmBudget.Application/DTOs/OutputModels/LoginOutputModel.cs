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
        /*public IEnumerable<ClaimOutputModel> Claims { get; set; }
        public IEnumerable<string> Roles { get; set; }*/
    }

    /*public class ClaimOutputModel
    {
        public string Tipo { get; set; }
        public string Valor { get; set; }
    }*/
}
