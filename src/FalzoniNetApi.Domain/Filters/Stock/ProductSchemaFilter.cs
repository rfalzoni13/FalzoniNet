using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FalzoniNetApi.Domain.Filters.Stock
{
    public class ProductSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Title = "Product";
            schema.Description = "Objeto do Produto";
            
            // Example Field
            //schema.Example = new OpenApiObject
            //{
            //    ["Id"] = new OpenApiString("XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"),
            //    ["Name"] = new OpenApiString("Notebook Gamer"),
            //    ["Price"] = new OpenApiDouble(100.00),
            //    ["Discount"] = new OpenApiDouble(5.00),
            //    ["Created"] = new OpenApiDateTime(new DateTime(2023, 5, 10, 13, 44, 21)),
            //    ["Modified"] = new OpenApiDateTime(new DateTime(2023, 8, 30, 9, 14, 17)),
            //};

            foreach (var item in schema.Properties)
            {
                switch (item.Key)
                {
                    case "id":
                        item.Value.Example = new OpenApiString("XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX");
                        break;
                    case "name":
                        item.Value.Example = new OpenApiString("Notebook Gamer");
                        break;
                    case "price":
                        item.Value.Example = new OpenApiDouble(100.00);
                        break;
                    case "discount":
                        item.Value.Example = new OpenApiDouble(5.00);
                        break;
                    case "created":
                        item.Value.Example = new OpenApiDateTime(new DateTime(2023, 5, 10, 13, 44, 21));
                        break;
                    case "modified":
                        item.Value.Example = new OpenApiDateTime(new DateTime(2023, 8, 30, 9, 14, 17));
                        break;
                }
            }
        }
    }
}
