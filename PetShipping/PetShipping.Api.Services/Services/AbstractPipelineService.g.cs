using Codenesium.DataConversionExtensions.AspNetCore;
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
        public abstract class AbstractPipelineService : AbstractService
        {
                private IPipelineRepository pipelineRepository;

                private IApiPipelineRequestModelValidator pipelineModelValidator;

                private IBOLPipelineMapper bolPipelineMapper;

                private IDALPipelineMapper dalPipelineMapper;

                private ILogger logger;

                public AbstractPipelineService(
                        ILogger logger,
                        IPipelineRepository pipelineRepository,
                        IApiPipelineRequestModelValidator pipelineModelValidator,
                        IBOLPipelineMapper bolPipelineMapper,
                        IDALPipelineMapper dalPipelineMapper)
                        : base()
                {
                        this.pipelineRepository = pipelineRepository;
                        this.pipelineModelValidator = pipelineModelValidator;
                        this.bolPipelineMapper = bolPipelineMapper;
                        this.dalPipelineMapper = dalPipelineMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPipelineResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.pipelineRepository.All(limit, offset);

                        return this.bolPipelineMapper.MapBOToModel(this.dalPipelineMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiPipelineResponseModel> Get(int id)
                {
                        var record = await this.pipelineRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolPipelineMapper.MapBOToModel(this.dalPipelineMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiPipelineResponseModel>> Create(
                        ApiPipelineRequestModel model)
                {
                        CreateResponse<ApiPipelineResponseModel> response = new CreateResponse<ApiPipelineResponseModel>(await this.pipelineModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolPipelineMapper.MapModelToBO(default(int), model);
                                var record = await this.pipelineRepository.Create(this.dalPipelineMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolPipelineMapper.MapBOToModel(this.dalPipelineMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiPipelineRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.pipelineModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolPipelineMapper.MapModelToBO(id, model);
                                await this.pipelineRepository.Update(this.dalPipelineMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.pipelineModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.pipelineRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>a3b7ed8056a1a2dc4ba9434087e4df04</Hash>
</Codenesium>*/