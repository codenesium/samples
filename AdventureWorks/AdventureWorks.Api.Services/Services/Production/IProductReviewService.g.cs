using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IProductReviewService
        {
                Task<CreateResponse<ApiProductReviewResponseModel>> Create(
                        ApiProductReviewRequestModel model);

                Task<ActionResponse> Update(int productReviewID,
                                            ApiProductReviewRequestModel model);

                Task<ActionResponse> Delete(int productReviewID);

                Task<ApiProductReviewResponseModel> Get(int productReviewID);

                Task<List<ApiProductReviewResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiProductReviewResponseModel>> ByCommentsProductIDReviewerName(string comments, int productID, string reviewerName);
        }
}

/*<Codenesium>
    <Hash>39e284820234638bd457aa1ad7fac20e</Hash>
</Codenesium>*/