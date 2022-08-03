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
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly MyEventosContext _context;
        public PalestrantePersist(MyEventosContext context)
        {
            _context = context;            
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais); 

            if( includeEventos ){
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude( pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais); 

            if( includeEventos ){
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude( pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id)
                .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedesSociais); 

            if( includeEventos ){
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude( pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id)
                .Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }

    }
}