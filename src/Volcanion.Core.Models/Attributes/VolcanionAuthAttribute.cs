namespace Volcanion.Core.Models.Attributes;

/// <summary>
/// VolcanionAuthAttribute
/// </summary>
/// <param name="roles"></param>
public class VolcanionAuthAttribute(string[] roles) : Attribute
{
    /// <summary>
    /// Roles
    /// </summary>
    public string[] Roles { get; set; } = roles;
}
