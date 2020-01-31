using InstagroomEX.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstagroomEX.Contracts
{
    public interface IGoogleManager
    {
        void Login(Action<UserDto, string> OnLoginComplete);
        void Logout();
        void OnAuthCompleted(object result);
    }
}
