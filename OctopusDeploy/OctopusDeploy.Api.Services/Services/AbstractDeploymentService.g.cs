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
        public abstract class AbstractDeploymentService : AbstractService
        {
                private IDeploymentRepository deploymentRepository;

                private IApiDeploymentRequestModelValidator deploymentModelValidator;

                private IBOLDeploymentMapper bolDeploymentMapper;

                private IDALDeploymentMapper dalDeploymentMapper;

                private IBOLDeploymentRelatedMachineMapper bolDeploymentRelatedMachineMapper;

                private IDALDeploymentRelatedMachineMapper dalDeploymentRelatedMachineMapper;

                private ILogger logger;

                public AbstractDeploymentService(
                        ILogger logger,
                        IDeploymentRepository deploymentRepository,
                        IApiDeploymentRequestModelValidator deploymentModelValidator,
                        IBOLDeploymentMapper bolDeploymentMapper,
                        IDALDeploymentMapper dalDeploymentMapper,
                        IBOLDeploymentRelatedMachineMapper bolDeploymentRelatedMachineMapper,
                        IDALDeploymentRelatedMachineMapper dalDeploymentRelatedMachineMapper)
                        : base()
                {
                        this.deploymentRepository = deploymentRepository;
                        this.deploymentModelValidator = deploymentModelValidator;
                        this.bolDeploymentMapper = bolDeploymentMapper;
                        this.dalDeploymentMapper = dalDeploymentMapper;
                        this.bolDeploymentRelatedMachineMapper = bolDeploymentRelatedMachineMapper;
                        this.dalDeploymentRelatedMachineMapper = dalDeploymentRelatedMachineMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiDeploymentResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.deploymentRepository.All(limit, offset);

                        return this.bolDeploymentMapper.MapBOToModel(this.dalDeploymentMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiDeploymentResponseModel> Get(string id)
                {
                        var record = await this.deploymentRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolDeploymentMapper.MapBOToModel(this.dalDeploymentMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiDeploymentResponseModel>> Create(
                        ApiDeploymentRequestModel model)
                {
                        CreateResponse<ApiDeploymentResponseModel> response = new CreateResponse<ApiDeploymentResponseModel>(await this.deploymentModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolDeploymentMapper.MapModelToBO(default(string), model);
                                var record = await this.deploymentRepository.Create(this.dalDeploymentMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolDeploymentMapper.MapBOToModel(this.dalDeploymentMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiDeploymentResponseModel>> Update(
                        string id,
                        ApiDeploymentRequestModel model)
                {
                        var validationResult = await this.deploymentModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolDeploymentMapper.MapModelToBO(id, model);
                                await this.deploymentRepository.Update(this.dalDeploymentMapper.MapBOToEF(bo));

                                var record = await this.deploymentRepository.Get(id);

                                return new UpdateResponse<ApiDeploymentResponseModel>(this.bolDeploymentMapper.MapBOToModel(this.dalDeploymentMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiDeploymentResponseModel>(validationResult);
                        }
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

                public async Task<List<ApiDeploymentResponseModel>> ByChannelId(string channelId)
                {
                        List<Deployment> records = await this.deploymentRepository.ByChannelId(channelId);

                        return this.bolDeploymentMapper.MapBOToModel(this.dalDeploymentMapper.MapEFToBO(records));
                }

                public async Task<List<ApiDeploymentResponseModel>> ByIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(string id, string projectId, string projectGroupId, string name, DateTimeOffset created, string releaseId, string taskId, string environmentId)
                {
                        List<Deployment> records = await this.deploymentRepository.ByIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(id, projectId, projectGroupId, name, created, releaseId, taskId, environmentId);

                        return this.bolDeploymentMapper.MapBOToModel(this.dalDeploymentMapper.MapEFToBO(records));
                }

                public async Task<List<ApiDeploymentResponseModel>> ByTenantId(string tenantId)
                {
                        List<Deployment> records = await this.deploymentRepository.ByTenantId(tenantId);

                        return this.bolDeploymentMapper.MapBOToModel(this.dalDeploymentMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiDeploymentRelatedMachineResponseModel>> DeploymentRelatedMachines(string deploymentId, int limit = int.MaxValue, int offset = 0)
                {
                        List<DeploymentRelatedMachine> records = await this.deploymentRepository.DeploymentRelatedMachines(deploymentId, limit, offset);

                        return this.bolDeploymentRelatedMachineMapper.MapBOToModel(this.dalDeploymentRelatedMachineMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>a0c0d463781ad2d1a1e33ead491a8bcc</Hash>
</Codenesium>*/