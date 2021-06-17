using POC.Hexagonal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Hexagonal.Application.Adapters.Queries
{
    public interface IUsuarioReadOnlyRepository
    {
        Usuario Obter(string cpf);
    }
}