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
        public abstract class AbstractProductDescriptionService : AbstractService
        {
                private IProductDescriptionRepository productDescriptionRepository;

                private IApiProductDescriptionRequestModelValidator productDescriptionModelValidator;

                private IBOLProductDescriptionMapper bolProductDescriptionMapper;

                private IDALProductDescriptionMapper dalProductDescriptionMapper;

                private IBOLProductModelProductDescriptionCultureMapper bolProductModelProductDescriptionCultureMapper;

                private IDALProductModelProductDescriptionCultureMapper dalProductModelProductDescriptionCultureMapper;

                private ILogger logger;

                public AbstractProductDescriptionService(
                        ILogger logger,
                        IProductDescriptionRepository productDescriptionRepository,
                        IApiProductDescriptionRequestModelValidator productDescriptionModelValidator,
                        IBOLProductDescriptionMapper bolProductDescriptionMapper,
                        IDALProductDescriptionMapper dalProductDescriptionMapper,
                        IBOLProductModelProductDescriptionCultureMapper bolProductModelProductDescriptionCultureMapper,
                        IDALProductModelProductDescriptionCultureMapper dalProductModelProductDescriptionCultureMapper)
                        : base()
                {
                        this.productDescriptionRepository = productDescriptionRepository;
                        this.productDescriptionModelValidator = productDescriptionModelValidator;
                        this.bolProductDescriptionMapper = bolProductDescriptionMapper;
                        this.dalProductDescriptionMapper = dalProductDescriptionMapper;
                        this.bolProductModelProductDescriptionCultureMapper = bolProductModelProductDescriptionCultureMapper;
                        this.dalProductModelProductDescriptionCultureMapper = dalProductModelProductDescriptionCultureMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProductDescriptionResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.productDescriptionRepository.All(limit, offset);

                        return this.bolProductDescriptionMapper.MapBOToModel(this.dalProductDescriptionMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProductDescriptionResponseModel> Get(int productDescriptionID)
                {
                        var record = await this.productDescriptionRepository.Get(productDescriptionID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolProductDescriptionMapper.MapBOToModel(this.dalProductDescriptionMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiProductDescriptionResponseModel>> Create(
                        ApiProductDescriptionRequestModel model)
                {
                        CreateResponse<ApiProductDescriptionResponseModel> response = new CreateResponse<ApiProductDescriptionResponseModel>(await this.productDescriptionModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProductDescriptionMapper.MapModelToBO(default(int), model);
                                var record = await this.productDescriptionRepository.Create(this.dalProductDescriptionMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProductDescriptionMapper.MapBOToModel(this.dalProductDescriptionMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiProductDescriptionResponseModel>> Update(
                        int productDescriptionID,
                        ApiProductDescriptionRequestModel model)
                {
                        var validationResult = await this.productDescriptionModelValidator.ValidateUpdateAsync(productDescriptionID, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolProductDescriptionMapper.MapModelToBO(productDescriptionID, model);
                                await this.productDescriptionRepository.Update(this.dalProductDescriptionMapper.MapBOToEF(bo));

                                var record = await this.productDescriptionRepository.Get(productDescriptionID);

                                return new UpdateResponse<ApiProductDescriptionResponseModel>(this.bolProductDescriptionMapper.MapBOToModel(this.dalProductDescriptionMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiProductDescriptionResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int productDescriptionID)
                {
                        ActionResponse response = new ActionResponse(await this.productDescriptionModelValidator.ValidateDeleteAsync(productDescriptionID));
                        if (response.Success)
                        {
                                await this.productDescriptionRepository.Delete(productDescriptionID);
                        }

                        return response;
                }

                public async virtual Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCultures(int productDescriptionID, int limit = int.MaxValue, int offset = 0)
                {
                        List<ProductModelProductDescriptionCulture> records = await this.productDescriptionRepository.ProductModelProductDescriptionCultures(productDescriptionID, limit, offset);

                        return this.bolProductModelProductDescriptionCultureMapper.MapBOToModel(this.dalProductModelProductDescriptionCultureMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>1c8f0566db8e92623cf1a9d4545a969a</Hash>
</Codenesium>*/