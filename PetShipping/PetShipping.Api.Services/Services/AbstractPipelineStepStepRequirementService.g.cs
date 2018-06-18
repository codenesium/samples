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
                        IBOLPipelineStepStepRequirementMapper bolPipelineStepStepRequirementMapper,
                        IDALPipelineStepStepRequirementMapper dalPipelineStepStepRequirementMapper

                        )
                        : base()

                {
                        this.pipelineStepStepRequirementRepository = pipelineStepStepRequirementRepository;
                        this.pipelineStepStepRequirementModelValidator = pipelineStepStepRequirementModelValidator;
                        this.bolPipelineStepStepRequirementMapper = bolPipelineStepStepRequirementMapper;
                        this.dalPipelineStepStepRequirementMapper = dalPipelineStepStepRequirementMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPipelineStepStepRequirementResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.pipelineStepStepRequirementRepository.All(limit, offset);

                        return this.bolPipelineStepStepRequirementMapper.MapBOToModel(this.dalPipelineStepStepRequirementMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiPipelineStepStepRequirementResponseModel> Get(int id)
                {
                        var record = await this.pipelineStepStepRequirementRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolPipelineStepStepRequirementMapper.MapBOToModel(this.dalPipelineStepStepRequirementMapper.MapEFToBO(record));
                        }
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
    <Hash>7a2cd7856fe54978aad2764f183c31ae</Hash>
</Codenesium>*/