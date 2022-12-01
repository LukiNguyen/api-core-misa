namespace Employee.Repositories {
    
    public interface IUserInterface
    {
        public Task<IEnumerable<User>> GetUsers(string keyword, int? limit, int? offset);
        public Task<User> GetUserByFullName(string? FullName);
        public Task<User> GetUserByID(string? UserId);
        public Task<User> GetUserByNumberPhone(string? NumberPhone);
        public Task<User> CreateUser(UserCreateModel user);
        public Task UpdateUser(string UserId, UserUpdateModel user);
        public Task DeleteUser(string UserId);
    }
}