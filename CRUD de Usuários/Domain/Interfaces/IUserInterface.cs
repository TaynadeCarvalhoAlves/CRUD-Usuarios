using CRUD_de_Usuários.Domain.Entidades;

namespace CRUD_de_Usuários.Domain.Interfaces
{
    public interface IUserInterface
    {
        Task<IEnumerable<User>> GetAlluser();
        Task<User> GetUserById(int userId);
        Task<IEnumerable<User>> CreateUser(User user);
        Task<IEnumerable<User>> UpdateUser(User user);
        Task<IEnumerable<User>> DeleteUser(int userId);

    }
}
