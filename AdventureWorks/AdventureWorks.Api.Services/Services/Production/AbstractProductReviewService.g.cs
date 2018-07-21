using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractProductReviewService : AbstractService
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
                        IDALProductReviewMapper dalProductReviewMapper)
                        : base()
                {
                        this.productReviewRepository = productReviewRepository;
                        this.productReviewModelValidator = productReviewModelValidator;
                        this.bolProductReviewMapper = bolProductReviewMapper;
                        this.dalProductReviewMapper = dalProductReviewMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProductReviewResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.productReviewRepository.All(limit, offset);

                        return this.bolProductReviewMapper.MapBOToModel(this.dalProductReviewMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProductReviewResponseModel> Get(int productReviewID)
                {
                        var record = await this.productReviewRepository.Get(productReviewID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolProductReviewMapper.MapBOToModel(this.dalProductReviewMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiProductReviewResponseModel>> Create(
                        ApiProductReviewRequestModel model)
                {
                        CreateResponse<ApiProductReviewResponseModel> response = new CreateResponse<ApiProductReviewResponseModel>(await this.productReviewModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProductReviewMapper.MapModelToBO(default(int), model);
                                var record = await this.productReviewRepository.Create(this.dalProductReviewMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProductReviewMapper.MapBOToModel(this.dalProductReviewMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiProductReviewResponseModel>> Update(
                        int productReviewID,
                        ApiProductReviewRequestModel model)
                {
                        var validationResult = await this.productReviewModelValidator.ValidateUpdateAsync(productReviewID, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolProductReviewMapper.MapModelToBO(productReviewID, model);
                                await this.productReviewRepository.Update(this.dalProductReviewMapper.MapBOToEF(bo));

                                var record = await this.productReviewRepository.Get(productReviewID);

                                return new UpdateResponse<ApiProductReviewResponseModel>(this.bolProductReviewMapper.MapBOToModel(this.dalProductReviewMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiProductReviewResponseModel>(validationResult);
                        }
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

                public async Task<List<ApiProductReviewResponseModel>> ByProductIDReviewerName(int productID, string reviewerName)
                {
                        List<ProductReview> records = await this.productReviewRepository.ByProductIDReviewerName(productID, reviewerName);

                        return this.bolProductReviewMapper.MapBOToModel(this.dalProductReviewMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>3c5e6928873c093ebbdf888f647993d3</Hash>
</Codenesium>*/