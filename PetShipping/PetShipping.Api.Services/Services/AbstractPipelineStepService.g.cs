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

                private ILogger logger;

                public AbstractPipelineStepService(
                        ILogger logger,
                        IPipelineStepRepository pipelineStepRepository,
                        IApiPipelineStepRequestModelValidator pipelineStepModelValidator,
                        IBOLPipelineStepMapper bolpipelineStepMapper,
                        IDALPipelineStepMapper dalpipelineStepMapper)
                        : base()

                {
                        this.pipelineStepRepository = pipelineStepRepository;
                        this.pipelineStepModelValidator = pipelineStepModelValidator;
                        this.bolPipelineStepMapper = bolpipelineStepMapper;
                        this.dalPipelineStepMapper = dalpipelineStepMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPipelineStepResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.pipelineStepRepository.All(skip, take, orderClause);

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
        }
}

/*<Codenesium>
    <Hash>998da0630bf4961b45e130181b82bcb2</Hash>
</Codenesium>*/