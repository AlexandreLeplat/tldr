using System;

namespace Entities.Models
{
    public class Token
    {
        public string Jwt { get; set; }
        public DateTime Expiration { get; set; }
        public bool IsPlaying { get; set; }
        public long UserId { get; set; }
    }
}
