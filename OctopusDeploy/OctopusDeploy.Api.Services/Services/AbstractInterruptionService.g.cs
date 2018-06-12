using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractInterruptionService: AbstractService
        {
                private IInterruptionRepository interruptionRepository;

                private IApiInterruptionRequestModelValidator interruptionModelValidator;

                private IBOLInterruptionMapper bolInterruptionMapper;

                private IDALInterruptionMapper dalInterruptionMapper;

                private ILogger logger;

                public AbstractInterruptionService(
                        ILogger logger,
                        IInterruptionRepository interruptionRepository,
                        IApiInterruptionRequestModelValidator interruptionModelValidator,
                        IBOLInterruptionMapper bolinterruptionMapper,
                        IDALInterruptionMapper dalinterruptionMapper)
                        : base()

                {
                        this.interruptionRepository = interruptionRepository;
                        this.interruptionModelValidator = interruptionModelValidator;
                        this.bolInterruptionMapper = bolinterruptionMapper;
                        this.dalInterruptionMapper = dalinterruptionMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiInterruptionResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.interruptionRepository.All(skip, take, orderClause);

                        return this.bolInterruptionMapper.MapBOToModel(this.dalInterruptionMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiInterruptionResponseModel> Get(string id)
                {
                        var record = await this.interruptionRepository.Get(id);

                        return this.bolInterruptionMapper.MapBOToModel(this.dalInterruptionMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiInterruptionResponseModel>> Create(
                        ApiInterruptionRequestModel model)
                {
                        CreateResponse<ApiInterruptionResponseModel> response = new CreateResponse<ApiInterruptionResponseModel>(await this.interruptionModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolInterruptionMapper.MapModelToBO(default (string), model);
                                var record = await this.interruptionRepository.Create(this.dalInterruptionMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolInterruptionMapper.MapBOToModel(this.dalInterruptionMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiInterruptionRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.interruptionModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolInterruptionMapper.MapModelToBO(id, model);
                                await this.interruptionRepository.Update(this.dalInterruptionMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.interruptionModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.interruptionRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<List<ApiInterruptionResponseModel>> GetTenantId(string tenantId)
                {
                        List<Interruption> records = await this.interruptionRepository.GetTenantId(tenantId);

                        return this.bolInterruptionMapper.MapBOToModel(this.dalInterruptionMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>e5ded25861de96ce748fc8c8abed6358</Hash>
</Codenesium>*/