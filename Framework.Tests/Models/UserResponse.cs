using System.Text.Json.Serialization;

namespace Framework.Tests
{
    public class UserResponse
    {
        [JsonPropertyName("data")]
        public UserData Data { get; set; }
    }

    public class UserData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("first_name")] // This fixes the underscore mismatch!
        public string FirstName { get; set; }
    }
}