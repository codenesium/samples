using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractInterruptionService : AbstractService
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
                        IBOLInterruptionMapper bolInterruptionMapper,
                        IDALInterruptionMapper dalInterruptionMapper)
                        : base()
                {
                        this.interruptionRepository = interruptionRepository;
                        this.interruptionModelValidator = interruptionModelValidator;
                        this.bolInterruptionMapper = bolInterruptionMapper;
                        this.dalInterruptionMapper = dalInterruptionMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiInterruptionResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.interruptionRepository.All(limit, offset);

                        return this.bolInterruptionMapper.MapBOToModel(this.dalInterruptionMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiInterruptionResponseModel> Get(string id)
                {
                        var record = await this.interruptionRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolInterruptionMapper.MapBOToModel(this.dalInterruptionMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiInterruptionResponseModel>> Create(
                        ApiInterruptionRequestModel model)
                {
                        CreateResponse<ApiInterruptionResponseModel> response = new CreateResponse<ApiInterruptionResponseModel>(await this.interruptionModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolInterruptionMapper.MapModelToBO(default(string), model);
                                var record = await this.interruptionRepository.Create(this.dalInterruptionMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolInterruptionMapper.MapBOToModel(this.dalInterruptionMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiInterruptionResponseModel>> Update(
                        string id,
                        ApiInterruptionRequestModel model)
                {
                        var validationResult = await this.interruptionModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolInterruptionMapper.MapModelToBO(id, model);
                                await this.interruptionRepository.Update(this.dalInterruptionMapper.MapBOToEF(bo));

                                var record = await this.interruptionRepository.Get(id);

                                return new UpdateResponse<ApiInterruptionResponseModel>(this.bolInterruptionMapper.MapBOToModel(this.dalInterruptionMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiInterruptionResponseModel>(validationResult);
                        }
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

                public async Task<List<ApiInterruptionResponseModel>> ByTenantId(string tenantId)
                {
                        List<Interruption> records = await this.interruptionRepository.ByTenantId(tenantId);

                        return this.bolInterruptionMapper.MapBOToModel(this.dalInterruptionMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>a6e6b6062487aa9cee583bea9919fdc3</Hash>
</Codenesium>*/