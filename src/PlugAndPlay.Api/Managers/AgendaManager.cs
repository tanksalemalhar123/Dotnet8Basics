using PlugAndPlay.Api.DTOs;
using PlugAndPlay.Api.Models;
using PlugAndPlay.Api.Providers;

namespace PlugAndPlay.Api.Managers;

public class AgendaManager
{
    private readonly IAgendaProvider _provider;

    public AgendaManager(IAgendaProvider provider)
    {
        _provider = provider;
    }

    public Task<ManagerResult<List<AgendaDto>>> GetAllAgendasAsync()
    {
        var agendas = _provider.GetAll()
            .Select(a => new AgendaDto(a.Id, a.Title, a.Description))
            .ToList();

        return Task.FromResult(new ManagerResult<List<AgendaDto>>(agendas, true, "OK"));
    }

    public Task<ManagerResult<AgendaDto>> GetAgendaByIdAsync(Guid id)
    {
        var a = _provider.GetAll().FirstOrDefault(x => x.Id == id);
        if (a == null)
            return Task.FromResult(new ManagerResult<AgendaDto>(null, false, "Not found"));

        var dto = new AgendaDto(a.Id, a.Title, a.Description);
        return Task.FromResult(new ManagerResult<AgendaDto>(dto, true, "OK"));
    }

    public Task<ManagerResult<AgendaDto>> CreateAgendaAsync(AgendaDto dto)
    {
        var model = new Agenda(Guid.NewGuid(), dto.Title, dto.Description);
        _provider.Add(model);

        var created = new AgendaDto(model.Id, model.Title, model.Description);
        return Task.FromResult(new ManagerResult<AgendaDto>(created, true, "Created"));
    }
}
