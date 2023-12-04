﻿using api_restaurante_hamburguesas.Models.Persona.Catalogos;

namespace api_restaurante_hamburguesas.Utils.Persona.Catalogos
{
    public class ListaTiposUsuario
    {
        public List<TipoUsuario> tiposUsuario = new List<TipoUsuario>()
        {
            new TipoUsuario() { TipoUsuarioId = 1, Tipo = "Administrador" },
            new TipoUsuario() { TipoUsuarioId = 2, Tipo = "Cliente" }
        };
    }
}
