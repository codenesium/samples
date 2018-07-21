using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IPersonCreditCardService
        {
                Task<CreateResponse<ApiPersonCreditCardResponseModel>> Create(
                        ApiPersonCreditCardRequestModel model);

                Task<UpdateResponse<ApiPersonCreditCardResponseModel>> Update(int businessEntityID,
                                                                               ApiPersonCreditCardRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiPersonCreditCardResponseModel> Get(int businessEntityID);

                Task<List<ApiPersonCreditCardResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>27a32dfb87f027b646ed4c61d1f6445c</Hash>
</Codenesium>*/