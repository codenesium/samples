using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IAWBuildVersionService
        {
                Task<CreateResponse<ApiAWBuildVersionResponseModel>> Create(
                        ApiAWBuildVersionRequestModel model);

                Task<ActionResponse> Update(int systemInformationID,
                                            ApiAWBuildVersionRequestModel model);

                Task<ActionResponse> Delete(int systemInformationID);

                Task<ApiAWBuildVersionResponseModel> Get(int systemInformationID);

                Task<List<ApiAWBuildVersionResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>91a3b14029146ad0cbeadeeda01a6ccf</Hash>
</Codenesium>*/