using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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

                Task<List<ApiAWBuildVersionResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>2318477765ab07f793ecfc2412817830</Hash>
</Codenesium>*/