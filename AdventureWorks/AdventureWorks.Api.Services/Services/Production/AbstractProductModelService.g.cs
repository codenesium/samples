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
        public abstract class AbstractProductModelService: AbstractService
        {
                private IProductModelRepository productModelRepository;

                private IApiProductModelRequestModelValidator productModelModelValidator;

                private IBOLProductModelMapper bolProductModelMapper;

                private IDALProductModelMapper dalProductModelMapper;

                private ILogger logger;

                public AbstractProductModelService(
                        ILogger logger,
                        IProductModelRepository productModelRepository,
                        IApiProductModelRequestModelValidator productModelModelValidator,
                        IBOLProductModelMapper bolproductModelMapper,
                        IDALProductModelMapper dalproductModelMapper)
                        : base()

                {
                        this.productModelRepository = productModelRepository;
                        this.productModelModelValidator = productModelModelValidator;
                        this.bolProductModelMapper = bolproductModelMapper;
                        this.dalProductModelMapper = dalproductModelMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProductModelResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.productModelRepository.All(skip, take, orderClause);

                        return this.bolProductModelMapper.MapBOToModel(this.dalProductModelMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProductModelResponseModel> Get(int productModelID)
                {
                        var record = await this.productModelRepository.Get(productModelID);

                        return this.bolProductModelMapper.MapBOToModel(this.dalProductModelMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiProductModelResponseModel>> Create(
                        ApiProductModelRequestModel model)
                {
                        CreateResponse<ApiProductModelResponseModel> response = new CreateResponse<ApiProductModelResponseModel>(await this.productModelModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProductModelMapper.MapModelToBO(default (int), model);
                                var record = await this.productModelRepository.Create(this.dalProductModelMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProductModelMapper.MapBOToModel(this.dalProductModelMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int productModelID,
                        ApiProductModelRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.productModelModelValidator.ValidateUpdateAsync(productModelID, model));

                        if (response.Success)
                        {
                                var bo = this.bolProductModelMapper.MapModelToBO(productModelID, model);
                                await this.productModelRepository.Update(this.dalProductModelMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int productModelID)
                {
                        ActionResponse response = new ActionResponse(await this.productModelModelValidator.ValidateDeleteAsync(productModelID));

                        if (response.Success)
                        {
                                await this.productModelRepository.Delete(productModelID);
                        }

                        return response;
                }

                public async Task<ApiProductModelResponseModel> GetName(string name)
                {
                        ProductModel record = await this.productModelRepository.GetName(name);

                        return this.bolProductModelMapper.MapBOToModel(this.dalProductModelMapper.MapEFToBO(record));
                }
                public async Task<List<ApiProductModelResponseModel>> GetCatalogDescription(string catalogDescription)
                {
                        List<ProductModel> records = await this.productModelRepository.GetCatalogDescription(catalogDescription);

                        return this.bolProductModelMapper.MapBOToModel(this.dalProductModelMapper.MapEFToBO(records));
                }
                public async Task<List<ApiProductModelResponseModel>> GetInstructions(string instructions)
                {
                        List<ProductModel> records = await this.productModelRepository.GetInstructions(instructions);

                        return this.bolProductModelMapper.MapBOToModel(this.dalProductModelMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>bebd97fa44c489852e12b2356e62e5aa</Hash>
</Codenesium>*/