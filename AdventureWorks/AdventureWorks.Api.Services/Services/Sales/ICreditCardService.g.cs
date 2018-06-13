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

                Task<List<ApiCreditCardResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiCreditCardResponseModel> GetCardNumber(string cardNumber);

                Task<List<ApiPersonCreditCardResponseModel>> PersonCreditCards(int creditCardID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeaders(int creditCardID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>12772e282770d98bc8f2d9073091899b</Hash>
</Codenesium>*/