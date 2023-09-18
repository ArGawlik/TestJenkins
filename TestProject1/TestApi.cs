using RestEase;
using TestProject1.Models;

namespace TestProject1
{
    public interface TestApi
    {
        [Get("hello-world")]
        Task<string> GetHelloWorldText();

        [Get("user")]
        Task<User> GetUser();

        [Get("user/{id}")]
        Task<User> GetUser([Path] int id);

        [Get("users")]
        Task<List<User>> GetUsers();

        [Post("user")]
        Task<string> PostUser([Body] User user);
    }
}
