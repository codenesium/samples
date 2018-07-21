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
        public abstract class AbstractProductListPriceHistoryService : AbstractService
        {
                private IProductListPriceHistoryRepository productListPriceHistoryRepository;

                private IApiProductListPriceHistoryRequestModelValidator productListPriceHistoryModelValidator;

                private IBOLProductListPriceHistoryMapper bolProductListPriceHistoryMapper;

                private IDALProductListPriceHistoryMapper dalProductListPriceHistoryMapper;

                private ILogger logger;

                public AbstractProductListPriceHistoryService(
                        ILogger logger,
                        IProductListPriceHistoryRepository productListPriceHistoryRepository,
                        IApiProductListPriceHistoryRequestModelValidator productListPriceHistoryModelValidator,
                        IBOLProductListPriceHistoryMapper bolProductListPriceHistoryMapper,
                        IDALProductListPriceHistoryMapper dalProductListPriceHistoryMapper)
                        : base()
                {
                        this.productListPriceHistoryRepository = productListPriceHistoryRepository;
                        this.productListPriceHistoryModelValidator = productListPriceHistoryModelValidator;
                        this.bolProductListPriceHistoryMapper = bolProductListPriceHistoryMapper;
                        this.dalProductListPriceHistoryMapper = dalProductListPriceHistoryMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProductListPriceHistoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.productListPriceHistoryRepository.All(limit, offset);

                        return this.bolProductListPriceHistoryMapper.MapBOToModel(this.dalProductListPriceHistoryMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProductListPriceHistoryResponseModel> Get(int productID)
                {
                        var record = await this.productListPriceHistoryRepository.Get(productID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolProductListPriceHistoryMapper.MapBOToModel(this.dalProductListPriceHistoryMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiProductListPriceHistoryResponseModel>> Create(
                        ApiProductListPriceHistoryRequestModel model)
                {
                        CreateResponse<ApiProductListPriceHistoryResponseModel> response = new CreateResponse<ApiProductListPriceHistoryResponseModel>(await this.productListPriceHistoryModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProductListPriceHistoryMapper.MapModelToBO(default(int), model);
                                var record = await this.productListPriceHistoryRepository.Create(this.dalProductListPriceHistoryMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProductListPriceHistoryMapper.MapBOToModel(this.dalProductListPriceHistoryMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiProductListPriceHistoryResponseModel>> Update(
                        int productID,
                        ApiProductListPriceHistoryRequestModel model)
                {
                        var validationResult = await this.productListPriceHistoryModelValidator.ValidateUpdateAsync(productID, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolProductListPriceHistoryMapper.MapModelToBO(productID, model);
                                await this.productListPriceHistoryRepository.Update(this.dalProductListPriceHistoryMapper.MapBOToEF(bo));

                                var record = await this.productListPriceHistoryRepository.Get(productID);

                                return new UpdateResponse<ApiProductListPriceHistoryResponseModel>(this.bolProductListPriceHistoryMapper.MapBOToModel(this.dalProductListPriceHistoryMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiProductListPriceHistoryResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int productID)
                {
                        ActionResponse response = new ActionResponse(await this.productListPriceHistoryModelValidator.ValidateDeleteAsync(productID));
                        if (response.Success)
                        {
                                await this.productListPriceHistoryRepository.Delete(productID);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>1e48594933e977ffa2dc6daf08b30124</Hash>
</Codenesium>*/