using Microsoft.EntityFrameworkCore;
using oracle_web_api.Context;
using oracle_web_api.Interfaces;
using oracle_web_api.Models;
using oracle_web_api.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace oracle_web_api.Services
{
    public class AttentionService : IAttentionService
    {
        private readonly ModelContext _context;

        public AttentionService(ModelContext context)
        {
            _context = context;
        }

        public async Task<Attention?> GetAttentionByIdAsync(int id)
        {
            var attentions = await _context.Attentions
                .FromSqlInterpolated($@"
                    SELECT atendime.cd_atendimento AS attentionId,
                           atendime.hr_atendimento AS dateAttention,
                           paciente.nm_paciente AS patientName
                    FROM atendime
                    INNER JOIN paciente ON paciente.cd_paciente = atendime.cd_paciente
                    WHERE atendime.cd_atendimento = {id}
                ")
                .ToListAsync();

            if (attentions.Count > 1)
            {
                throw new InvalidOperationException("Se han encontrado múltiples resultados para el mismo identificador. Esto debería revisarse a nivel de datos.");
            }

            return attentions.SingleOrDefault();
        }
    }
}
