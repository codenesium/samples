using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface ICustomerService
        {
                Task<CreateResponse<ApiCustomerResponseModel>> Create(
                        ApiCustomerRequestModel model);

                Task<ActionResponse> Update(int customerID,
                                            ApiCustomerRequestModel model);

                Task<ActionResponse> Delete(int customerID);

                Task<ApiCustomerResponseModel> Get(int customerID);

                Task<List<ApiCustomerResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiCustomerResponseModel> GetAccountNumber(string accountNumber);
                Task<List<ApiCustomerResponseModel>> GetTerritoryID(Nullable<int> territoryID);
        }
}

/*<Codenesium>
    <Hash>0ae06efb07e343fec8d0ce351e36b1f7</Hash>
</Codenesium>*/