using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IShipMethodService
        {
                Task<CreateResponse<ApiShipMethodResponseModel>> Create(
                        ApiShipMethodRequestModel model);

                Task<ActionResponse> Update(int shipMethodID,
                                            ApiShipMethodRequestModel model);

                Task<ActionResponse> Delete(int shipMethodID);

                Task<ApiShipMethodResponseModel> Get(int shipMethodID);

                Task<List<ApiShipMethodResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiShipMethodResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>a43e19af0da97ddd968695b17ceed436</Hash>
</Codenesium>*/