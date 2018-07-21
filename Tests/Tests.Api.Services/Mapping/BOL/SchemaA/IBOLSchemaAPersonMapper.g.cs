using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface IBOLSchemaAPersonMapper
        {
                BOSchemaAPerson MapModelToBO(
                        int id,
                        ApiSchemaAPersonRequestModel model);

                ApiSchemaAPersonResponseModel MapBOToModel(
                        BOSchemaAPerson boSchemaAPerson);

                List<ApiSchemaAPersonResponseModel> MapBOToModel(
                        List<BOSchemaAPerson> items);
        }
}

/*<Codenesium>
    <Hash>a574e3926e1d5a8f6147c0e23b2a1b26</Hash>
</Codenesium>*/