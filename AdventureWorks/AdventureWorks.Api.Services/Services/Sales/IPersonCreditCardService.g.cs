using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IPersonCreditCardService
        {
                Task<CreateResponse<ApiPersonCreditCardResponseModel>> Create(
                        ApiPersonCreditCardRequestModel model);

                Task<ActionResponse> Update(int businessEntityID,
                                            ApiPersonCreditCardRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiPersonCreditCardResponseModel> Get(int businessEntityID);

                Task<List<ApiPersonCreditCardResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>39612767bf80b7f31aa375586b1f6750</Hash>
</Codenesium>*/