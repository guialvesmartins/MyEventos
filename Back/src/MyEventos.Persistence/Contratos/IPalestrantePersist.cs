using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyEventos.Domain;

namespace MyEventos.Persistence.Contatos
{
    public interface IPalestrantePersist
    {
        //PALESTRANTES
         Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos);
    }
}