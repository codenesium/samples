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
        public abstract class AbstractPipelineStepNoteService : AbstractService
        {
                private IPipelineStepNoteRepository pipelineStepNoteRepository;

                private IApiPipelineStepNoteRequestModelValidator pipelineStepNoteModelValidator;

                private IBOLPipelineStepNoteMapper bolPipelineStepNoteMapper;

                private IDALPipelineStepNoteMapper dalPipelineStepNoteMapper;

                private ILogger logger;

                public AbstractPipelineStepNoteService(
                        ILogger logger,
                        IPipelineStepNoteRepository pipelineStepNoteRepository,
                        IApiPipelineStepNoteRequestModelValidator pipelineStepNoteModelValidator,
                        IBOLPipelineStepNoteMapper bolPipelineStepNoteMapper,
                        IDALPipelineStepNoteMapper dalPipelineStepNoteMapper)
                        : base()
                {
                        this.pipelineStepNoteRepository = pipelineStepNoteRepository;
                        this.pipelineStepNoteModelValidator = pipelineStepNoteModelValidator;
                        this.bolPipelineStepNoteMapper = bolPipelineStepNoteMapper;
                        this.dalPipelineStepNoteMapper = dalPipelineStepNoteMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPipelineStepNoteResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.pipelineStepNoteRepository.All(limit, offset);

                        return this.bolPipelineStepNoteMapper.MapBOToModel(this.dalPipelineStepNoteMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiPipelineStepNoteResponseModel> Get(int id)
                {
                        var record = await this.pipelineStepNoteRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolPipelineStepNoteMapper.MapBOToModel(this.dalPipelineStepNoteMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiPipelineStepNoteResponseModel>> Create(
                        ApiPipelineStepNoteRequestModel model)
                {
                        CreateResponse<ApiPipelineStepNoteResponseModel> response = new CreateResponse<ApiPipelineStepNoteResponseModel>(await this.pipelineStepNoteModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolPipelineStepNoteMapper.MapModelToBO(default(int), model);
                                var record = await this.pipelineStepNoteRepository.Create(this.dalPipelineStepNoteMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolPipelineStepNoteMapper.MapBOToModel(this.dalPipelineStepNoteMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiPipelineStepNoteResponseModel>> Update(
                        int id,
                        ApiPipelineStepNoteRequestModel model)
                {
                        var validationResult = await this.pipelineStepNoteModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolPipelineStepNoteMapper.MapModelToBO(id, model);
                                await this.pipelineStepNoteRepository.Update(this.dalPipelineStepNoteMapper.MapBOToEF(bo));

                                var record = await this.pipelineStepNoteRepository.Get(id);

                                return new UpdateResponse<ApiPipelineStepNoteResponseModel>(this.bolPipelineStepNoteMapper.MapBOToModel(this.dalPipelineStepNoteMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiPipelineStepNoteResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.pipelineStepNoteModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.pipelineStepNoteRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>a27806e5d88860f2a1d7811521a25fa9</Hash>
</Codenesium>*/