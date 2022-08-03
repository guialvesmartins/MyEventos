using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyEventos.Application.Contratos;
using MyEventos.Domain;
using MyEventos.Persistence.Contatos;

namespace MyEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;
        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _eventoPersist = eventoPersist;
            _geralPersist = geralPersist;

        }
        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralPersist.Add<Evento>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                //Atribui a variavel evento o Id do modelo que será atualizado.
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
                //Verfica se foi encontrado
                if (evento == null) return null;
                //Se localizar atribui o Id ao evento
                model.Id = evento.Id;
                //Aplica update
                _geralPersist.Update(model);
                //Salva Alterações
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                //Atribui a variavel evento o Id do modelo que será atualizado.
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
                //Verfica se foi encontrado
                if (evento == null) throw new Exception("Evento para delete não encontrado.");
                //Aplica update
                _geralPersist.Delete(evento);
                //Salva Alterações
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema,includePalestrantes);
                if (eventos == null) return null;
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
             try
            {
                var eventos = await _eventoPersist.GetEventoByIdAsync(eventoId ,includePalestrantes);
                if (eventos == null) return null;
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}