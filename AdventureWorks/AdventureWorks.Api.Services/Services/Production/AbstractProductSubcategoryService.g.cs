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
        public abstract class AbstractProductSubcategoryService: AbstractService
        {
                private IProductSubcategoryRepository productSubcategoryRepository;

                private IApiProductSubcategoryRequestModelValidator productSubcategoryModelValidator;

                private IBOLProductSubcategoryMapper bolProductSubcategoryMapper;

                private IDALProductSubcategoryMapper dalProductSubcategoryMapper;

                private IBOLProductMapper bolProductMapper;

                private IDALProductMapper dalProductMapper;

                private ILogger logger;

                public AbstractProductSubcategoryService(
                        ILogger logger,
                        IProductSubcategoryRepository productSubcategoryRepository,
                        IApiProductSubcategoryRequestModelValidator productSubcategoryModelValidator,
                        IBOLProductSubcategoryMapper bolProductSubcategoryMapper,
                        IDALProductSubcategoryMapper dalProductSubcategoryMapper

                        ,
                        IBOLProductMapper bolProductMapper,
                        IDALProductMapper dalProductMapper

                        )
                        : base()

                {
                        this.productSubcategoryRepository = productSubcategoryRepository;
                        this.productSubcategoryModelValidator = productSubcategoryModelValidator;
                        this.bolProductSubcategoryMapper = bolProductSubcategoryMapper;
                        this.dalProductSubcategoryMapper = dalProductSubcategoryMapper;
                        this.bolProductMapper = bolProductMapper;
                        this.dalProductMapper = dalProductMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProductSubcategoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.productSubcategoryRepository.All(limit, offset);

                        return this.bolProductSubcategoryMapper.MapBOToModel(this.dalProductSubcategoryMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProductSubcategoryResponseModel> Get(int productSubcategoryID)
                {
                        var record = await this.productSubcategoryRepository.Get(productSubcategoryID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolProductSubcategoryMapper.MapBOToModel(this.dalProductSubcategoryMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiProductSubcategoryResponseModel>> Create(
                        ApiProductSubcategoryRequestModel model)
                {
                        CreateResponse<ApiProductSubcategoryResponseModel> response = new CreateResponse<ApiProductSubcategoryResponseModel>(await this.productSubcategoryModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProductSubcategoryMapper.MapModelToBO(default (int), model);
                                var record = await this.productSubcategoryRepository.Create(this.dalProductSubcategoryMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProductSubcategoryMapper.MapBOToModel(this.dalProductSubcategoryMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int productSubcategoryID,
                        ApiProductSubcategoryRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.productSubcategoryModelValidator.ValidateUpdateAsync(productSubcategoryID, model));

                        if (response.Success)
                        {
                                var bo = this.bolProductSubcategoryMapper.MapModelToBO(productSubcategoryID, model);
                                await this.productSubcategoryRepository.Update(this.dalProductSubcategoryMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int productSubcategoryID)
                {
                        ActionResponse response = new ActionResponse(await this.productSubcategoryModelValidator.ValidateDeleteAsync(productSubcategoryID));

                        if (response.Success)
                        {
                                await this.productSubcategoryRepository.Delete(productSubcategoryID);
                        }

                        return response;
                }

                public async Task<ApiProductSubcategoryResponseModel> ByName(string name)
                {
                        ProductSubcategory record = await this.productSubcategoryRepository.ByName(name);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolProductSubcategoryMapper.MapBOToModel(this.dalProductSubcategoryMapper.MapEFToBO(record));
                        }
                }

                public async virtual Task<List<ApiProductResponseModel>> Products(int productSubcategoryID, int limit = int.MaxValue, int offset = 0)
                {
                        List<Product> records = await this.productSubcategoryRepository.Products(productSubcategoryID, limit, offset);

                        return this.bolProductMapper.MapBOToModel(this.dalProductMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>f37eddac8d8414163925ae4e3e99426a</Hash>
</Codenesium>*/