using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>71c72d65f9b49b38f4944685bd59855e</Hash>
</Codenesium>*/