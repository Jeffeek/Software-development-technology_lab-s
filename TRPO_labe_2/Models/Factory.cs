namespace TRPO_labe_2.Models
{
    class Factory : PossessionBase
    {
        public override string Info()
        {
            return "Завод!";
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
