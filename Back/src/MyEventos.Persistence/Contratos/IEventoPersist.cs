using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyEventos.Domain;

namespace MyEventos.Persistence.Contatos
{
    public interface IEventoPersist
    {
        //EVENTOS
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes);
    }
}