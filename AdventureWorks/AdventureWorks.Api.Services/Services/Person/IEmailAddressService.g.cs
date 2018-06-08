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

                Task<List<ApiEmailAddressResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ApiEmailAddressResponseModel>> GetEmailAddress(string emailAddress1);
        }
}

/*<Codenesium>
    <Hash>c702379f8e7f0e8f4f37bdd51f471cc3</Hash>
</Codenesium>*/