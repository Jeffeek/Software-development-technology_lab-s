namespace TRPO_labe_2.Models
{
    class Office : PossessionBase
    {
        public override string Info()
        {
            return "Офис!";
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
