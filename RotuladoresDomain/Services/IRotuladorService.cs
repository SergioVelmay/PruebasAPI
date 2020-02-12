using AutoMapper;
using RotuladoresDomain.Models;
using RotuladoresDomain.Repositories;
using RotuladoresDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RotuladoresDomain.Services
{
    public interface IRotuladorService
    {
        List<RotuladorDTO> Get();

        RotuladorDTO Get(string id);

        RotuladorDTO Create(RotuladorDTO rotulador);

        void Update(string id, RotuladorDTO rotulador);

        void Remove(RotuladorDTO rotulador);

        void Remove(string id);
    }
}
