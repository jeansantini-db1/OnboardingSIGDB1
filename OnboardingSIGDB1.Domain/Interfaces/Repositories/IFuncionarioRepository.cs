﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OnboardingSIGDB1.Domain.Entities;

namespace OnboardingSIGDB1.Domain.Interfaces.Repositories
{
    public interface IFuncionarioRepository : IGenericRepository<Funcionario>
    {
        Funcionario Get(Expression<Func<Funcionario, bool>> funcFilter);
        bool GetCpfAlreadyExists(int id, string cpf);
    }
}