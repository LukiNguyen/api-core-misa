namespace Employee.Entities
{
    public record User { 
        public Guid UserId { get; set; }
        public string? FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? IdentityCard { get; set; }
        public string? Position { get; set; }
        public string? NumberPhone { get; set; }
        public string? NumberBank { get; set; }
        public string? NameBank { get; set; }
        public string? BranchBank { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}