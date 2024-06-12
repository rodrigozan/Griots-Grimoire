using MongoDB.Driver;

public class UserService
{
    private readonly IMongoCollection<UserModel> _userCollection;

    public UserService(IMongoClient client)
    {
        var database = client.GetDatabase("GriotsGrimoire");
        _userCollection = database.GetCollection<UserModel>("Users");
    }

    public async Task<UserModel> GetUserByUsername(string username)
    {
        return await _userCollection.Find(user => user.Username == username).FirstOrDefaultAsync();
    }

    public async Task CreateUser(UserModel user)
    {
        await _userCollection.InsertOneAsync(user);
    }
}
