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
        public abstract class AbstractPipelineStepService: AbstractService
        {
                private IPipelineStepRepository pipelineStepRepository;

                private IApiPipelineStepRequestModelValidator pipelineStepModelValidator;

                private IBOLPipelineStepMapper bolPipelineStepMapper;

                private IDALPipelineStepMapper dalPipelineStepMapper;

                private IBOLHandlerPipelineStepMapper bolHandlerPipelineStepMapper;

                private IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper;
                private IBOLOtherTransportMapper bolOtherTransportMapper;

                private IDALOtherTransportMapper dalOtherTransportMapper;
                private IBOLPipelineStepDestinationMapper bolPipelineStepDestinationMapper;

                private IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper;
                private IBOLPipelineStepNoteMapper bolPipelineStepNoteMapper;

                private IDALPipelineStepNoteMapper dalPipelineStepNoteMapper;
                private IBOLPipelineStepStepRequirementMapper bolPipelineStepStepRequirementMapper;

                private IDALPipelineStepStepRequirementMapper dalPipelineStepStepRequirementMapper;

                private ILogger logger;

                public AbstractPipelineStepService(
                        ILogger logger,
                        IPipelineStepRepository pipelineStepRepository,
                        IApiPipelineStepRequestModelValidator pipelineStepModelValidator,
                        IBOLPipelineStepMapper bolPipelineStepMapper,
                        IDALPipelineStepMapper dalPipelineStepMapper

                        ,
                        IBOLHandlerPipelineStepMapper bolHandlerPipelineStepMapper,
                        IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper
                        ,
                        IBOLOtherTransportMapper bolOtherTransportMapper,
                        IDALOtherTransportMapper dalOtherTransportMapper
                        ,
                        IBOLPipelineStepDestinationMapper bolPipelineStepDestinationMapper,
                        IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper
                        ,
                        IBOLPipelineStepNoteMapper bolPipelineStepNoteMapper,
                        IDALPipelineStepNoteMapper dalPipelineStepNoteMapper
                        ,
                        IBOLPipelineStepStepRequirementMapper bolPipelineStepStepRequirementMapper,
                        IDALPipelineStepStepRequirementMapper dalPipelineStepStepRequirementMapper

                        )
                        : base()

                {
                        this.pipelineStepRepository = pipelineStepRepository;
                        this.pipelineStepModelValidator = pipelineStepModelValidator;
                        this.bolPipelineStepMapper = bolPipelineStepMapper;
                        this.dalPipelineStepMapper = dalPipelineStepMapper;
                        this.bolHandlerPipelineStepMapper = bolHandlerPipelineStepMapper;
                        this.dalHandlerPipelineStepMapper = dalHandlerPipelineStepMapper;
                        this.bolOtherTransportMapper = bolOtherTransportMapper;
                        this.dalOtherTransportMapper = dalOtherTransportMapper;
                        this.bolPipelineStepDestinationMapper = bolPipelineStepDestinationMapper;
                        this.dalPipelineStepDestinationMapper = dalPipelineStepDestinationMapper;
                        this.bolPipelineStepNoteMapper = bolPipelineStepNoteMapper;
                        this.dalPipelineStepNoteMapper = dalPipelineStepNoteMapper;
                        this.bolPipelineStepStepRequirementMapper = bolPipelineStepStepRequirementMapper;
                        this.dalPipelineStepStepRequirementMapper = dalPipelineStepStepRequirementMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPipelineStepResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.pipelineStepRepository.All(limit, offset, orderClause);

                        return this.bolPipelineStepMapper.MapBOToModel(this.dalPipelineStepMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiPipelineStepResponseModel> Get(int id)
                {
                        var record = await this.pipelineStepRepository.Get(id);

                        return this.bolPipelineStepMapper.MapBOToModel(this.dalPipelineStepMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiPipelineStepResponseModel>> Create(
                        ApiPipelineStepRequestModel model)
                {
                        CreateResponse<ApiPipelineStepResponseModel> response = new CreateResponse<ApiPipelineStepResponseModel>(await this.pipelineStepModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolPipelineStepMapper.MapModelToBO(default (int), model);
                                var record = await this.pipelineStepRepository.Create(this.dalPipelineStepMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolPipelineStepMapper.MapBOToModel(this.dalPipelineStepMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiPipelineStepRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.pipelineStepModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolPipelineStepMapper.MapModelToBO(id, model);
                                await this.pipelineStepRepository.Update(this.dalPipelineStepMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.pipelineStepModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.pipelineStepRepository.Delete(id);
                        }

                        return response;
                }

                public async virtual Task<List<ApiHandlerPipelineStepResponseModel>> HandlerPipelineSteps(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
                {
                        List<HandlerPipelineStep> records = await this.pipelineStepRepository.HandlerPipelineSteps(pipelineStepId, limit, offset);

                        return this.bolHandlerPipelineStepMapper.MapBOToModel(this.dalHandlerPipelineStepMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiOtherTransportResponseModel>> OtherTransports(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
                {
                        List<OtherTransport> records = await this.pipelineStepRepository.OtherTransports(pipelineStepId, limit, offset);

                        return this.bolOtherTransportMapper.MapBOToModel(this.dalOtherTransportMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiPipelineStepDestinationResponseModel>> PipelineStepDestinations(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
                {
                        List<PipelineStepDestination> records = await this.pipelineStepRepository.PipelineStepDestinations(pipelineStepId, limit, offset);

                        return this.bolPipelineStepDestinationMapper.MapBOToModel(this.dalPipelineStepDestinationMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiPipelineStepNoteResponseModel>> PipelineStepNotes(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
                {
                        List<PipelineStepNote> records = await this.pipelineStepRepository.PipelineStepNotes(pipelineStepId, limit, offset);

                        return this.bolPipelineStepNoteMapper.MapBOToModel(this.dalPipelineStepNoteMapper.MapEFToBO(records));
                }
                public async virtual Task<List<ApiPipelineStepStepRequirementResponseModel>> PipelineStepStepRequirements(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
                {
                        List<PipelineStepStepRequirement> records = await this.pipelineStepRepository.PipelineStepStepRequirements(pipelineStepId, limit, offset);

                        return this.bolPipelineStepStepRequirementMapper.MapBOToModel(this.dalPipelineStepStepRequirementMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>82f8e89beb4a3ea2cfcf6df153e2afb4</Hash>
</Codenesium>*/