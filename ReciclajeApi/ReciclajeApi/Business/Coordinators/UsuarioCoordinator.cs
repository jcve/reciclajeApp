﻿using System;
using AutoMapper;
using ReciclajeApi.Business.ICoordinators;
using ReciclajeApi.Business.Models.ApiModels;
using ReciclajeApi.Business.Models.Domain;
using ReciclajeApi.Persistance.IDao;

namespace ReciclajeApi.Business.Coordinators
{
    public class UsuarioCoordinator : IUsuarioCoordinator
    {
        private readonly IUsuarioDao usuarioDao;
        private readonly IMapper mapper;

        public UsuarioCoordinator(IUsuarioDao usuarioDao, IMapper mapper)
        {
            this.usuarioDao = usuarioDao;
            this.mapper = mapper;
        }

        public UsuarioApiModel ObtenerUsuario(int idUsuario)
        {
            if (idUsuario < 1)
            {
                throw new Exception();
            }

            var result = usuarioDao.ObtenerUsuario(idUsuario);

            if (result == null)
            {
                return null;
            }

            return mapper.Map<UsuarioApiModel>(result);
        }

        public UsuarioApiModel ObtenerUsuarioPorMail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception();
            }

            var result = usuarioDao.ObtenerUsuarioPorMail(email);

            if (result == null)
            {
                return null;
            }

            return mapper.Map<UsuarioApiModel>(result);
        }

        public bool ValidarUsuario(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception();
            }

            return usuarioDao.ValidarUsuario(email);
        }

        public int SignUpUsuario(SignUp signUp)
        {
            return usuarioDao.SignUpUsuario(signUp);
        }

        public bool ExisteUsuario(int idUsuario)
        {
            return usuarioDao.ExisteUsuario(idUsuario);
        }

        public PerfilApiModel ObtenerPerfil(int idUsuario)
        {
            var result = usuarioDao.ObtenerPerfil(idUsuario);

            if (result == null)
            {
                throw new Exception();
            }

            return mapper.Map<PerfilApiModel>(result);
        }
    }
}