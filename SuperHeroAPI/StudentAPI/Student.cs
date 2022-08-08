namespace StudentAPI
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int MatricNo { get; set; } 
        public int Level { get; set; }
        public string Department { get; set; } = string.Empty;
        public string Program { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
