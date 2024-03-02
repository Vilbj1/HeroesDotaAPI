namespace HeroesDota.Models
{
    public class HeroModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Atributo { get; set; }
        public int Ataque { get; set; }
        public int Armor { get; set; }
        public int Hp { get; set; }

        public static implicit operator HeroModel(bool v)
        {
            throw new NotImplementedException();
        }
    }
}
