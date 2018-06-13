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

                Task<List<ApiAWBuildVersionResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>84fab466f4a5bce64dfdc2fad9685dc9</Hash>
</Codenesium>*/