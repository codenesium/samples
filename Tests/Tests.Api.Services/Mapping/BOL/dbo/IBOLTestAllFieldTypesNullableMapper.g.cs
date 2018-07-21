using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface IBOLTestAllFieldTypesNullableMapper
        {
                BOTestAllFieldTypesNullable MapModelToBO(
                        int id,
                        ApiTestAllFieldTypesNullableRequestModel model);

                ApiTestAllFieldTypesNullableResponseModel MapBOToModel(
                        BOTestAllFieldTypesNullable boTestAllFieldTypesNullable);

                List<ApiTestAllFieldTypesNullableResponseModel> MapBOToModel(
                        List<BOTestAllFieldTypesNullable> items);
        }
}

/*<Codenesium>
    <Hash>0482a1103462ac60ef46714b9b36482e</Hash>
</Codenesium>*/