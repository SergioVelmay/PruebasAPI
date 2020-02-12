using AutoMapper;
using RotuladoresDomain.Models;
using RotuladoresDomain.Repositories;
using RotuladoresDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RotuladoresDomain.Services
{
    public class RotuladorService : IRotuladorService
    {
        private readonly IRotuladorRepository _rotuladores;
        private readonly IMapper _mapper;

        public RotuladorService(IRotuladorRepository rotuladorRepository, IMapper mapper)
        {
            _rotuladores = rotuladorRepository;
            _mapper = mapper;
        }

        public List<RotuladorDTO> Get()
        {
            List<Rotulador> rotuladores = _rotuladores.Get();
            List<RotuladorDTO> rotuladoresDTO = _mapper.Map<List<RotuladorDTO>>(rotuladores);
            return rotuladoresDTO;
        }

        public RotuladorDTO Get(string id)
        {
            Rotulador rotulador = _rotuladores.Get(id);
            RotuladorDTO rotuladorDTO = _mapper.Map<RotuladorDTO>(rotulador);
            return rotuladorDTO;
        }

        public RotuladorDTO Create(RotuladorDTO rotulador)
        {
            Rotulador rotuladorModel = _mapper.Map<Rotulador>(rotulador);
            _rotuladores.Create(rotuladorModel);
            RotuladorDTO rotuladorDTO = Get(rotuladorModel.Id);
            return rotuladorDTO;
        }

        public void Update(string id, RotuladorDTO rotulador)
        {
            Rotulador rotuladorModel = _mapper.Map<Rotulador>(rotulador);
            _rotuladores.Update(id, rotuladorModel);
        }

        public void Remove(RotuladorDTO rotulador)
        {
            Rotulador rotuladorModel = _mapper.Map<Rotulador>(rotulador);
            _rotuladores.Remove(rotuladorModel);
        }

        public void Remove(string id)
        {
            _rotuladores.Remove(id);
        }
    }
}
