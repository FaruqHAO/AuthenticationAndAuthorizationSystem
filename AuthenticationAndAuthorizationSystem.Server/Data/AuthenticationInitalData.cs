using Microsoft.AspNetCore.Identity;

namespace AuthenticationAndAuthorizationSystem.Server.Data
{
    public static class AuthenticationInitalData
    {
        public const string SuperAdminRole = "superadmin";
        public const string AccountantRole = "accountant";
        public const string MarketingRole = "marketing";
        public const string HrRole = "hr";
        public const string ManagerRole = "manager";
        public static readonly List<IdentityRole> AppRoles  = new List<IdentityRole>
                    {
                        new IdentityRole
                        {
                            Id = "1",
                            Name = SuperAdminRole,
                            NormalizedName = SuperAdminRole,
                        },
                        new IdentityRole
                        {
                            Id = "2",
                            Name = AccountantRole,
                            NormalizedName = AccountantRole,
                        },
                        new IdentityRole
                        {
                            Id = "3",
                            Name = MarketingRole,
                            NormalizedName = MarketingRole,
                        },
                        new IdentityRole
                        {
                            Id = "4",
                            Name = HrRole,
                            NormalizedName = HrRole,
                        },
                        new IdentityRole
                        {
                            Id = "5",
                            Name = ManagerRole,
                            NormalizedName = ManagerRole,
                        },
                    };
    }
}
