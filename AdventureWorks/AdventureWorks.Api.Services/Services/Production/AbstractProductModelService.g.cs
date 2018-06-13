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

                private IBOLProductMapper bolProductMapper;

                private IDALProductMapper dalProductMapper;
                private IBOLProductModelIllustrationMapper bolProductModelIllustrationMapper;

                private IDALProductModelIllustrationMapper dalProductModelIllustrationMapper;
                private IBOLProductModelProductDescriptionCultureMapper bolProductModelProductDescriptionCultureMapper;

                private IDALProductModelProductDescriptionCultureMapper dalProductModelProductDescriptionCultureMapper;

                private ILogger logger;

                public AbstractProductModelService(
                        ILogger logger,
                        IProductModelRepository productModelRepository,
                        IApiProductModelRequestModelValidator productModelModelValidator,
                        IBOLProductModelMapper bolProductModelMapper,
                        IDALProductModelMapper dalProductModelMapper

                        ,
                        IBOLProductMapper bolProductMapper,
                        IDALProductMapper dalProductMapper
                        ,
                        IBOLProductModelIllustrationMapper bolProductModelIllustrationMapper,
                        IDALProductModelIllustrationMapper dalProductModelIllustrationMapper
                        ,
                        IBOLProductModelProductDescriptionCultureMapper bolProductModelProductDescriptionCultureMapper,
                        IDALProductModelProductDescriptionCultureMapper dalProductModelProductDescriptionCultureMapper

                        )
                        : base()

                {
                        this.productModelRepository = productModelRepository;
                        this.productModelModelValidator = productModelModelValidator;
                        this.bolProductModelMapper = bolProductModelMapper;
                        this.dalProductModelMapper = dalProductModelMapper;
                        this.bolProductMapper = bolProductMapper;
                        this.dalProductMapper = dalProductMapper;
                        this.bolProductModelIllustrationMapper = bolProductModelIllustrationMapper;
                        this.dalProductModelIllustrationMapper = dalProductModelIllustrationMapper;
                        this.bolProductModelProductDescriptionCultureMapper = bolProductModelProductDescriptionCultureMapper;
                        this.dalProductModelProductDescriptionCultureMapper = dalProductModelProductDescriptionCultureMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProductModelResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.productModelRepository.All(limit, offset, orderClause);

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

                public async virtual Task<List<ApiProductResponseModel>> Products(int productModelID, int limit = int.MaxValue, int offset = 0)
                {
                        List<Product> records = await this.productModelRepository.Products(productModelID, limit, offset);

                        return this.bolProductMapper.MapBOToModel(this.dalProductMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiProductModelIllustrationResponseModel>> ProductModelIllustrations(int productModelID, int limit = int.MaxValue, int offset = 0)
                {
                        List<ProductModelIllustration> records = await this.productModelRepository.ProductModelIllustrations(productModelID, limit, offset);

                        return this.bolProductModelIllustrationMapper.MapBOToModel(this.dalProductModelIllustrationMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCultures(int productModelID, int limit = int.MaxValue, int offset = 0)
                {
                        List<ProductModelProductDescriptionCulture> records = await this.productModelRepository.ProductModelProductDescriptionCultures(productModelID, limit, offset);

                        return this.bolProductModelProductDescriptionCultureMapper.MapBOToModel(this.dalProductModelProductDescriptionCultureMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>2d5f31294b89a91227cdb7c921b559f8</Hash>
</Codenesium>*/