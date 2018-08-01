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
		private IDeploymentHistoryRepository deploymentHistoryRepository;

		private IApiDeploymentHistoryRequestModelValidator deploymentHistoryModelValidator;

		private IBOLDeploymentHistoryMapper bolDeploymentHistoryMapper;

		private IDALDeploymentHistoryMapper dalDeploymentHistoryMapper;

		private ILogger logger;

		public AbstractDeploymentHistoryService(
			ILogger logger,
			IDeploymentHistoryRepository deploymentHistoryRepository,
			IApiDeploymentHistoryRequestModelValidator deploymentHistoryModelValidator,
			IBOLDeploymentHistoryMapper bolDeploymentHistoryMapper,
			IDALDeploymentHistoryMapper dalDeploymentHistoryMapper)
			: base()
		{
			this.deploymentHistoryRepository = deploymentHistoryRepository;
			this.deploymentHistoryModelValidator = deploymentHistoryModelValidator;
			this.bolDeploymentHistoryMapper = bolDeploymentHistoryMapper;
			this.dalDeploymentHistoryMapper = dalDeploymentHistoryMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDeploymentHistoryResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.deploymentHistoryRepository.All(limit, offset);

			return this.bolDeploymentHistoryMapper.MapBOToModel(this.dalDeploymentHistoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDeploymentHistoryResponseModel> Get(string deploymentId)
		{
			var record = await this.deploymentHistoryRepository.Get(deploymentId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolDeploymentHistoryMapper.MapBOToModel(this.dalDeploymentHistoryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiDeploymentHistoryResponseModel>> Create(
			ApiDeploymentHistoryRequestModel model)
		{
			CreateResponse<ApiDeploymentHistoryResponseModel> response = new CreateResponse<ApiDeploymentHistoryResponseModel>(await this.deploymentHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolDeploymentHistoryMapper.MapModelToBO(default(string), model);
				var record = await this.deploymentHistoryRepository.Create(this.dalDeploymentHistoryMapper.MapBOToEF(bo));

				response.SetRecord(this.bolDeploymentHistoryMapper.MapBOToModel(this.dalDeploymentHistoryMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDeploymentHistoryResponseModel>> Update(
			string deploymentId,
			ApiDeploymentHistoryRequestModel model)
		{
			var validationResult = await this.deploymentHistoryModelValidator.ValidateUpdateAsync(deploymentId, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolDeploymentHistoryMapper.MapModelToBO(deploymentId, model);
				await this.deploymentHistoryRepository.Update(this.dalDeploymentHistoryMapper.MapBOToEF(bo));

				var record = await this.deploymentHistoryRepository.Get(deploymentId);

				return new UpdateResponse<ApiDeploymentHistoryResponseModel>(this.bolDeploymentHistoryMapper.MapBOToModel(this.dalDeploymentHistoryMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiDeploymentHistoryResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string deploymentId)
		{
			ActionResponse response = new ActionResponse(await this.deploymentHistoryModelValidator.ValidateDeleteAsync(deploymentId));
			if (response.Success)
			{
				await this.deploymentHistoryRepository.Delete(deploymentId);
			}

			return response;
		}

		public async Task<List<ApiDeploymentHistoryResponseModel>> ByCreated(DateTimeOffset created)
		{
			List<DeploymentHistory> records = await this.deploymentHistoryRepository.ByCreated(created);

			return this.bolDeploymentHistoryMapper.MapBOToModel(this.dalDeploymentHistoryMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>ab7debc390281af439d3bcc4e2c5e06b</Hash>
</Codenesium>*/