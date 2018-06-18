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
        public abstract class AbstractPipelineStepStatusService: AbstractService
        {
                private IPipelineStepStatusRepository pipelineStepStatusRepository;

                private IApiPipelineStepStatusRequestModelValidator pipelineStepStatusModelValidator;

                private IBOLPipelineStepStatusMapper bolPipelineStepStatusMapper;

                private IDALPipelineStepStatusMapper dalPipelineStepStatusMapper;

                private IBOLPipelineStepMapper bolPipelineStepMapper;

                private IDALPipelineStepMapper dalPipelineStepMapper;

                private ILogger logger;

                public AbstractPipelineStepStatusService(
                        ILogger logger,
                        IPipelineStepStatusRepository pipelineStepStatusRepository,
                        IApiPipelineStepStatusRequestModelValidator pipelineStepStatusModelValidator,
                        IBOLPipelineStepStatusMapper bolPipelineStepStatusMapper,
                        IDALPipelineStepStatusMapper dalPipelineStepStatusMapper

                        ,
                        IBOLPipelineStepMapper bolPipelineStepMapper,
                        IDALPipelineStepMapper dalPipelineStepMapper

                        )
                        : base()

                {
                        this.pipelineStepStatusRepository = pipelineStepStatusRepository;
                        this.pipelineStepStatusModelValidator = pipelineStepStatusModelValidator;
                        this.bolPipelineStepStatusMapper = bolPipelineStepStatusMapper;
                        this.dalPipelineStepStatusMapper = dalPipelineStepStatusMapper;
                        this.bolPipelineStepMapper = bolPipelineStepMapper;
                        this.dalPipelineStepMapper = dalPipelineStepMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPipelineStepStatusResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.pipelineStepStatusRepository.All(limit, offset);

                        return this.bolPipelineStepStatusMapper.MapBOToModel(this.dalPipelineStepStatusMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiPipelineStepStatusResponseModel> Get(int id)
                {
                        var record = await this.pipelineStepStatusRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolPipelineStepStatusMapper.MapBOToModel(this.dalPipelineStepStatusMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiPipelineStepStatusResponseModel>> Create(
                        ApiPipelineStepStatusRequestModel model)
                {
                        CreateResponse<ApiPipelineStepStatusResponseModel> response = new CreateResponse<ApiPipelineStepStatusResponseModel>(await this.pipelineStepStatusModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolPipelineStepStatusMapper.MapModelToBO(default (int), model);
                                var record = await this.pipelineStepStatusRepository.Create(this.dalPipelineStepStatusMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolPipelineStepStatusMapper.MapBOToModel(this.dalPipelineStepStatusMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiPipelineStepStatusRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.pipelineStepStatusModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolPipelineStepStatusMapper.MapModelToBO(id, model);
                                await this.pipelineStepStatusRepository.Update(this.dalPipelineStepStatusMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.pipelineStepStatusModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.pipelineStepStatusRepository.Delete(id);
                        }

                        return response;
                }

                public async virtual Task<List<ApiPipelineStepResponseModel>> PipelineSteps(int pipelineStepStatusId, int limit = int.MaxValue, int offset = 0)
                {
                        List<PipelineStep> records = await this.pipelineStepStatusRepository.PipelineSteps(pipelineStepStatusId, limit, offset);

                        return this.bolPipelineStepMapper.MapBOToModel(this.dalPipelineStepMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>a456c5a574f08944284cb2011ec7ced7</Hash>
</Codenesium>*/