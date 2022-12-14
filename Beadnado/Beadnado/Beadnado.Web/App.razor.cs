using Avalonia.Web.Blazor;

namespace Beadnado.Web;

public partial class App
{
    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        WebAppBuilder.Configure<Beadnado.App>()
            .SetupWithSingleViewLifetime();
    }
}