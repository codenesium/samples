using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractHandlerPipelineStepService: AbstractService
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
                        IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper

                        )
                        : base()

                {
                        this.handlerPipelineStepRepository = handlerPipelineStepRepository;
                        this.handlerPipelineStepModelValidator = handlerPipelineStepModelValidator;
                        this.bolHandlerPipelineStepMapper = bolHandlerPipelineStepMapper;
                        this.dalHandlerPipelineStepMapper = dalHandlerPipelineStepMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiHandlerPipelineStepResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.handlerPipelineStepRepository.All(limit, offset, orderClause);

                        return this.bolHandlerPipelineStepMapper.MapBOToModel(this.dalHandlerPipelineStepMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiHandlerPipelineStepResponseModel> Get(int id)
                {
                        var record = await this.handlerPipelineStepRepository.Get(id);

                        return this.bolHandlerPipelineStepMapper.MapBOToModel(this.dalHandlerPipelineStepMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiHandlerPipelineStepResponseModel>> Create(
                        ApiHandlerPipelineStepRequestModel model)
                {
                        CreateResponse<ApiHandlerPipelineStepResponseModel> response = new CreateResponse<ApiHandlerPipelineStepResponseModel>(await this.handlerPipelineStepModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolHandlerPipelineStepMapper.MapModelToBO(default (int), model);
                                var record = await this.handlerPipelineStepRepository.Create(this.dalHandlerPipelineStepMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolHandlerPipelineStepMapper.MapBOToModel(this.dalHandlerPipelineStepMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiHandlerPipelineStepRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.handlerPipelineStepModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolHandlerPipelineStepMapper.MapModelToBO(id, model);
                                await this.handlerPipelineStepRepository.Update(this.dalHandlerPipelineStepMapper.MapBOToEF(bo));
                        }

                        return response;
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
    <Hash>50b7ca9d98308266ca34ef5b37504129</Hash>
</Codenesium>*/