namespace HeroesDota.Models
{
    public class FuncaoModel
    {
        public int Id { get; set; }    
        public string? Funcao { get; set; }
        public string? Descricao { get; set; }
        public int? HeroId { get; set; }
        public virtual HeroModel? Hero { get; set; }
    }
}
