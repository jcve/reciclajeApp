﻿using System;
using System.Collections.Generic;
using AutoMapper;
using ReciclajeApi.Business.ICoordinators;
using ReciclajeApi.Business.Models.ApiModels;
using ReciclajeApi.Persistance.IDao;

namespace ReciclajeApi.Business.Coordinators
{
    public class InformacionCoordinator : IInformacionCoordinator
    {
        private readonly IInformacionDao informacionDao;
        private readonly IMapper mapper;

        public InformacionCoordinator(IInformacionDao informacionDao, IMapper mapper)
        {
            this.informacionDao = informacionDao;
            this.mapper = mapper;
        }

        public List<MaterialApiModel> ObtenerMateriales()
        {
            var result = informacionDao.ObtenerMateriales();

            if (result == null)
            {
                throw new Exception();
            }

            return mapper.Map<List<MaterialApiModel>>(result);
        }

        public string ObtenerTip()
        {

            var result = informacionDao.ObtenerTip();

            if (result == null)
            {
                throw new Exception();
            }

            var random = new Random();
            int num = random.Next(result.Count);

            return result[num].Descripcion;

        }
    }
}