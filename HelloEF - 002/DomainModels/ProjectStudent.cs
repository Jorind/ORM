namespace HelloEF.DomainModels {
    public class ProjectStudent
    {
        public int Id { get; set; }

        //FK to Student
        public int StudentId { get; set; }
        //Navigation property
        public virtual Student Student { get; set; }

        //FK to Project
        public int ProjectId { get; set; }
        //Navigation property
        public virtual Project Project { get; set; }
    }
}

