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
        public abstract class AbstractProductModelIllustrationService : AbstractService
        {
                private IProductModelIllustrationRepository productModelIllustrationRepository;

                private IApiProductModelIllustrationRequestModelValidator productModelIllustrationModelValidator;

                private IBOLProductModelIllustrationMapper bolProductModelIllustrationMapper;

                private IDALProductModelIllustrationMapper dalProductModelIllustrationMapper;

                private ILogger logger;

                public AbstractProductModelIllustrationService(
                        ILogger logger,
                        IProductModelIllustrationRepository productModelIllustrationRepository,
                        IApiProductModelIllustrationRequestModelValidator productModelIllustrationModelValidator,
                        IBOLProductModelIllustrationMapper bolProductModelIllustrationMapper,
                        IDALProductModelIllustrationMapper dalProductModelIllustrationMapper)
                        : base()
                {
                        this.productModelIllustrationRepository = productModelIllustrationRepository;
                        this.productModelIllustrationModelValidator = productModelIllustrationModelValidator;
                        this.bolProductModelIllustrationMapper = bolProductModelIllustrationMapper;
                        this.dalProductModelIllustrationMapper = dalProductModelIllustrationMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiProductModelIllustrationResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.productModelIllustrationRepository.All(limit, offset);

                        return this.bolProductModelIllustrationMapper.MapBOToModel(this.dalProductModelIllustrationMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiProductModelIllustrationResponseModel> Get(int productModelID)
                {
                        var record = await this.productModelIllustrationRepository.Get(productModelID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolProductModelIllustrationMapper.MapBOToModel(this.dalProductModelIllustrationMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiProductModelIllustrationResponseModel>> Create(
                        ApiProductModelIllustrationRequestModel model)
                {
                        CreateResponse<ApiProductModelIllustrationResponseModel> response = new CreateResponse<ApiProductModelIllustrationResponseModel>(await this.productModelIllustrationModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolProductModelIllustrationMapper.MapModelToBO(default(int), model);
                                var record = await this.productModelIllustrationRepository.Create(this.dalProductModelIllustrationMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolProductModelIllustrationMapper.MapBOToModel(this.dalProductModelIllustrationMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int productModelID,
                        ApiProductModelIllustrationRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.productModelIllustrationModelValidator.ValidateUpdateAsync(productModelID, model));
                        if (response.Success)
                        {
                                var bo = this.bolProductModelIllustrationMapper.MapModelToBO(productModelID, model);
                                await this.productModelIllustrationRepository.Update(this.dalProductModelIllustrationMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int productModelID)
                {
                        ActionResponse response = new ActionResponse(await this.productModelIllustrationModelValidator.ValidateDeleteAsync(productModelID));
                        if (response.Success)
                        {
                                await this.productModelIllustrationRepository.Delete(productModelID);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>03990b370d6c4023fa1ea4826bc987c8</Hash>
</Codenesium>*/