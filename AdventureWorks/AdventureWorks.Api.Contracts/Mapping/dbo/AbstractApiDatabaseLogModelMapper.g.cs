using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiDatabaseLogModelMapper
        {
                public virtual ApiDatabaseLogResponseModel MapRequestToResponse(
                        int databaseLogID,
                        ApiDatabaseLogRequestModel request)
                {
                        var response = new ApiDatabaseLogResponseModel();
                        response.SetProperties(databaseLogID,
                                               request.DatabaseUser,
                                               request.@Event,
                                               request.@Object,
                                               request.PostTime,
                                               request.Schema,
                                               request.TSQL,
                                               request.XmlEvent);
                        return response;
                }

                public virtual ApiDatabaseLogRequestModel MapResponseToRequest(
                        ApiDatabaseLogResponseModel response)
                {
                        var request = new ApiDatabaseLogRequestModel();
                        request.SetProperties(
                                response.DatabaseUser,
                                response.@Event,
                                response.@Object,
                                response.PostTime,
                                response.Schema,
                                response.TSQL,
                                response.XmlEvent);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>01e3ad894dc5108fdecbcbbedfd1646c</Hash>
</Codenesium>*/