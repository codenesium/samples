using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface ISalesReasonService
        {
                Task<CreateResponse<ApiSalesReasonResponseModel>> Create(
                        ApiSalesReasonRequestModel model);

                Task<ActionResponse> Update(int salesReasonID,
                                            ApiSalesReasonRequestModel model);

                Task<ActionResponse> Delete(int salesReasonID);

                Task<ApiSalesReasonResponseModel> Get(int salesReasonID);

                Task<List<ApiSalesReasonResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>da3af608f7b0e2309f780fdbf941ddb4</Hash>
</Codenesium>*/