namespace CarShowRoom.DbModel;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
    public int RoleId { get; set; }

    public User()
    {
        
    }
    public User(string login, string password, int roleId)
    {
        Login = login;
        Password = password;
        RoleId = roleId;
    }
}
public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<User> Users { get; set; }
    public Role(string name) => Name = name;

    public Role()
    {
        
    }
}