using System.Runtime.Serialization;


namespace WebApplication.Models
{
    public class ItemPerfil
    {
        public int Id { get ; set; }
        public int RecursoId { get; set; }
        public int PerfilId { get; set; }
        public int Quantidade { get; set; }
        public int DiasUso { get; set; }
        public double Tempo_uso { get; set; }
        [DataMember(IsRequired = false)]
        public virtual Recurso Recurso { get; set; }
        [DataMember(IsRequired = false)]
        public virtual PerfilConsumo PerfilConsumo { get; set; }
        public ItemPerfil()
        {
        }

        public ItemPerfil(int id, int recursoId, int perfilId, int quantidade, int dias_uso, int tempo_uso)
        {
            this.Id = id;
            this.RecursoId = recursoId;
            this.PerfilId = perfilId;
            this.Quantidade = quantidade;
            this.DiasUso = dias_uso;
            this.Tempo_uso = tempo_uso;
        }

        
    }
}