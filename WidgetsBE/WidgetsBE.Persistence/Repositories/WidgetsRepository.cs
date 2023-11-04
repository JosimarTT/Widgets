using WidgetsBE.Persistence.Models;

namespace WidgetsBE.Persistence.Repositories;

public class WidgetsRepository : IWidgetsRepository
{
    public async Task<List<Widget>> GetWidgets()
    {
        await Task.Delay(1000);
        return GenerateWidgets();
    }

    private List<Widget> GenerateWidgets()
    {
        return new List<Widget>
        {
            new Widget { Id = Guid.NewGuid() },
            new Widget { Id = Guid.NewGuid() },
            new Widget { Id = Guid.NewGuid() },
            new Widget { Id = Guid.NewGuid() },
            new Widget { Id = Guid.NewGuid() },
            new Widget { Id = Guid.NewGuid() },
        };
    }
}

public interface IWidgetsRepository
{
    Task<List<Widget>> GetWidgets();
}