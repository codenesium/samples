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
        public abstract class AbstractProductService: AbstractService
        {
                private IProductRepository productRepository;

                private IApiProductRequestModelValidator productModelValidator;

                private IBOLProductMapper bolProductMapper;

                private IDALProductMapper dalProductMapper;

                private ILogger logger;

                public AbstractProductService(
                        ILogger logger,
                        IProductRepository productRepository,
                        IApiProductRequestModelValidator productModelValidator,
                        IBOLProductMapper bolproductMapper,
                        IDALProductMapper dalproductMapper)
                        : base()

                {
                        this.productRepository = productRepository;
                        this.productModelValidator = productModelValidator;
                        this.bolProductMapper = bolproductMapper;
                        this.dalProductMapper = dalproductMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProductResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.productRepository.All(skip, take, orderClause);

                        return this.bolProductMapper.MapBOToModel(this.dalProductMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProductResponseModel> Get(int productID)
                {
                        var record = await this.productRepository.Get(productID);

                        return this.bolProductMapper.MapBOToModel(this.dalProductMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiProductResponseModel>> Create(
                        ApiProductRequestModel model)
                {
                        CreateResponse<ApiProductResponseModel> response = new CreateResponse<ApiProductResponseModel>(await this.productModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProductMapper.MapModelToBO(default (int), model);
                                var record = await this.productRepository.Create(this.dalProductMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProductMapper.MapBOToModel(this.dalProductMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int productID,
                        ApiProductRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.productModelValidator.ValidateUpdateAsync(productID, model));

                        if (response.Success)
                        {
                                var bo = this.bolProductMapper.MapModelToBO(productID, model);
                                await this.productRepository.Update(this.dalProductMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int productID)
                {
                        ActionResponse response = new ActionResponse(await this.productModelValidator.ValidateDeleteAsync(productID));

                        if (response.Success)
                        {
                                await this.productRepository.Delete(productID);
                        }

                        return response;
                }

                public async Task<ApiProductResponseModel> GetName(string name)
                {
                        Product record = await this.productRepository.GetName(name);

                        return this.bolProductMapper.MapBOToModel(this.dalProductMapper.MapEFToBO(record));
                }
                public async Task<ApiProductResponseModel> GetProductNumber(string productNumber)
                {
                        Product record = await this.productRepository.GetProductNumber(productNumber);

                        return this.bolProductMapper.MapBOToModel(this.dalProductMapper.MapEFToBO(record));
                }
        }
}

/*<Codenesium>
    <Hash>17c2aa698b165088df804d8abfa2bfdf</Hash>
</Codenesium>*/