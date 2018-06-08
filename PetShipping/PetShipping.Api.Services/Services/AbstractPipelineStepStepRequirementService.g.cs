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
        public abstract class AbstractPipelineStepStepRequirementService: AbstractService
        {
                private IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository;

                private IApiPipelineStepStepRequirementRequestModelValidator pipelineStepStepRequirementModelValidator;

                private IBOLPipelineStepStepRequirementMapper bolPipelineStepStepRequirementMapper;

                private IDALPipelineStepStepRequirementMapper dalPipelineStepStepRequirementMapper;

                private ILogger logger;

                public AbstractPipelineStepStepRequirementService(
                        ILogger logger,
                        IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository,
                        IApiPipelineStepStepRequirementRequestModelValidator pipelineStepStepRequirementModelValidator,
                        IBOLPipelineStepStepRequirementMapper bolpipelineStepStepRequirementMapper,
                        IDALPipelineStepStepRequirementMapper dalpipelineStepStepRequirementMapper)
                        : base()

                {
                        this.pipelineStepStepRequirementRepository = pipelineStepStepRequirementRepository;
                        this.pipelineStepStepRequirementModelValidator = pipelineStepStepRequirementModelValidator;
                        this.bolPipelineStepStepRequirementMapper = bolpipelineStepStepRequirementMapper;
                        this.dalPipelineStepStepRequirementMapper = dalpipelineStepStepRequirementMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPipelineStepStepRequirementResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.pipelineStepStepRequirementRepository.All(skip, take, orderClause);

                        return this.bolPipelineStepStepRequirementMapper.MapBOToModel(this.dalPipelineStepStepRequirementMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiPipelineStepStepRequirementResponseModel> Get(int id)
                {
                        var record = await this.pipelineStepStepRequirementRepository.Get(id);

                        return this.bolPipelineStepStepRequirementMapper.MapBOToModel(this.dalPipelineStepStepRequirementMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiPipelineStepStepRequirementResponseModel>> Create(
                        ApiPipelineStepStepRequirementRequestModel model)
                {
                        CreateResponse<ApiPipelineStepStepRequirementResponseModel> response = new CreateResponse<ApiPipelineStepStepRequirementResponseModel>(await this.pipelineStepStepRequirementModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolPipelineStepStepRequirementMapper.MapModelToBO(default (int), model);
                                var record = await this.pipelineStepStepRequirementRepository.Create(this.dalPipelineStepStepRequirementMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolPipelineStepStepRequirementMapper.MapBOToModel(this.dalPipelineStepStepRequirementMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiPipelineStepStepRequirementRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.pipelineStepStepRequirementModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolPipelineStepStepRequirementMapper.MapModelToBO(id, model);
                                await this.pipelineStepStepRequirementRepository.Update(this.dalPipelineStepStepRequirementMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.pipelineStepStepRequirementModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.pipelineStepStepRequirementRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>e61f834faaf5ba08196e1804489bd9ef</Hash>
</Codenesium>*/