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

                Task<List<ApiProductReviewResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiProductReviewResponseModel>> GetCommentsProductIDReviewerName(string comments, int productID, string reviewerName);
        }
}

/*<Codenesium>
    <Hash>910db6fa2dd18ae823fe1a551ec0e4d0</Hash>
</Codenesium>*/