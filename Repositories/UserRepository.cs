using Dapper;
using Employee.Database;
using System.Data;

namespace Employee.Repositories
{

    public class UserRepository : IUserInterface
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context) =>  _context = context;
        
        public async Task<IEnumerable<User>>  GetUsers(string keyword, int? limit, int? offset)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@limit", limit);
            parameters.Add("@offset", offset);
            var query = "SELECT * FROM User OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY";
            using var connection = _context.CreateConnection();
            var users = await connection.QueryAsync<User>(query, parameters);
            return users;
        }


        public async Task<User> GetUserByID(string? UserId)
        {
            var query = "SELECT * FROM User WHERE UserId = @UserId";
            using var connection = _context.CreateConnection();
            var user = await connection.QuerySingleOrDefaultAsync<User>(query, new { UserId });
            return user.AsUserModel();
        }
        public async Task<User> GetUserByFullName(string? FullName)
        {
            var query = "SELECT * FROM User WHERE FullName = @FullName";
            using var connection = _context.CreateConnection();
            var user = await connection.QuerySingleOrDefaultAsync<User>(query, new { FullName });
            return user;
        }
        public async Task<User> GetUserByNumberPhone(string? NumberPhone)
        {
            var query = "SELECT * FROM User WHERE NumberPhone = @NumberPhone";
            using var connection = _context.CreateConnection();
            var user = await connection.QuerySingleOrDefaultAsync<User>(query, new { NumberPhone });
            return user;
        }
        public async Task<User> CreateUser(UserCreateModel user)
        {
            var query = "INSERT INTO User (UserId, FullName, Gender, DateOfBirth, IdentityCard, Position, NumberPhone, NumberBank, NameBank, BranchBank) VALUES (@UserId, @FullName, @Gender, @DateOfBirth, @IdentityCard, @Position, @NumberPhone, @NumberBank, @NameBank, @BranchBank)";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", user.UserId, DbType.String);
            parameters.Add("FullName", user.FullName, DbType.String);
            parameters.Add("Gender", user.Gender, DbType.String);
            parameters.Add("DateOfBirth", user.DateOfBirth, DbType.DateTime);
            parameters.Add("IdentityCard", user.IdentityCard, DbType.String);
            parameters.Add("Position", user.Position, DbType.String);
            parameters.Add("NumberPhone", user.NumberPhone, DbType.String);
            parameters.Add("NumberBank", user.NumberBank, DbType.String);
            parameters.Add("NameBank", user.NameBank, DbType.String);
            parameters.Add("BranchBank", user.BranchBank, DbType.String);
            using var connection = _context.CreateConnection();
            var id = await connection.QuerySingleAsync<int>(query, parameters);
            var createdUser = new User
            {
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
            return createdUser;
        }

        public async Task UpdateUser(string UserId, UserUpdateModel user)
        {
            var query = "UPDATE User SET FullName = @FullName, Gender = @Gender, DateOfBirth = @DateOfBirth, IdentityCard = @IdentityCard, Position = @Position, NumberPhone = @NumberPhone, NumberBank = @NumberBank, NameBank = @NameBank, BranchBank = @BranchBank WHERE UserId = @UserId";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", UserId);
            parameters.Add("FullName", user.FullName, DbType.String);
            parameters.Add("Gender", user.Gender, DbType.String);
            parameters.Add("DateOfBirth", user.DateOfBirth, DbType.DateTime);
            parameters.Add("IdentityCard", user.IdentityCard, DbType.String);
            parameters.Add("Position", user.Position, DbType.String);
            parameters.Add("NumberPhone", user.NumberPhone, DbType.String);
            parameters.Add("NumberBank", user.NumberBank, DbType.String);
            parameters.Add("NameBank", user.NameBank, DbType.String);
            parameters.Add("BranchBank", user.BranchBank, DbType.String);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteUser(string UserId)
        {
            var query = "DELETE FROM User WHERE UserId = @UserId";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, new { UserId });
        }
    }
}