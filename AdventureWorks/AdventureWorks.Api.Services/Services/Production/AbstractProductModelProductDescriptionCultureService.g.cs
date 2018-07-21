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
        public abstract class AbstractProductModelProductDescriptionCultureService : AbstractService
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
                        IBOLProductModelProductDescriptionCultureMapper bolProductModelProductDescriptionCultureMapper,
                        IDALProductModelProductDescriptionCultureMapper dalProductModelProductDescriptionCultureMapper)
                        : base()
                {
                        this.productModelProductDescriptionCultureRepository = productModelProductDescriptionCultureRepository;
                        this.productModelProductDescriptionCultureModelValidator = productModelProductDescriptionCultureModelValidator;
                        this.bolProductModelProductDescriptionCultureMapper = bolProductModelProductDescriptionCultureMapper;
                        this.dalProductModelProductDescriptionCultureMapper = dalProductModelProductDescriptionCultureMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProductModelProductDescriptionCultureResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.productModelProductDescriptionCultureRepository.All(limit, offset);

                        return this.bolProductModelProductDescriptionCultureMapper.MapBOToModel(this.dalProductModelProductDescriptionCultureMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProductModelProductDescriptionCultureResponseModel> Get(int productModelID)
                {
                        var record = await this.productModelProductDescriptionCultureRepository.Get(productModelID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolProductModelProductDescriptionCultureMapper.MapBOToModel(this.dalProductModelProductDescriptionCultureMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>> Create(
                        ApiProductModelProductDescriptionCultureRequestModel model)
                {
                        CreateResponse<ApiProductModelProductDescriptionCultureResponseModel> response = new CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>(await this.productModelProductDescriptionCultureModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProductModelProductDescriptionCultureMapper.MapModelToBO(default(int), model);
                                var record = await this.productModelProductDescriptionCultureRepository.Create(this.dalProductModelProductDescriptionCultureMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProductModelProductDescriptionCultureMapper.MapBOToModel(this.dalProductModelProductDescriptionCultureMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiProductModelProductDescriptionCultureResponseModel>> Update(
                        int productModelID,
                        ApiProductModelProductDescriptionCultureRequestModel model)
                {
                        var validationResult = await this.productModelProductDescriptionCultureModelValidator.ValidateUpdateAsync(productModelID, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolProductModelProductDescriptionCultureMapper.MapModelToBO(productModelID, model);
                                await this.productModelProductDescriptionCultureRepository.Update(this.dalProductModelProductDescriptionCultureMapper.MapBOToEF(bo));

                                var record = await this.productModelProductDescriptionCultureRepository.Get(productModelID);

                                return new UpdateResponse<ApiProductModelProductDescriptionCultureResponseModel>(this.bolProductModelProductDescriptionCultureMapper.MapBOToModel(this.dalProductModelProductDescriptionCultureMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiProductModelProductDescriptionCultureResponseModel>(validationResult);
                        }
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
    <Hash>f1c12fc2d5d2084ab4d03b6d3d579dc1</Hash>
</Codenesium>*/