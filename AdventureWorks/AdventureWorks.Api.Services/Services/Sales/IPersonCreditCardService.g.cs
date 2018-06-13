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

                Task<List<ApiPersonCreditCardResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>82cb4dc00cac3e66a16bf27e574e65cf</Hash>
</Codenesium>*/