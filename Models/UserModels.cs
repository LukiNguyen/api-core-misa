using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Employee {
    public record User { 
        public string UserId { get; set; }
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

    public static class UserModels {
        public static User AsUserModel(this User user) {
            return new User {
                UserId = user.UserId,
                FullName = user.FullName,
                Gender = user.Gender,
                DateOfBirth = user.DateOfBirth,
                IdentityCard = user.IdentityCard,
                Position = user.Position,
                NumberPhone = user.NumberPhone,
                NumberBank = user.NumberBank,
                NameBank = user.NameBank,
                BranchBank = user.BranchBank,
            };
        }
    }
    
    public record UserCreateModel
    { 

        [Required]
        public string UserId { get; set; }

        [Required]
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = "other";
        public string? IdentityCard { get; set; }
        public string? Position { get; set; }
        public string? NumberPhone { get; set; }
        public string? NumberBank { get; set; }
        public string? NameBank { get; set; }
        public string? BranchBank { get; set; }
    }

    public record UserUpdateModel
    { 
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [DefaultValue("other")]
        public string Gender { get; set; }
        public string? IdentityCard { get; set; }
        public string? Position { get; set; }
        public string? NumberPhone { get; set; }
        public string? NumberBank { get; set; }
        public string? NameBank { get; set; }
        public string? BranchBank { get; set; }
    }

    public record DeleteUser { 

        [Required]
        public string UserId { get; set; }
    }
}