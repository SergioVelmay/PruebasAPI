using AutoMapper;
using RotuladoresDomain.Models;
using RotuladoresDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RotuladoresDomain.Mappers
{
    public class RotuladorMapper : Profile
    {
        public RotuladorMapper()
        {
            CreateMap<Rotulador, RotuladorDTO>()
                .ForMember(
                    dest => dest.Marca, 
                    opts => opts.MapFrom(src => ExtractMarca(src.Nombre)))
                .ForMember(
                    dest => dest.Modelo,
                    opts => opts.MapFrom(src => ExtractModelo(src.Nombre))
                );

            CreateMap<RotuladorDTO, Rotulador>()
                .ForMember(
                    dest => dest.Nombre,
                    opts => opts.MapFrom(src => CreateNombre(src.Marca, src.Modelo))
                );
        }

        private string ExtractMarca(string name)
        {
            string[] words = name.Split(' ');
            return words[0];
        }

        private string ExtractModelo(string name)
        {
            string[] words = name.Split(' ');
            if (words.Length > 1) {
                return words[1];
            }
            else
            {
                return string.Empty;
            }
        }

        private string CreateNombre(string marca, string modelo)
        {
            return (marca + " " + modelo).Trim();
        }
    }
}
