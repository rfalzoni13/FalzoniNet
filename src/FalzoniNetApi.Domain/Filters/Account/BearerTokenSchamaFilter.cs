using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FalzoniNetApi.Domain.Filters.Account
{
    public class BearerTokenSchamaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Title = "Token";
            schema.Description = "Objeto de retorno do Token";
            
            // Example Field
            //schema.Example = new OpenApiObject
            //{
            //    ["Token"] = new OpenApiString("XxXxXXXxxxXXxXxXxXXXXxxXXXxxxXXxX-XXxXXXxX-XXxXxXXXXXxxXXXXxxXX"),
            //    ["ExpiresIn"] = new OpenApiDateTime(new DateTime(2025, 7, 10, 00, 30, 00)),
            //};

            foreach (var item in schema.Properties)
            {
                switch (item.Key)
                {
                    case "token":
                        item.Value.Example = new OpenApiString("XxXxXXXxxxXXxXxXxXXXXxxXXXxxxXXxX-XXxXXXxX-XXxXxXXXXXxxXXXXxxXX");
                        break;
                    case "expiresIn":
                        item.Value.Example = new OpenApiDateTime(new DateTime(2025, 7, 10, 00, 30, 00));
                        break;
                }
            }
        }
    }
}
