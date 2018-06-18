using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface ICreditCardService
        {
                Task<CreateResponse<ApiCreditCardResponseModel>> Create(
                        ApiCreditCardRequestModel model);

                Task<ActionResponse> Update(int creditCardID,
                                            ApiCreditCardRequestModel model);

                Task<ActionResponse> Delete(int creditCardID);

                Task<ApiCreditCardResponseModel> Get(int creditCardID);

                Task<List<ApiCreditCardResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiCreditCardResponseModel> ByCardNumber(string cardNumber);

                Task<List<ApiPersonCreditCardResponseModel>> PersonCreditCards(int creditCardID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaders(int creditCardID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>23ac6400bad99e018cc12be565ef079b</Hash>
</Codenesium>*/