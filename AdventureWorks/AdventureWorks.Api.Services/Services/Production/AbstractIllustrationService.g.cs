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
        public abstract class AbstractIllustrationService : AbstractService
        {
                private IIllustrationRepository illustrationRepository;

                private IApiIllustrationRequestModelValidator illustrationModelValidator;

                private IBOLIllustrationMapper bolIllustrationMapper;

                private IDALIllustrationMapper dalIllustrationMapper;

                private IBOLProductModelIllustrationMapper bolProductModelIllustrationMapper;

                private IDALProductModelIllustrationMapper dalProductModelIllustrationMapper;

                private ILogger logger;

                public AbstractIllustrationService(
                        ILogger logger,
                        IIllustrationRepository illustrationRepository,
                        IApiIllustrationRequestModelValidator illustrationModelValidator,
                        IBOLIllustrationMapper bolIllustrationMapper,
                        IDALIllustrationMapper dalIllustrationMapper,
                        IBOLProductModelIllustrationMapper bolProductModelIllustrationMapper,
                        IDALProductModelIllustrationMapper dalProductModelIllustrationMapper)
                        : base()
                {
                        this.illustrationRepository = illustrationRepository;
                        this.illustrationModelValidator = illustrationModelValidator;
                        this.bolIllustrationMapper = bolIllustrationMapper;
                        this.dalIllustrationMapper = dalIllustrationMapper;
                        this.bolProductModelIllustrationMapper = bolProductModelIllustrationMapper;
                        this.dalProductModelIllustrationMapper = dalProductModelIllustrationMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiIllustrationResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.illustrationRepository.All(limit, offset);

                        return this.bolIllustrationMapper.MapBOToModel(this.dalIllustrationMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiIllustrationResponseModel> Get(int illustrationID)
                {
                        var record = await this.illustrationRepository.Get(illustrationID);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolIllustrationMapper.MapBOToModel(this.dalIllustrationMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiIllustrationResponseModel>> Create(
                        ApiIllustrationRequestModel model)
                {
                        CreateResponse<ApiIllustrationResponseModel> response = new CreateResponse<ApiIllustrationResponseModel>(await this.illustrationModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolIllustrationMapper.MapModelToBO(default(int), model);
                                var record = await this.illustrationRepository.Create(this.dalIllustrationMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolIllustrationMapper.MapBOToModel(this.dalIllustrationMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiIllustrationResponseModel>> Update(
                        int illustrationID,
                        ApiIllustrationRequestModel model)
                {
                        var validationResult = await this.illustrationModelValidator.ValidateUpdateAsync(illustrationID, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolIllustrationMapper.MapModelToBO(illustrationID, model);
                                await this.illustrationRepository.Update(this.dalIllustrationMapper.MapBOToEF(bo));

                                var record = await this.illustrationRepository.Get(illustrationID);

                                return new UpdateResponse<ApiIllustrationResponseModel>(this.bolIllustrationMapper.MapBOToModel(this.dalIllustrationMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiIllustrationResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int illustrationID)
                {
                        ActionResponse response = new ActionResponse(await this.illustrationModelValidator.ValidateDeleteAsync(illustrationID));
                        if (response.Success)
                        {
                                await this.illustrationRepository.Delete(illustrationID);
                        }

                        return response;
                }

                public async virtual Task<List<ApiProductModelIllustrationResponseModel>> ProductModelIllustrations(int illustrationID, int limit = int.MaxValue, int offset = 0)
                {
                        List<ProductModelIllustration> records = await this.illustrationRepository.ProductModelIllustrations(illustrationID, limit, offset);

                        return this.bolProductModelIllustrationMapper.MapBOToModel(this.dalProductModelIllustrationMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>08b65ec8f7c1eed10eaff358a7c26cc2</Hash>
</Codenesium>*/