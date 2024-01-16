using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NewApi.Models;
using NewWeb.Settings;

namespace NewWeb.Services;

public class TeamService
{
    private readonly IMongoCollection<Team> _teams;
    public TeamService(IOptions<DatabaseSetting> setting)
    {
        MongoClient mongoClient = new MongoClient(setting.Value.ConnectionString); 
        var database = mongoClient.GetDatabase(setting.Value.DatabaseName);
        _teams = database.GetCollection<Team>(setting.Value.CollectionName);
    }
    public Team Create(Team team)
    {
        _teams.InsertOne(team);
        return team;
    }
    public List<Team> Get()
    {
        return _teams.Find(_ => true).ToList();
    }
    public Team Get(string id)
    {
        return _teams.Find(team => team.Id == id).FirstOrDefault();
    }
    public void Delete(string id)
    {
        _teams.DeleteOne(team => team.Id == id);
    }
    public void Update(string id, string country)
    {
        var filter = Builders<Team>.Filter.Eq(t => t.Id, id);
        var update = Builders<Team>.Update.Set(t => t.Country, country);
        _teams.UpdateOne(filter, update);
    }
}