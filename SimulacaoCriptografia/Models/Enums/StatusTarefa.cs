using System.ComponentModel;

namespace SimulacaoCriptografia.Models.Enums
{
    public enum StatusTarefa
    {
        [Description("A fazer")]
        AFazer = 1,

        [Description("Em processamento")]
        EmAndamento = 2,

        [Description("Concluída")]
        Concluido = 3

    }
}
