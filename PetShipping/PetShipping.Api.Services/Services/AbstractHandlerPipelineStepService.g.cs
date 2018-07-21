using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractHandlerPipelineStepService : AbstractService
        {
                private IHandlerPipelineStepRepository handlerPipelineStepRepository;

                private IApiHandlerPipelineStepRequestModelValidator handlerPipelineStepModelValidator;

                private IBOLHandlerPipelineStepMapper bolHandlerPipelineStepMapper;

                private IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper;

                private ILogger logger;

                public AbstractHandlerPipelineStepService(
                        ILogger logger,
                        IHandlerPipelineStepRepository handlerPipelineStepRepository,
                        IApiHandlerPipelineStepRequestModelValidator handlerPipelineStepModelValidator,
                        IBOLHandlerPipelineStepMapper bolHandlerPipelineStepMapper,
                        IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper)
                        : base()
                {
                        this.handlerPipelineStepRepository = handlerPipelineStepRepository;
                        this.handlerPipelineStepModelValidator = handlerPipelineStepModelValidator;
                        this.bolHandlerPipelineStepMapper = bolHandlerPipelineStepMapper;
                        this.dalHandlerPipelineStepMapper = dalHandlerPipelineStepMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiHandlerPipelineStepResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.handlerPipelineStepRepository.All(limit, offset);

                        return this.bolHandlerPipelineStepMapper.MapBOToModel(this.dalHandlerPipelineStepMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiHandlerPipelineStepResponseModel> Get(int id)
                {
                        var record = await this.handlerPipelineStepRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolHandlerPipelineStepMapper.MapBOToModel(this.dalHandlerPipelineStepMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiHandlerPipelineStepResponseModel>> Create(
                        ApiHandlerPipelineStepRequestModel model)
                {
                        CreateResponse<ApiHandlerPipelineStepResponseModel> response = new CreateResponse<ApiHandlerPipelineStepResponseModel>(await this.handlerPipelineStepModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolHandlerPipelineStepMapper.MapModelToBO(default(int), model);
                                var record = await this.handlerPipelineStepRepository.Create(this.dalHandlerPipelineStepMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolHandlerPipelineStepMapper.MapBOToModel(this.dalHandlerPipelineStepMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiHandlerPipelineStepResponseModel>> Update(
                        int id,
                        ApiHandlerPipelineStepRequestModel model)
                {
                        var validationResult = await this.handlerPipelineStepModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolHandlerPipelineStepMapper.MapModelToBO(id, model);
                                await this.handlerPipelineStepRepository.Update(this.dalHandlerPipelineStepMapper.MapBOToEF(bo));

                                var record = await this.handlerPipelineStepRepository.Get(id);

                                return new UpdateResponse<ApiHandlerPipelineStepResponseModel>(this.bolHandlerPipelineStepMapper.MapBOToModel(this.dalHandlerPipelineStepMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiHandlerPipelineStepResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.handlerPipelineStepModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.handlerPipelineStepRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>af876bc163d36385c1f5d1c8080bcad0</Hash>
</Codenesium>*/