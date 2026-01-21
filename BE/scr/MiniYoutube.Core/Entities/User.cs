using MiniYoutube.Core.Enums;

namespace MiniYoutube.Core.Entities
{
    public class User : BaseEntity
    {
        public string OAuthProvider { get; set; } = string.Empty; // google, github, ...
        public string OAuthId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.User; // USER | ADMIN
    }
}
