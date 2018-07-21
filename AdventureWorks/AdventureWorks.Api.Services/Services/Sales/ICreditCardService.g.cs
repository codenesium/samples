using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface ICreditCardService
        {
                Task<CreateResponse<ApiCreditCardResponseModel>> Create(
                        ApiCreditCardRequestModel model);

                Task<UpdateResponse<ApiCreditCardResponseModel>> Update(int creditCardID,
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
    <Hash>8aceb8965c27c32eac4e3e12aae592d3</Hash>
</Codenesium>*/