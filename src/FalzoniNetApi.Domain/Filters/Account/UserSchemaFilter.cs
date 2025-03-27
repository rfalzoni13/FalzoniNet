using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FalzoniNetApi.Domain.Filters.Account
{
    public class UserSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Title = "User";
            schema.Description = "Objeto do Usuário";
            
            // Example Field
            //schema.Example = new OpenApiObject
            //{
            //    ["Id"] = new OpenApiString("XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"),
            //    ["FullName"] = new OpenApiString("User Test"),
            //    ["UserName"] = new OpenApiString("userTest"),
            //    ["Email"] = new OpenApiString("user@test.com"),
            //    ["PhoneNumber"] = new OpenApiString("(11) 99999-7777"),
            //    ["Password"] = new OpenApiString("123456")
            //};

            foreach (var item in schema.Properties)
            {
                switch (item.Key)
                {
                    case "id":
                        item.Value.Example = new OpenApiString("XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX");
                        break;
                    case "fullName":
                        item.Value.Example = new OpenApiString("User Customer");
                        break;
                    case "userName":
                        item.Value.Example = new OpenApiString("userTest");
                        break;
                    case "email":
                        item.Value.Example = new OpenApiString("user@test.com");
                        break;
                    case "phoneNumber":
                        item.Value.Example = new OpenApiString("(11) 99999-7777");
                        break;
                    case "password":
                        item.Value.Example = new OpenApiString("123456");
                        break;
                }
            }
        }
    }
}
