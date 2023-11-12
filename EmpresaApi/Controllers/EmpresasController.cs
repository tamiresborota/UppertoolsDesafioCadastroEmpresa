using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmpresaApi.Models;
using EmpresaApi.Data;
using static EmpresaApi.Models.ReceitaFederalEmpresa;

namespace EmpresaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly UppertoolsContext _context;

        public EmpresasController(UppertoolsContext context)
        {
            _context = context;
        }

        // GET: api/Empresas
        [HttpGet]
        [Route("/api/empresas")]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas()
        {
            if (_context.Empresas == null)
            {
                return NotFound();
            }
            return await _context.Empresas.ToListAsync();
        }

        // GET: api/Empresas/5
        [HttpGet("{cnpjOuRazaoSocial}")]
        [Route("/api/empresas")]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas(string cnpjOuRazaoSocial)
        {

            var empresas = await _context.Empresas
                .Where(e => e.Cnpj == cnpjOuRazaoSocial || e.RazaoSocial.Contains(cnpjOuRazaoSocial))
                .ToListAsync();

            if (!empresas.Any())
            {
                return NotFound("Nenhuma empresa encontrada");
            }

            return empresas;
        }


        // POST: api/Empresas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("/api/empresas")]
        public async Task<ActionResult<Empresa>> PostEmpresa(string cnpj)
        {

            if (!Validador.ValidarCnpj(cnpj))
            {
                return Problem("CNPJ Informado é inválido.");
            }

            try
            {
                ReceitaFederalEmpresa.EmpresaApi empresaApi = ReceitaFederalEmpresa.EmpresaApi.ConsultarApi(cnpj);

                Empresa empresa = CriarEmpresa(empresaApi);


                if (_context.Empresas == null)
                {
                    return Problem("Falha de conexão com o Banco de Dados.");
                }
                _context.Empresas.Add(empresa);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (EmpresaExists(empresa.Cnpj))
                    {
                        return Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }

                return CreatedAtAction("GetEmpresas", new { cnpj = empresa.Cnpj }, empresa);
            }

            catch (Exception ex) { return Problem(ex.Message); }

        }

        private Empresa CriarEmpresa(ReceitaFederalEmpresa.EmpresaApi empresaApi)
        {
            var situacaoApi = (empresaApi.situacao == "ATIVA");

            return new Empresa
            {
                Cnpj = empresaApi.cnpj.Replace(".", "").Replace("-", "").Replace("/", ""),
                RazaoSocial = empresaApi.nome,
                NomeFantasia = empresaApi.fantasia,
                SituacaoCadastral = situacaoApi,
                Telefone = empresaApi.telefone,
                Cidade = empresaApi.municipio,
                Uf = empresaApi.uf,
                Cep = empresaApi.cep,
                Logradouro = empresaApi.logradouro,
                Numero = empresaApi.numero
            };
        }
        // DELETE: api/Empresas/5
        [HttpDelete("{cnpj}")]
        public async Task<IActionResult> DeleteEmpresa(string cnpj)
        {
            if (_context.Empresas == null)
            {
                return NotFound();
            }
            var empresa = await _context.Empresas.FindAsync(cnpj);
            if (empresa == null)
            {
                return NotFound();
            }

            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpresaExists(string cnpj)
        {
            return (_context.Empresas?.Any(e => e.Cnpj == cnpj)).GetValueOrDefault();
        }
    }
}
