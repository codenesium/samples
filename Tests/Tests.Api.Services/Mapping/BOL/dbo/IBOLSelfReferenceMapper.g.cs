using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface IBOLSelfReferenceMapper
        {
                BOSelfReference MapModelToBO(
                        int id,
                        ApiSelfReferenceRequestModel model);

                ApiSelfReferenceResponseModel MapBOToModel(
                        BOSelfReference boSelfReference);

                List<ApiSelfReferenceResponseModel> MapBOToModel(
                        List<BOSelfReference> items);
        }
}

/*<Codenesium>
    <Hash>7a4ea7f83227fb9f1414bd559ef54cf6</Hash>
</Codenesium>*/