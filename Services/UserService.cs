using MongoDB.Driver;

public class UserService
{
    private readonly IMongoCollection<UserModel> _users;

    public UserService(IMongoClient client, string databaseName)
    {
        var database = client.GetDatabase(databaseName);
        _users = database.GetCollection<UserModel>("Users");
    }

    public async Task<UserModel> GetUserByUsername(string username)
    {
        return await _users.Find(user => user.Username == username).FirstOrDefaultAsync();
    }

    public async Task CreateUser(UserModel user)
    {
        await _users.InsertOneAsync(user);
    }
}
