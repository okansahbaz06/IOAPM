namespace APM.Entities.Entities
{
    public class ProjectEmployee
    {
        public int ProjectID { get; set; }
        public Project PROJECT { get; set; }

        public int EmployeeID { get; set; }
        public Employee EMPLOYEE { get; set; }
    }
}
