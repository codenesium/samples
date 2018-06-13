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
        public abstract class AbstractDestinationService: AbstractService
        {
                private IDestinationRepository destinationRepository;

                private IApiDestinationRequestModelValidator destinationModelValidator;

                private IBOLDestinationMapper bolDestinationMapper;

                private IDALDestinationMapper dalDestinationMapper;

                private IBOLPipelineStepDestinationMapper bolPipelineStepDestinationMapper;

                private IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper;

                private ILogger logger;

                public AbstractDestinationService(
                        ILogger logger,
                        IDestinationRepository destinationRepository,
                        IApiDestinationRequestModelValidator destinationModelValidator,
                        IBOLDestinationMapper bolDestinationMapper,
                        IDALDestinationMapper dalDestinationMapper

                        ,
                        IBOLPipelineStepDestinationMapper bolPipelineStepDestinationMapper,
                        IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper

                        )
                        : base()

                {
                        this.destinationRepository = destinationRepository;
                        this.destinationModelValidator = destinationModelValidator;
                        this.bolDestinationMapper = bolDestinationMapper;
                        this.dalDestinationMapper = dalDestinationMapper;
                        this.bolPipelineStepDestinationMapper = bolPipelineStepDestinationMapper;
                        this.dalPipelineStepDestinationMapper = dalPipelineStepDestinationMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiDestinationResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.destinationRepository.All(limit, offset, orderClause);

                        return this.bolDestinationMapper.MapBOToModel(this.dalDestinationMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiDestinationResponseModel> Get(int id)
                {
                        var record = await this.destinationRepository.Get(id);

                        return this.bolDestinationMapper.MapBOToModel(this.dalDestinationMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiDestinationResponseModel>> Create(
                        ApiDestinationRequestModel model)
                {
                        CreateResponse<ApiDestinationResponseModel> response = new CreateResponse<ApiDestinationResponseModel>(await this.destinationModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolDestinationMapper.MapModelToBO(default (int), model);
                                var record = await this.destinationRepository.Create(this.dalDestinationMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolDestinationMapper.MapBOToModel(this.dalDestinationMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiDestinationRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.destinationModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolDestinationMapper.MapModelToBO(id, model);
                                await this.destinationRepository.Update(this.dalDestinationMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.destinationModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.destinationRepository.Delete(id);
                        }

                        return response;
                }

                public async virtual Task<List<ApiPipelineStepDestinationResponseModel>> PipelineStepDestinations(int destinationId, int limit = int.MaxValue, int offset = 0)
                {
                        List<PipelineStepDestination> records = await this.destinationRepository.PipelineStepDestinations(destinationId, limit, offset);

                        return this.bolPipelineStepDestinationMapper.MapBOToModel(this.dalPipelineStepDestinationMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>27dbce4f2a2228e8dc4d6eb91393643f</Hash>
</Codenesium>*/