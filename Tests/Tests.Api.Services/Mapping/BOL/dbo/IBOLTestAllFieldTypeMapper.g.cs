using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface IBOLTestAllFieldTypeMapper
        {
                BOTestAllFieldType MapModelToBO(
                        int id,
                        ApiTestAllFieldTypeRequestModel model);

                ApiTestAllFieldTypeResponseModel MapBOToModel(
                        BOTestAllFieldType boTestAllFieldType);

                List<ApiTestAllFieldTypeResponseModel> MapBOToModel(
                        List<BOTestAllFieldType> items);
        }
}

/*<Codenesium>
    <Hash>0c201958a1429dd42348a688a2f4a136</Hash>
</Codenesium>*/