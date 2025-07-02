﻿using WebApiProj1.Repositories.Interfaces;

namespace WebApiProj1.Repositories.Common
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        void SaveChanges();
    }
}
