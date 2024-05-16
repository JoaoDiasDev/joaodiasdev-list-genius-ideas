﻿using JoaoDiasDev.ListGenius.Data.VO;
using JoaoDiasDev.ListGenius.Model;

namespace JoaoDiasDev.ListGenius.Repository.UserRepo
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
        User ValidateCredentials(string userName, string email);
        bool RevokeToken(string userName);
        User RefreshUserInfo(User user);
        bool CreateUser(User user);
    }
}