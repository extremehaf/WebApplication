using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.ViewModels
{
    public class RecursoMaiorConsumoViewModel
    {
        public int IdPerfil { get; set; }
        public string  NomePerfil { get; set; }
        public int IdRecurso { get; set; }
        public string NomeRecurso { get; set; }
        public double KwhConsumo { get; set; }
        public double ValorConsumo { get; set; }
    }
}