using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IEmailAddressService
        {
                Task<CreateResponse<ApiEmailAddressResponseModel>> Create(
                        ApiEmailAddressRequestModel model);

                Task<ActionResponse> Update(int businessEntityID,
                                            ApiEmailAddressRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiEmailAddressResponseModel> Get(int businessEntityID);

                Task<List<ApiEmailAddressResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiEmailAddressResponseModel>> ByEmailAddress(string emailAddress1);
        }
}

/*<Codenesium>
    <Hash>2f3fa6671e67ff665585d1ceeed1fd3d</Hash>
</Codenesium>*/