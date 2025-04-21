using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Routing;

namespace Volcanion.Core.Presentation.Helpers;

public class SlugifyRouteTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object value)
    {
        if (value == null) return null;

        return Regex.Replace(value.ToString()!, "([a-z])([A-Z])", "$1-$2").ToLower();
    }
}
