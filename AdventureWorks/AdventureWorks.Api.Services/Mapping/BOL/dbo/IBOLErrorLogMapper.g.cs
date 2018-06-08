using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>01fe9b80cf72d78226e0db463bbb2602</Hash>
</Codenesium>*/