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

                Task<UpdateResponse<ApiAWBuildVersionResponseModel>> Update(int systemInformationID,
                                                                             ApiAWBuildVersionRequestModel model);

                Task<ActionResponse> Delete(int systemInformationID);

                Task<ApiAWBuildVersionResponseModel> Get(int systemInformationID);

                Task<List<ApiAWBuildVersionResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>6e7354e38caa9c18cd83682b61e31ce9</Hash>
</Codenesium>*/