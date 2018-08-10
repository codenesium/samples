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
	public abstract class AbstractDeploymentHistoryService : AbstractService
	{
		protected IDeploymentHistoryRepository DeploymentHistoryRepository { get; private set; }

		protected IApiDeploymentHistoryRequestModelValidator DeploymentHistoryModelValidator { get; private set; }

		protected IBOLDeploymentHistoryMapper BolDeploymentHistoryMapper { get; private set; }

		protected IDALDeploymentHistoryMapper DalDeploymentHistoryMapper { get; private set; }

		private ILogger logger;

		public AbstractDeploymentHistoryService(
			ILogger logger,
			IDeploymentHistoryRepository deploymentHistoryRepository,
			IApiDeploymentHistoryRequestModelValidator deploymentHistoryModelValidator,
			IBOLDeploymentHistoryMapper bolDeploymentHistoryMapper,
			IDALDeploymentHistoryMapper dalDeploymentHistoryMapper)
			: base()
		{
			this.DeploymentHistoryRepository = deploymentHistoryRepository;
			this.DeploymentHistoryModelValidator = deploymentHistoryModelValidator;
			this.BolDeploymentHistoryMapper = bolDeploymentHistoryMapper;
			this.DalDeploymentHistoryMapper = dalDeploymentHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDeploymentHistoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.DeploymentHistoryRepository.All(limit, offset);

			return this.BolDeploymentHistoryMapper.MapBOToModel(this.DalDeploymentHistoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDeploymentHistoryResponseModel> Get(string deploymentId)
		{
			var record = await this.DeploymentHistoryRepository.Get(deploymentId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolDeploymentHistoryMapper.MapBOToModel(this.DalDeploymentHistoryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiDeploymentHistoryResponseModel>> Create(
			ApiDeploymentHistoryRequestModel model)
		{
			CreateResponse<ApiDeploymentHistoryResponseModel> response = new CreateResponse<ApiDeploymentHistoryResponseModel>(await this.DeploymentHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolDeploymentHistoryMapper.MapModelToBO(default(string), model);
				var record = await this.DeploymentHistoryRepository.Create(this.DalDeploymentHistoryMapper.MapBOToEF(bo));

				response.SetRecord(this.BolDeploymentHistoryMapper.MapBOToModel(this.DalDeploymentHistoryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDeploymentHistoryResponseModel>> Update(
			string deploymentId,
			ApiDeploymentHistoryRequestModel model)
		{
			var validationResult = await this.DeploymentHistoryModelValidator.ValidateUpdateAsync(deploymentId, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolDeploymentHistoryMapper.MapModelToBO(deploymentId, model);
				await this.DeploymentHistoryRepository.Update(this.DalDeploymentHistoryMapper.MapBOToEF(bo));

				var record = await this.DeploymentHistoryRepository.Get(deploymentId);

				return new UpdateResponse<ApiDeploymentHistoryResponseModel>(this.BolDeploymentHistoryMapper.MapBOToModel(this.DalDeploymentHistoryMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiDeploymentHistoryResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string deploymentId)
		{
			ActionResponse response = new ActionResponse(await this.DeploymentHistoryModelValidator.ValidateDeleteAsync(deploymentId));
			if (response.Success)
			{
				await this.DeploymentHistoryRepository.Delete(deploymentId);
			}

			return response;
		}

		public async Task<List<ApiDeploymentHistoryResponseModel>> ByCreated(DateTimeOffset created)
		{
			List<DeploymentHistory> records = await this.DeploymentHistoryRepository.ByCreated(created);

			return this.BolDeploymentHistoryMapper.MapBOToModel(this.DalDeploymentHistoryMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>16cab4773fd89a073c838f0d7f0faf4d</Hash>
</Codenesium>*/