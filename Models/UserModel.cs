using System.ComponentModel.DataAnnotations;
using CarShowRoom.DbModel;

namespace CarShowRoom.Models;

public class UserModel
{
    [Required(ErrorMessage = "Не введен логин")]
    public string Login { get; set; }
    [Required(ErrorMessage = "Не введен пароль")]
    public string Password { get; set; }

    public User ToDbModel()
    {
        return new User()
        {
            Login = Login,
            Password = Password,
            RoleId = 3
        };
    }
}