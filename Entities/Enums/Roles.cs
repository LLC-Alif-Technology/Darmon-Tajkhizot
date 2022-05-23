using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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
