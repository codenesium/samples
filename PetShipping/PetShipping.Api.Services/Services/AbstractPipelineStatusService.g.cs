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
        public abstract class AbstractPipelineStatusService : AbstractService
        {
                private IPipelineStatusRepository pipelineStatusRepository;

                private IApiPipelineStatusRequestModelValidator pipelineStatusModelValidator;

                private IBOLPipelineStatusMapper bolPipelineStatusMapper;

                private IDALPipelineStatusMapper dalPipelineStatusMapper;

                private IBOLPipelineMapper bolPipelineMapper;

                private IDALPipelineMapper dalPipelineMapper;

                private ILogger logger;

                public AbstractPipelineStatusService(
                        ILogger logger,
                        IPipelineStatusRepository pipelineStatusRepository,
                        IApiPipelineStatusRequestModelValidator pipelineStatusModelValidator,
                        IBOLPipelineStatusMapper bolPipelineStatusMapper,
                        IDALPipelineStatusMapper dalPipelineStatusMapper,
                        IBOLPipelineMapper bolPipelineMapper,
                        IDALPipelineMapper dalPipelineMapper)
                        : base()
                {
                        this.pipelineStatusRepository = pipelineStatusRepository;
                        this.pipelineStatusModelValidator = pipelineStatusModelValidator;
                        this.bolPipelineStatusMapper = bolPipelineStatusMapper;
                        this.dalPipelineStatusMapper = dalPipelineStatusMapper;
                        this.bolPipelineMapper = bolPipelineMapper;
                        this.dalPipelineMapper = dalPipelineMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPipelineStatusResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.pipelineStatusRepository.All(limit, offset);

                        return this.bolPipelineStatusMapper.MapBOToModel(this.dalPipelineStatusMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiPipelineStatusResponseModel> Get(int id)
                {
                        var record = await this.pipelineStatusRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolPipelineStatusMapper.MapBOToModel(this.dalPipelineStatusMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiPipelineStatusResponseModel>> Create(
                        ApiPipelineStatusRequestModel model)
                {
                        CreateResponse<ApiPipelineStatusResponseModel> response = new CreateResponse<ApiPipelineStatusResponseModel>(await this.pipelineStatusModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolPipelineStatusMapper.MapModelToBO(default(int), model);
                                var record = await this.pipelineStatusRepository.Create(this.dalPipelineStatusMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolPipelineStatusMapper.MapBOToModel(this.dalPipelineStatusMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiPipelineStatusResponseModel>> Update(
                        int id,
                        ApiPipelineStatusRequestModel model)
                {
                        var validationResult = await this.pipelineStatusModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolPipelineStatusMapper.MapModelToBO(id, model);
                                await this.pipelineStatusRepository.Update(this.dalPipelineStatusMapper.MapBOToEF(bo));

                                var record = await this.pipelineStatusRepository.Get(id);

                                return new UpdateResponse<ApiPipelineStatusResponseModel>(this.bolPipelineStatusMapper.MapBOToModel(this.dalPipelineStatusMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiPipelineStatusResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.pipelineStatusModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.pipelineStatusRepository.Delete(id);
                        }

                        return response;
                }

                public async virtual Task<List<ApiPipelineResponseModel>> Pipelines(int pipelineStatusId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Pipeline> records = await this.pipelineStatusRepository.Pipelines(pipelineStatusId, limit, offset);

                        return this.bolPipelineMapper.MapBOToModel(this.dalPipelineMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>cfbe7c39f7dede7dad086b1acd36ef87</Hash>
</Codenesium>*/