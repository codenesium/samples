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
        public abstract class AbstractProductInventoryService: AbstractService
        {
                private IProductInventoryRepository productInventoryRepository;

                private IApiProductInventoryRequestModelValidator productInventoryModelValidator;

                private IBOLProductInventoryMapper bolProductInventoryMapper;

                private IDALProductInventoryMapper dalProductInventoryMapper;

                private ILogger logger;

                public AbstractProductInventoryService(
                        ILogger logger,
                        IProductInventoryRepository productInventoryRepository,
                        IApiProductInventoryRequestModelValidator productInventoryModelValidator,
                        IBOLProductInventoryMapper bolProductInventoryMapper,
                        IDALProductInventoryMapper dalProductInventoryMapper

                        )
                        : base()

                {
                        this.productInventoryRepository = productInventoryRepository;
                        this.productInventoryModelValidator = productInventoryModelValidator;
                        this.bolProductInventoryMapper = bolProductInventoryMapper;
                        this.dalProductInventoryMapper = dalProductInventoryMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProductInventoryResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.productInventoryRepository.All(limit, offset, orderClause);

                        return this.bolProductInventoryMapper.MapBOToModel(this.dalProductInventoryMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProductInventoryResponseModel> Get(int productID)
                {
                        var record = await this.productInventoryRepository.Get(productID);

                        return this.bolProductInventoryMapper.MapBOToModel(this.dalProductInventoryMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiProductInventoryResponseModel>> Create(
                        ApiProductInventoryRequestModel model)
                {
                        CreateResponse<ApiProductInventoryResponseModel> response = new CreateResponse<ApiProductInventoryResponseModel>(await this.productInventoryModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProductInventoryMapper.MapModelToBO(default (int), model);
                                var record = await this.productInventoryRepository.Create(this.dalProductInventoryMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProductInventoryMapper.MapBOToModel(this.dalProductInventoryMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int productID,
                        ApiProductInventoryRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.productInventoryModelValidator.ValidateUpdateAsync(productID, model));

                        if (response.Success)
                        {
                                var bo = this.bolProductInventoryMapper.MapModelToBO(productID, model);
                                await this.productInventoryRepository.Update(this.dalProductInventoryMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int productID)
                {
                        ActionResponse response = new ActionResponse(await this.productInventoryModelValidator.ValidateDeleteAsync(productID));

                        if (response.Success)
                        {
                                await this.productInventoryRepository.Delete(productID);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>40813c26399b4e5ec3efea9bba4563cc</Hash>
</Codenesium>*/