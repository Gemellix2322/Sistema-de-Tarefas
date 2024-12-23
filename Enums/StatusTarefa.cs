using System.ComponentModel;

namespace SistemadeTarefas.Enums
{
    public enum StatusTarefa
    {
        [Description("A fazer")]
        afazer = 1,
        [Description("Em andamento")]
        emandamento = 2,
        [Description("Concluido")]
        concluido = 3,

    }
}
