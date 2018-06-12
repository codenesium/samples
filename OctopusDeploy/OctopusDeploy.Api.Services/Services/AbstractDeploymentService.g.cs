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
        public abstract class AbstractDeploymentService: AbstractService
        {
                private IDeploymentRepository deploymentRepository;

                private IApiDeploymentRequestModelValidator deploymentModelValidator;

                private IBOLDeploymentMapper bolDeploymentMapper;

                private IDALDeploymentMapper dalDeploymentMapper;

                private ILogger logger;

                public AbstractDeploymentService(
                        ILogger logger,
                        IDeploymentRepository deploymentRepository,
                        IApiDeploymentRequestModelValidator deploymentModelValidator,
                        IBOLDeploymentMapper boldeploymentMapper,
                        IDALDeploymentMapper daldeploymentMapper)
                        : base()

                {
                        this.deploymentRepository = deploymentRepository;
                        this.deploymentModelValidator = deploymentModelValidator;
                        this.bolDeploymentMapper = boldeploymentMapper;
                        this.dalDeploymentMapper = daldeploymentMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiDeploymentResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.deploymentRepository.All(skip, take, orderClause);

                        return this.bolDeploymentMapper.MapBOToModel(this.dalDeploymentMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiDeploymentResponseModel> Get(string id)
                {
                        var record = await this.deploymentRepository.Get(id);

                        return this.bolDeploymentMapper.MapBOToModel(this.dalDeploymentMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiDeploymentResponseModel>> Create(
                        ApiDeploymentRequestModel model)
                {
                        CreateResponse<ApiDeploymentResponseModel> response = new CreateResponse<ApiDeploymentResponseModel>(await this.deploymentModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolDeploymentMapper.MapModelToBO(default (string), model);
                                var record = await this.deploymentRepository.Create(this.dalDeploymentMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolDeploymentMapper.MapBOToModel(this.dalDeploymentMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiDeploymentRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.deploymentModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolDeploymentMapper.MapModelToBO(id, model);
                                await this.deploymentRepository.Update(this.dalDeploymentMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.deploymentModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.deploymentRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<List<ApiDeploymentResponseModel>> GetChannelId(string channelId)
                {
                        List<Deployment> records = await this.deploymentRepository.GetChannelId(channelId);

                        return this.bolDeploymentMapper.MapBOToModel(this.dalDeploymentMapper.MapEFToBO(records));
                }
                public async Task<List<ApiDeploymentResponseModel>> GetIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(string id, string projectId, string projectGroupId, string name, DateTime created, string releaseId, string taskId, string environmentId)
                {
                        List<Deployment> records = await this.deploymentRepository.GetIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(id, projectId, projectGroupId, name, created, releaseId, taskId, environmentId);

                        return this.bolDeploymentMapper.MapBOToModel(this.dalDeploymentMapper.MapEFToBO(records));
                }
                public async Task<List<ApiDeploymentResponseModel>> GetTenantId(string tenantId)
                {
                        List<Deployment> records = await this.deploymentRepository.GetTenantId(tenantId);

                        return this.bolDeploymentMapper.MapBOToModel(this.dalDeploymentMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>b30527b5decc085564775c6f0f66533c</Hash>
</Codenesium>*/