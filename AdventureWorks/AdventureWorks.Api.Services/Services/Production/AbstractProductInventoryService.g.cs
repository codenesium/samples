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
        public abstract class AbstractProductInventoryService : AbstractService
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
                        IDALProductInventoryMapper dalProductInventoryMapper)
                        : base()
                {
                        this.productInventoryRepository = productInventoryRepository;
                        this.productInventoryModelValidator = productInventoryModelValidator;
                        this.bolProductInventoryMapper = bolProductInventoryMapper;
                        this.dalProductInventoryMapper = dalProductInventoryMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProductInventoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.productInventoryRepository.All(limit, offset);

                        return this.bolProductInventoryMapper.MapBOToModel(this.dalProductInventoryMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProductInventoryResponseModel> Get(int productID)
                {
                        var record = await this.productInventoryRepository.Get(productID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolProductInventoryMapper.MapBOToModel(this.dalProductInventoryMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiProductInventoryResponseModel>> Create(
                        ApiProductInventoryRequestModel model)
                {
                        CreateResponse<ApiProductInventoryResponseModel> response = new CreateResponse<ApiProductInventoryResponseModel>(await this.productInventoryModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProductInventoryMapper.MapModelToBO(default(int), model);
                                var record = await this.productInventoryRepository.Create(this.dalProductInventoryMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProductInventoryMapper.MapBOToModel(this.dalProductInventoryMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiProductInventoryResponseModel>> Update(
                        int productID,
                        ApiProductInventoryRequestModel model)
                {
                        var validationResult = await this.productInventoryModelValidator.ValidateUpdateAsync(productID, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolProductInventoryMapper.MapModelToBO(productID, model);
                                await this.productInventoryRepository.Update(this.dalProductInventoryMapper.MapBOToEF(bo));

                                var record = await this.productInventoryRepository.Get(productID);

                                return new UpdateResponse<ApiProductInventoryResponseModel>(this.bolProductInventoryMapper.MapBOToModel(this.dalProductInventoryMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiProductInventoryResponseModel>(validationResult);
                        }
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
    <Hash>e2da4f5e679c4a655580db69b6c0346d</Hash>
</Codenesium>*/