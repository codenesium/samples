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
        public abstract class AbstractProductModelProductDescriptionCultureService: AbstractService
        {
                private IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository;

                private IApiProductModelProductDescriptionCultureRequestModelValidator productModelProductDescriptionCultureModelValidator;

                private IBOLProductModelProductDescriptionCultureMapper bolProductModelProductDescriptionCultureMapper;

                private IDALProductModelProductDescriptionCultureMapper dalProductModelProductDescriptionCultureMapper;

                private ILogger logger;

                public AbstractProductModelProductDescriptionCultureService(
                        ILogger logger,
                        IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository,
                        IApiProductModelProductDescriptionCultureRequestModelValidator productModelProductDescriptionCultureModelValidator,
                        IBOLProductModelProductDescriptionCultureMapper bolproductModelProductDescriptionCultureMapper,
                        IDALProductModelProductDescriptionCultureMapper dalproductModelProductDescriptionCultureMapper)
                        : base()

                {
                        this.productModelProductDescriptionCultureRepository = productModelProductDescriptionCultureRepository;
                        this.productModelProductDescriptionCultureModelValidator = productModelProductDescriptionCultureModelValidator;
                        this.bolProductModelProductDescriptionCultureMapper = bolproductModelProductDescriptionCultureMapper;
                        this.dalProductModelProductDescriptionCultureMapper = dalproductModelProductDescriptionCultureMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProductModelProductDescriptionCultureResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.productModelProductDescriptionCultureRepository.All(skip, take, orderClause);

                        return this.bolProductModelProductDescriptionCultureMapper.MapBOToModel(this.dalProductModelProductDescriptionCultureMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProductModelProductDescriptionCultureResponseModel> Get(int productModelID)
                {
                        var record = await this.productModelProductDescriptionCultureRepository.Get(productModelID);

                        return this.bolProductModelProductDescriptionCultureMapper.MapBOToModel(this.dalProductModelProductDescriptionCultureMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>> Create(
                        ApiProductModelProductDescriptionCultureRequestModel model)
                {
                        CreateResponse<ApiProductModelProductDescriptionCultureResponseModel> response = new CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>(await this.productModelProductDescriptionCultureModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProductModelProductDescriptionCultureMapper.MapModelToBO(default (int), model);
                                var record = await this.productModelProductDescriptionCultureRepository.Create(this.dalProductModelProductDescriptionCultureMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProductModelProductDescriptionCultureMapper.MapBOToModel(this.dalProductModelProductDescriptionCultureMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int productModelID,
                        ApiProductModelProductDescriptionCultureRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.productModelProductDescriptionCultureModelValidator.ValidateUpdateAsync(productModelID, model));

                        if (response.Success)
                        {
                                var bo = this.bolProductModelProductDescriptionCultureMapper.MapModelToBO(productModelID, model);
                                await this.productModelProductDescriptionCultureRepository.Update(this.dalProductModelProductDescriptionCultureMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int productModelID)
                {
                        ActionResponse response = new ActionResponse(await this.productModelProductDescriptionCultureModelValidator.ValidateDeleteAsync(productModelID));

                        if (response.Success)
                        {
                                await this.productModelProductDescriptionCultureRepository.Delete(productModelID);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>a13ddd14cd5307b8dcd094faf075ecc0</Hash>
</Codenesium>*/