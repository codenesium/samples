using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface IBOLSchemaBPersonMapper
        {
                BOSchemaBPerson MapModelToBO(
                        int id,
                        ApiSchemaBPersonRequestModel model);

                ApiSchemaBPersonResponseModel MapBOToModel(
                        BOSchemaBPerson boSchemaBPerson);

                List<ApiSchemaBPersonResponseModel> MapBOToModel(
                        List<BOSchemaBPerson> items);
        }
}

/*<Codenesium>
    <Hash>65d655562bb66806fe54a0cfaa80eae6</Hash>
</Codenesium>*/