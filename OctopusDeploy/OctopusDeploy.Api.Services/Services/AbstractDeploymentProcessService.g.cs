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
        public abstract class AbstractDeploymentProcessService: AbstractService
        {
                private IDeploymentProcessRepository deploymentProcessRepository;

                private IApiDeploymentProcessRequestModelValidator deploymentProcessModelValidator;

                private IBOLDeploymentProcessMapper bolDeploymentProcessMapper;

                private IDALDeploymentProcessMapper dalDeploymentProcessMapper;

                private ILogger logger;

                public AbstractDeploymentProcessService(
                        ILogger logger,
                        IDeploymentProcessRepository deploymentProcessRepository,
                        IApiDeploymentProcessRequestModelValidator deploymentProcessModelValidator,
                        IBOLDeploymentProcessMapper boldeploymentProcessMapper,
                        IDALDeploymentProcessMapper daldeploymentProcessMapper)
                        : base()

                {
                        this.deploymentProcessRepository = deploymentProcessRepository;
                        this.deploymentProcessModelValidator = deploymentProcessModelValidator;
                        this.bolDeploymentProcessMapper = boldeploymentProcessMapper;
                        this.dalDeploymentProcessMapper = daldeploymentProcessMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiDeploymentProcessResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.deploymentProcessRepository.All(skip, take, orderClause);

                        return this.bolDeploymentProcessMapper.MapBOToModel(this.dalDeploymentProcessMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiDeploymentProcessResponseModel> Get(string id)
                {
                        var record = await this.deploymentProcessRepository.Get(id);

                        return this.bolDeploymentProcessMapper.MapBOToModel(this.dalDeploymentProcessMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiDeploymentProcessResponseModel>> Create(
                        ApiDeploymentProcessRequestModel model)
                {
                        CreateResponse<ApiDeploymentProcessResponseModel> response = new CreateResponse<ApiDeploymentProcessResponseModel>(await this.deploymentProcessModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolDeploymentProcessMapper.MapModelToBO(default (string), model);
                                var record = await this.deploymentProcessRepository.Create(this.dalDeploymentProcessMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolDeploymentProcessMapper.MapBOToModel(this.dalDeploymentProcessMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiDeploymentProcessRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.deploymentProcessModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolDeploymentProcessMapper.MapModelToBO(id, model);
                                await this.deploymentProcessRepository.Update(this.dalDeploymentProcessMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.deploymentProcessModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.deploymentProcessRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>91576c6d91c8fa7806ab9a3be4ec07f1</Hash>
</Codenesium>*/