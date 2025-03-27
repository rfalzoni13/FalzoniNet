using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FalzoniNetApi.Domain.Filters.Account
{
    public class LoginSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Title = "Login";
            schema.Description = "Objeto do Login";
            
            // Example Field
            //schema.Example = new OpenApiObject
            //{
            //    ["UserName"] = new OpenApiString("userTest"),
            //    ["Password"] = new OpenApiString("123456")
            //};

            foreach (var item in schema.Properties)
            {
                switch (item.Key)
                {
                    case "userName":
                        item.Value.Example = new OpenApiString("userTest");
                        break;
                    case "password":
                        item.Value.Example = new OpenApiString("123456");
                        break;
                }
            }
        }
    }
}
