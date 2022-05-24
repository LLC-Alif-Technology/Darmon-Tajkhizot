using System.ComponentModel;

namespace Entities.Enums
{
    public enum Roles
    {
        [Description("Администратор")]
        Admin = 1,
        [Description("Менеджер")]
        Manager,
        [Description("Пользователь")]
        User
    }
}
