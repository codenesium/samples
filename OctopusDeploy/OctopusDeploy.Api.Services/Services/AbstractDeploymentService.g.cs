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
		protected IDeploymentRepository DeploymentRepository { get; private set; }

		protected IApiDeploymentRequestModelValidator DeploymentModelValidator { get; private set; }

		protected IBOLDeploymentMapper BolDeploymentMapper { get; private set; }

		protected IDALDeploymentMapper DalDeploymentMapper { get; private set; }

		protected IBOLDeploymentRelatedMachineMapper BolDeploymentRelatedMachineMapper { get; private set; }

		protected IDALDeploymentRelatedMachineMapper DalDeploymentRelatedMachineMapper { get; private set; }

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
			this.DeploymentRepository = deploymentRepository;
			this.DeploymentModelValidator = deploymentModelValidator;
			this.BolDeploymentMapper = bolDeploymentMapper;
			this.DalDeploymentMapper = dalDeploymentMapper;
			this.BolDeploymentRelatedMachineMapper = bolDeploymentRelatedMachineMapper;
			this.DalDeploymentRelatedMachineMapper = dalDeploymentRelatedMachineMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDeploymentResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.DeploymentRepository.All(limit, offset);

			return this.BolDeploymentMapper.MapBOToModel(this.DalDeploymentMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDeploymentResponseModel> Get(string id)
		{
			var record = await this.DeploymentRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolDeploymentMapper.MapBOToModel(this.DalDeploymentMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiDeploymentResponseModel>> Create(
			ApiDeploymentRequestModel model)
		{
			CreateResponse<ApiDeploymentResponseModel> response = new CreateResponse<ApiDeploymentResponseModel>(await this.DeploymentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolDeploymentMapper.MapModelToBO(default(string), model);
				var record = await this.DeploymentRepository.Create(this.DalDeploymentMapper.MapBOToEF(bo));

				response.SetRecord(this.BolDeploymentMapper.MapBOToModel(this.DalDeploymentMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDeploymentResponseModel>> Update(
			string id,
			ApiDeploymentRequestModel model)
		{
			var validationResult = await this.DeploymentModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolDeploymentMapper.MapModelToBO(id, model);
				await this.DeploymentRepository.Update(this.DalDeploymentMapper.MapBOToEF(bo));

				var record = await this.DeploymentRepository.Get(id);

				return new UpdateResponse<ApiDeploymentResponseModel>(this.BolDeploymentMapper.MapBOToModel(this.DalDeploymentMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiDeploymentResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.DeploymentModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.DeploymentRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiDeploymentResponseModel>> ByChannelId(string channelId)
		{
			List<Deployment> records = await this.DeploymentRepository.ByChannelId(channelId);

			return this.BolDeploymentMapper.MapBOToModel(this.DalDeploymentMapper.MapEFToBO(records));
		}

		public async Task<List<ApiDeploymentResponseModel>> ByIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(string id, string projectId, string projectGroupId, string name, DateTimeOffset created, string releaseId, string taskId, string environmentId)
		{
			List<Deployment> records = await this.DeploymentRepository.ByIdProjectIdProjectGroupIdNameCreatedReleaseIdTaskIdEnvironmentId(id, projectId, projectGroupId, name, created, releaseId, taskId, environmentId);

			return this.BolDeploymentMapper.MapBOToModel(this.DalDeploymentMapper.MapEFToBO(records));
		}

		public async Task<List<ApiDeploymentResponseModel>> ByTenantId(string tenantId)
		{
			List<Deployment> records = await this.DeploymentRepository.ByTenantId(tenantId);

			return this.BolDeploymentMapper.MapBOToModel(this.DalDeploymentMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiDeploymentRelatedMachineResponseModel>> DeploymentRelatedMachines(string deploymentId, int limit = int.MaxValue, int offset = 0)
		{
			List<DeploymentRelatedMachine> records = await this.DeploymentRepository.DeploymentRelatedMachines(deploymentId, limit, offset);

			return this.BolDeploymentRelatedMachineMapper.MapBOToModel(this.DalDeploymentRelatedMachineMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>8a67c638a3c38d7d6f78e033cce3c181</Hash>
</Codenesium>*/