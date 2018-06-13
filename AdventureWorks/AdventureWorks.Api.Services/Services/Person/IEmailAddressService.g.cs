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

                Task<List<ApiEmailAddressResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiEmailAddressResponseModel>> GetEmailAddress(string emailAddress1);
        }
}

/*<Codenesium>
    <Hash>ac5c7e0d5c92755c3bbf4d253bce2c18</Hash>
</Codenesium>*/