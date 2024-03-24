namespace Noru.Employee
{
    public class Employee
    {
        public Character Character { get; private set; }
        public Rank Rank { get; private set; }
        public Level Level { get; private set; }
        public Limit Limit { get; private set; }
        public float Proficiency { get; private set; }

        public Employee(Character character)
        {
            Character = character;
            Rank = Rank.employee;
            Level = Level.newcomer;
            Limit = Limit.none;
            Proficiency = 0;
        }

        public void SetEmployee(Character character)
        {
            Character = character;
            Rank = Rank.employee;
            Level = Level.newcomer;
            Limit = Limit.none;
            Proficiency = 0;
        }

        public void SetLevel(Level level)
        {
            Level = level;
        }

        public void SetRank(Rank rank)
        {
            Rank = rank;
        }

        public void SetLimit(Limit limit)
        {
            Limit = limit;
        }

        public void SetProficiency(float proficiency)
        {
            Proficiency = proficiency;
        }
    }
}