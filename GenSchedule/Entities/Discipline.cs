namespace GenSchedule.Entities
{
    class Discipline
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int LessonsPerWeek { get; set; }
        public int Period { get; set; }
        public Professor Professor { get; set; }

        public Discipline(string id, string name, int lessonsPerWeek, int period, Professor professor)
        {
            Id = id;
            Name = name;
            LessonsPerWeek = lessonsPerWeek;
            Period = period;
            Professor = professor;
        }
    }
}
