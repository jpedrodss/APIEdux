using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIEdux.Contexts;
using APIEdux.Domains;
using APIEdux.Repositories;

namespace APIEdux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriaRepository _categoriaRepository;

        public CategoriasController()
        {
            _categoriaRepository = new CategoriaRepository();
        }



        /// <summary>
        /// Lista todos itens do Objeto Categoria
        /// </summary>
        /// <returns>Lista Categoria</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var categorias = _categoriaRepository.Listar();

                if (categorias.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = categorias.Count,
                    data = categorias
                });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca Objeto Categoria por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Categoria Buscada</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Categoria categoria = _categoriaRepository.BuscarID(id);

                if (categoria == null)
                    return NotFound();

                return Ok(categoria);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita Objeto categoria
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoria"></param>
        /// <returns>Itens categoria a serem editados</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Categoria categoria)
        {
            try
            {
                var categoriaTemp = _categoriaRepository.BuscarID(id);

                if (categoriaTemp == null)
                    return NotFound();

                categoria.IdCategoria = id;
                _categoriaRepository.Editar(categoria);

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Adiciona Objeto Categoria
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>Objeto categoria a ser adicionado</returns>
        [HttpPost]
        public IActionResult Post(Categoria categoria)
        {
            try
            {
                _categoriaRepository.Adicionar(categoria);

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui Objeto Categoria
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto categoria a ser Excluido</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _categoriaRepository.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
