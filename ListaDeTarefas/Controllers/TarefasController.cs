using System.Collections.Generic;
using ListaDeTarefas.Model;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefas.Controllers
{
    public class TarefasController : Controller
    {
        private static List<Tarefa> _tarefas = new List<Tarefa>();

        public IActionResult Index()
        {
            return View(_tarefas);
        }

        public IActionResult Concluidas()
        {
            var tarefasConcluidas = _tarefas.Where(t => t.Concluida).ToList();
            return View(tarefasConcluidas);
        }

        public IActionResult AFazer()
        {
            var tarefasAFazer = _tarefas.Where(t => !t.Concluida).ToList();
            return View(tarefasAFazer);
        }


        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Tarefa tarefa)
        {
            tarefa.Id = _tarefas.Count + 1;

            _tarefas.Add(tarefa);

            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var tarefa = _tarefas.Find(t => t.Id == id);
            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Editar(Tarefa tarefa)
        {
            var index = _tarefas.FindIndex(t => t.Id == tarefa.Id);
            _tarefas[index] = tarefa;
            return RedirectToAction("Index");
        }

        public IActionResult Deletar(int id)
        {
            var tarefa = _tarefas.Find(t => t.Id == id);
            return View(tarefa);
        }

        [HttpPost]
        public IActionResult DeletarConfirmado(int id)
        {
            _tarefas.RemoveAll(t => t.Id == id);
            return RedirectToAction("Index");
        }
    }
}
