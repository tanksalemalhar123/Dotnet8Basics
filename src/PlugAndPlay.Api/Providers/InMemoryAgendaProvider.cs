using PlugAndPlay.Api.Models;

namespace PlugAndPlay.Api.Providers;

public interface IAgendaProvider
{
    IEnumerable<Agenda> GetAll();
    void Add(Agenda agenda);
}

public class InMemoryAgendaProvider : IAgendaProvider
{
    private readonly List<Agenda> _store = new()
    {
        new Agenda(Guid.NewGuid(), "Daily Standup", "Discuss progress and blockers"),
        new Agenda(Guid.NewGuid(), "Sprint Planning", "Plan next sprint work")
    };

    public IEnumerable<Agenda> GetAll() => _store;

    public void Add(Agenda agenda) => _store.Add(agenda);
}
