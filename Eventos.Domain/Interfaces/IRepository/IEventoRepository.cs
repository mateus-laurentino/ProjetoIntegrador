﻿using Eventos.Domain.DTOs.InputModel;
using Eventos.Domain.DTOs.OutputModel;
using Eventos.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.Domain.Interfaces.IRepository
{
    public interface IEventoRepository
    {
        Task<List<EventoOutputModel>> BuscarTodos(CategoriaEnum categoria);
        Task<bool> AdicionarEvento(AdicionarEventoInputModel model);
    }
}
