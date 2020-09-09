namespace ExpensesTracker.Identity.Infrastructure.AspNetIdentity
{
    public class AspNetIdentityOptions
    {
        public PasswordOptions Password { get; set; }
        public LockoutOptions Lockout { get; set; }
        public UserOptions User { get; set; }
        public ApplicationCookieOptions ApplicationCookie { get; set; }
        public class PasswordOptions
        {
            public bool RequireDigit { get; set; }
            public bool RequireLowercase { get; set; }
            public bool RequireNonAlphanumeric { get; set; }
            public bool RequireUppercase { get; set; }
            public int RequiredLength { get; set; }
            public int RequiredUniqueChars { get; set; }
        }
        public class LockoutOptions
        {
            public int DefaultLockoutTimeSpanInMinutes { get; set; }
            public int MaxFailedAccessAttempts { get; set; }
            public bool AllowedForNewUsers { get; set; }

        }
        public class UserOptions
        {
            public string AllowedUserNameCharacters { get; set; }
            public bool RequireUniqueEmail { get; set; }

        }
        public class ApplicationCookieOptions
        {
            public bool HttpOnly { get; set; }
            public int ExpireTimeSpanInMinutes { get; set; }
            public string LoginPath { get; set; }
            public string AccessDeniedPath { get; set; }
            public bool SlidingExpiration { get; set; }
        }
    }
}
