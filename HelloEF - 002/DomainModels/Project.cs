namespace HelloEF.DomainModels
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsPrivate { get; set; }

        public virtual ICollection<ProjectStudent> ProjectStudents { get; set; }
    }
}

