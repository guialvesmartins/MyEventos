using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyEventos.Domain;
using MyEventos.Persistence.Contatos;
using MyEventos.Persistence.Contextos;

namespace MyEventos.Persistence
{
    public class EventoPersist : IEventoPersist
    {
        private readonly MyEventosContext _context;
        public EventoPersist(MyEventosContext context)
        {
            _context = context;
            // Remove Tracking (Reserva de Registro)
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;            
        }
			//Busca Todos os Eventos
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais); 

            if( includePalestrantes ){
                query = query.Include(e => e.PalestrantesEventos)
                    .ThenInclude( pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        //Busca Evento por Tema
        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais); 

            if( includePalestrantes ){
                query = query.Include(e => e.PalestrantesEventos).
                            ThenInclude( pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
                .Where( e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }
        
        //Busca Evento por ID
        public async Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais); 

            if( includePalestrantes ){
                query = query.Include(e => e.PalestrantesEventos)
                            .ThenInclude( pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
                .Where( e => e.Id == EventoId);

            return await query.FirstOrDefaultAsync();
        }
    }
}