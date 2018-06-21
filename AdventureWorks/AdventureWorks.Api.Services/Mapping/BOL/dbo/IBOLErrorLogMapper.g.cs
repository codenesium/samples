using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLErrorLogMapper
        {
                BOErrorLog MapModelToBO(
                        int errorLogID,
                        ApiErrorLogRequestModel model);

                ApiErrorLogResponseModel MapBOToModel(
                        BOErrorLog boErrorLog);

                List<ApiErrorLogResponseModel> MapBOToModel(
                        List<BOErrorLog> items);
        }
}

/*<Codenesium>
    <Hash>14b298db7691f535627aa6e183ca67d0</Hash>
</Codenesium>*/