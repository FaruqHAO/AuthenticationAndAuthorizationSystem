namespace AuthenticationAndAuthorizationSystem.Server.Models
{
    public class UserWithRoles
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public bool Error { get; set; }
        public bool Saved { get; set; }
        public bool Saving { get; set; }
    }
}
