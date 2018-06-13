using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractProductReviewService: AbstractService
        {
                private IProductReviewRepository productReviewRepository;

                private IApiProductReviewRequestModelValidator productReviewModelValidator;

                private IBOLProductReviewMapper bolProductReviewMapper;

                private IDALProductReviewMapper dalProductReviewMapper;

                private ILogger logger;

                public AbstractProductReviewService(
                        ILogger logger,
                        IProductReviewRepository productReviewRepository,
                        IApiProductReviewRequestModelValidator productReviewModelValidator,
                        IBOLProductReviewMapper bolProductReviewMapper,
                        IDALProductReviewMapper dalProductReviewMapper

                        )
                        : base()

                {
                        this.productReviewRepository = productReviewRepository;
                        this.productReviewModelValidator = productReviewModelValidator;
                        this.bolProductReviewMapper = bolProductReviewMapper;
                        this.dalProductReviewMapper = dalProductReviewMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProductReviewResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.productReviewRepository.All(limit, offset, orderClause);

                        return this.bolProductReviewMapper.MapBOToModel(this.dalProductReviewMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProductReviewResponseModel> Get(int productReviewID)
                {
                        var record = await this.productReviewRepository.Get(productReviewID);

                        return this.bolProductReviewMapper.MapBOToModel(this.dalProductReviewMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiProductReviewResponseModel>> Create(
                        ApiProductReviewRequestModel model)
                {
                        CreateResponse<ApiProductReviewResponseModel> response = new CreateResponse<ApiProductReviewResponseModel>(await this.productReviewModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProductReviewMapper.MapModelToBO(default (int), model);
                                var record = await this.productReviewRepository.Create(this.dalProductReviewMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProductReviewMapper.MapBOToModel(this.dalProductReviewMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int productReviewID,
                        ApiProductReviewRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.productReviewModelValidator.ValidateUpdateAsync(productReviewID, model));

                        if (response.Success)
                        {
                                var bo = this.bolProductReviewMapper.MapModelToBO(productReviewID, model);
                                await this.productReviewRepository.Update(this.dalProductReviewMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int productReviewID)
                {
                        ActionResponse response = new ActionResponse(await this.productReviewModelValidator.ValidateDeleteAsync(productReviewID));

                        if (response.Success)
                        {
                                await this.productReviewRepository.Delete(productReviewID);
                        }

                        return response;
                }

                public async Task<List<ApiProductReviewResponseModel>> GetCommentsProductIDReviewerName(string comments, int productID, string reviewerName)
                {
                        List<ProductReview> records = await this.productReviewRepository.GetCommentsProductIDReviewerName(comments, productID, reviewerName);

                        return this.bolProductReviewMapper.MapBOToModel(this.dalProductReviewMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>90c4d67dee5d811bc8cb19a9f96357e1</Hash>
</Codenesium>*/