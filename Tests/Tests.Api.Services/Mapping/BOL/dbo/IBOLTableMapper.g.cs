using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface IBOLTableMapper
        {
                BOTable MapModelToBO(
                        int id,
                        ApiTableRequestModel model);

                ApiTableResponseModel MapBOToModel(
                        BOTable boTable);

                List<ApiTableResponseModel> MapBOToModel(
                        List<BOTable> items);
        }
}

/*<Codenesium>
    <Hash>cc6765a3087c1dd7fb80ee992f1e087a</Hash>
</Codenesium>*/