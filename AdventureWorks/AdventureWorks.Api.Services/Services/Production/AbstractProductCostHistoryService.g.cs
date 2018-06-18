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
        public abstract class AbstractProductCostHistoryService: AbstractService
        {
                private IProductCostHistoryRepository productCostHistoryRepository;

                private IApiProductCostHistoryRequestModelValidator productCostHistoryModelValidator;

                private IBOLProductCostHistoryMapper bolProductCostHistoryMapper;

                private IDALProductCostHistoryMapper dalProductCostHistoryMapper;

                private ILogger logger;

                public AbstractProductCostHistoryService(
                        ILogger logger,
                        IProductCostHistoryRepository productCostHistoryRepository,
                        IApiProductCostHistoryRequestModelValidator productCostHistoryModelValidator,
                        IBOLProductCostHistoryMapper bolProductCostHistoryMapper,
                        IDALProductCostHistoryMapper dalProductCostHistoryMapper

                        )
                        : base()

                {
                        this.productCostHistoryRepository = productCostHistoryRepository;
                        this.productCostHistoryModelValidator = productCostHistoryModelValidator;
                        this.bolProductCostHistoryMapper = bolProductCostHistoryMapper;
                        this.dalProductCostHistoryMapper = dalProductCostHistoryMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProductCostHistoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.productCostHistoryRepository.All(limit, offset);

                        return this.bolProductCostHistoryMapper.MapBOToModel(this.dalProductCostHistoryMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProductCostHistoryResponseModel> Get(int productID)
                {
                        var record = await this.productCostHistoryRepository.Get(productID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolProductCostHistoryMapper.MapBOToModel(this.dalProductCostHistoryMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiProductCostHistoryResponseModel>> Create(
                        ApiProductCostHistoryRequestModel model)
                {
                        CreateResponse<ApiProductCostHistoryResponseModel> response = new CreateResponse<ApiProductCostHistoryResponseModel>(await this.productCostHistoryModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProductCostHistoryMapper.MapModelToBO(default (int), model);
                                var record = await this.productCostHistoryRepository.Create(this.dalProductCostHistoryMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProductCostHistoryMapper.MapBOToModel(this.dalProductCostHistoryMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int productID,
                        ApiProductCostHistoryRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.productCostHistoryModelValidator.ValidateUpdateAsync(productID, model));

                        if (response.Success)
                        {
                                var bo = this.bolProductCostHistoryMapper.MapModelToBO(productID, model);
                                await this.productCostHistoryRepository.Update(this.dalProductCostHistoryMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int productID)
                {
                        ActionResponse response = new ActionResponse(await this.productCostHistoryModelValidator.ValidateDeleteAsync(productID));

                        if (response.Success)
                        {
                                await this.productCostHistoryRepository.Delete(productID);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>f204892fb63bf909a106048534a1c9dd</Hash>
</Codenesium>*/