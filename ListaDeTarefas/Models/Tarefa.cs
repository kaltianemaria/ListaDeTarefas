namespace ListaDeTarefas.Model
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Concluida { get; set; }
        public string DataDeConclusao { get; set; }
    }

}
