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
	public abstract class AbstractServerTaskService : AbstractService
	{
		protected IServerTaskRepository ServerTaskRepository { get; private set; }

		protected IApiServerTaskRequestModelValidator ServerTaskModelValidator { get; private set; }

		protected IBOLServerTaskMapper BolServerTaskMapper { get; private set; }

		protected IDALServerTaskMapper DalServerTaskMapper { get; private set; }

		private ILogger logger;

		public AbstractServerTaskService(
			ILogger logger,
			IServerTaskRepository serverTaskRepository,
			IApiServerTaskRequestModelValidator serverTaskModelValidator,
			IBOLServerTaskMapper bolServerTaskMapper,
			IDALServerTaskMapper dalServerTaskMapper)
			: base()
		{
			this.ServerTaskRepository = serverTaskRepository;
			this.ServerTaskModelValidator = serverTaskModelValidator;
			this.BolServerTaskMapper = bolServerTaskMapper;
			this.DalServerTaskMapper = dalServerTaskMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiServerTaskResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ServerTaskRepository.All(limit, offset);

			return this.BolServerTaskMapper.MapBOToModel(this.DalServerTaskMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiServerTaskResponseModel> Get(string id)
		{
			var record = await this.ServerTaskRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolServerTaskMapper.MapBOToModel(this.DalServerTaskMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiServerTaskResponseModel>> Create(
			ApiServerTaskRequestModel model)
		{
			CreateResponse<ApiServerTaskResponseModel> response = new CreateResponse<ApiServerTaskResponseModel>(await this.ServerTaskModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolServerTaskMapper.MapModelToBO(default(string), model);
				var record = await this.ServerTaskRepository.Create(this.DalServerTaskMapper.MapBOToEF(bo));

				response.SetRecord(this.BolServerTaskMapper.MapBOToModel(this.DalServerTaskMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiServerTaskResponseModel>> Update(
			string id,
			ApiServerTaskRequestModel model)
		{
			var validationResult = await this.ServerTaskModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolServerTaskMapper.MapModelToBO(id, model);
				await this.ServerTaskRepository.Update(this.DalServerTaskMapper.MapBOToEF(bo));

				var record = await this.ServerTaskRepository.Get(id);

				return new UpdateResponse<ApiServerTaskResponseModel>(this.BolServerTaskMapper.MapBOToModel(this.DalServerTaskMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiServerTaskResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.ServerTaskModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.ServerTaskRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiServerTaskResponseModel>> ByDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(string description, DateTimeOffset queueTime, DateTimeOffset? startTime, DateTimeOffset? completedTime, string errorMessage, string concurrencyTag, bool hasPendingInterruptions, bool hasWarningsOrErrors, int durationSeconds, string jSON, string state, string name, string projectId, string environmentId, string tenantId, string serverNodeId)
		{
			List<ServerTask> records = await this.ServerTaskRepository.ByDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(description, queueTime, startTime, completedTime, errorMessage, concurrencyTag, hasPendingInterruptions, hasWarningsOrErrors, durationSeconds, jSON, state, name, projectId, environmentId, tenantId, serverNodeId);

			return this.BolServerTaskMapper.MapBOToModel(this.DalServerTaskMapper.MapEFToBO(records));
		}

		public async Task<List<ApiServerTaskResponseModel>> ByStateConcurrencyTag(string state, string concurrencyTag)
		{
			List<ServerTask> records = await this.ServerTaskRepository.ByStateConcurrencyTag(state, concurrencyTag);

			return this.BolServerTaskMapper.MapBOToModel(this.DalServerTaskMapper.MapEFToBO(records));
		}

		public async Task<List<ApiServerTaskResponseModel>> ByNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(string name, string description, DateTimeOffset? startTime, DateTimeOffset? completedTime, string errorMessage, bool hasWarningsOrErrors, string projectId, string environmentId, string tenantId, int durationSeconds, string jSON, DateTimeOffset queueTime, string state, string concurrencyTag, bool hasPendingInterruptions, string serverNodeId)
		{
			List<ServerTask> records = await this.ServerTaskRepository.ByNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(name, description, startTime, completedTime, errorMessage, hasWarningsOrErrors, projectId, environmentId, tenantId, durationSeconds, jSON, queueTime, state, concurrencyTag, hasPendingInterruptions, serverNodeId);

			return this.BolServerTaskMapper.MapBOToModel(this.DalServerTaskMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>26d5117dfa2fd678c2fbf84fe4fd1a04</Hash>
</Codenesium>*/