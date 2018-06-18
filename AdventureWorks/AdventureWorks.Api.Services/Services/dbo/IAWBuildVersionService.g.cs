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

                Task<List<ApiAWBuildVersionResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>c0a1d3b3a8ed49980eed9c35bfd043d9</Hash>
</Codenesium>*/