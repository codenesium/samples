using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IBusinessEntityContactService
        {
                Task<CreateResponse<ApiBusinessEntityContactResponseModel>> Create(
                        ApiBusinessEntityContactRequestModel model);

                Task<ActionResponse> Update(int businessEntityID,
                                            ApiBusinessEntityContactRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiBusinessEntityContactResponseModel> Get(int businessEntityID);

                Task<List<ApiBusinessEntityContactResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiBusinessEntityContactResponseModel>> ByContactTypeID(int contactTypeID);

                Task<List<ApiBusinessEntityContactResponseModel>> ByPersonID(int personID);
        }
}

/*<Codenesium>
    <Hash>3d4894ee2caf70488b39991f8a250bc3</Hash>
</Codenesium>*/