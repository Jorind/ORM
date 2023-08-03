namespace HelloEF.DomainModels
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}

