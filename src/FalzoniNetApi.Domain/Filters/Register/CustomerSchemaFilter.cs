using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FalzoniNetApi.Domain.Filters.Register
{
    public class CustomerSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Title = "Customer";
            schema.Type = "object";
            schema.Description = "Objeto do Cliente";
            
            // Example Field
            //schema.Example = new OpenApiObject
            //{
            //    ["Id"] = new OpenApiString("XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"),
            //    ["Name"] = new OpenApiString("Test Customer"),
            //    ["Document"] = new OpenApiString("123.456.789-00"),
            //    ["Created"] = new OpenApiDateTime(new DateTime(2025, 1, 5, 18, 31, 55)),
            //    ["Modified"] = new OpenApiDateTime(new DateTime(2025, 1, 6, 7, 4, 3)),
            //};

            foreach(var item in schema.Properties)
            {
                switch(item.Key)
                {
                    case "id":
                        item.Value.Example = new OpenApiString("XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX");
                        break;
                    case "name":
                        item.Value.Example = new OpenApiString("Test Customer");
                        break;
                    case "document":
                        item.Value.Example = new OpenApiString("123.456.789-00");
                        break;
                    case "created":
                        item.Value.Example = new OpenApiDateTime(new DateTime(2025, 1, 5, 18, 31, 55));
                        break;
                    case "modified":
                        item.Value.Example = new OpenApiDateTime(new DateTime(2025, 1, 6, 7, 4, 3));
                        break;
                }
            }
        }
    }
}
