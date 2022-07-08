using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using sistemaEscolar.Data;
using sistemaEscolar.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sistemaEscolar.Controllers
{
    [ApiController]
    [Route("aluno")]
    public class AlunoController : ControllerBase
    {
        [HttpGet]
        [Route("alunos")]
        public async Task<IActionResult> Get(
            [FromServices] AppDbContext context)
        {

            var alunos = await context
                .Aluno
                .AsNoTracking()
                .ToListAsync();

            return Ok(alunos);
        }


        [HttpGet]
        [Route("alunos/{id}")]
        public async Task<IActionResult> GetByName(
          [FromServices] AppDbContext context, [FromRoute] int id)
        {

            var aluno = await context
                .Aluno
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if(aluno == null)
                return NotFound("Nenhum aluno encontrado");

            return Ok(aluno);
        }


        [HttpPost]
        [Route("alunos")]
        public async Task<IActionResult> PostAsync(
         [FromServices] AppDbContext context, [FromBody] AlunoModel Aluno)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var aluno = new AlunoModel
            {
                Nome = Aluno.Nome,
                Nota1 = Aluno.Nota1,
                Nota2 = Aluno.Nota2,
                Nota3 = Aluno.Nota3,
            };
            //Calculo de média
            CalculoMedia calculadora = new CalculoMedia();
            calculadora.calcularMedia(aluno.Nota1, aluno.Nota2, aluno.Nota3);
            aluno.Media = calculadora.media;
            aluno.Media = (float)Math.Round(aluno.Media, 2);

            //Lógica de recuperação
            RastrearMedia rastrearMedia = new RastrearMedia();
            aluno.Recuperacao = rastrearMedia.calcRecuperacao(aluno.Media);

            //Lógica de reprovação
            aluno.Reprovado = rastrearMedia.calcReprovacao(aluno.Media);

            try
            {
                await context.Aluno.AddAsync(aluno);
                await context.SaveChangesAsync();
                return Ok(aluno);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("alunos/{id}")]
        public async Task<IActionResult> PutAsync(
         [FromServices] AppDbContext context, 
         [FromBody] AlunoModel Aluno,
         [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var aluno = await context
                .Aluno
                .FirstOrDefaultAsync(x => x.Id == id);
            
            if(aluno == null)
                return NotFound();

            aluno.Nota1 = Aluno.Nota1;
            aluno.Nota2 = Aluno.Nota2;
            aluno.Nota3 = Aluno.Nota3;

            //Calculo de média
            CalculoMedia calculadora = new CalculoMedia();
            calculadora.calcularMedia(aluno.Nota1, aluno.Nota2, aluno.Nota3);
            aluno.Media = calculadora.media;
            aluno.Media = (float)Math.Round(aluno.Media, 2);


            //Lógica de recuperação
            RastrearMedia rastrearMedia = new RastrearMedia();
            aluno.Recuperacao = rastrearMedia.calcRecuperacao(aluno.Media);

            //Lógica de reprovação
            aluno.Reprovado = rastrearMedia.calcReprovacao(aluno.Media);


            try
            { 
                context.Aluno.Update(aluno);
                await context.SaveChangesAsync();
                return Ok(aluno);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPatch]
        [Route("recuperacao/{id}")]
        public async Task<IActionResult> PatchAsync(
         [FromServices] AppDbContext context,
         [FromBody] JsonPatchDocument Aluno,
         [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var aluno = await context
                .Aluno
                .FirstOrDefaultAsync(x => x.Id == id);

            if (aluno == null)
                return NotFound();

                Aluno.ApplyTo(aluno);
                

                //Logica de recupercao
                var rastrearNota = new RastrearMedia();
                aluno.Recuperacao = rastrearNota.calcRecuperacao(aluno.Media);
                
                //Lógica de nota Final
                aluno.NotaFinal = rastrearNota.CalcNotaFinal(aluno.Media, aluno.NotaRecuperacao);
                
                //Situacao Final
                aluno.Aprovado = rastrearNota.situacaofinal(aluno.Media, aluno.NotaRecuperacao);
            try
                {
                    await context.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            return BadRequest();
        }
    }
}

