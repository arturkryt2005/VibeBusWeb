using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace VibeBusWeb.Api;

public class PrefixDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        foreach (var path in swaggerDoc.Paths.ToList())
        {
            swaggerDoc.Paths.Remove(path.Key);
            var newPathKey = "/mentors-diary-api" + path.Key;
            swaggerDoc.Paths.Add(newPathKey, path.Value);
        }
    }
}