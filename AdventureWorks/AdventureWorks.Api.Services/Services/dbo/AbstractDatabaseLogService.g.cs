using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDatabaseLogService : AbstractService
	{
		private IMediator mediator;

		protected IDatabaseLogRepository DatabaseLogRepository { get; private set; }

		protected IApiDatabaseLogServerRequestModelValidator DatabaseLogModelValidator { get; private set; }

		protected IDALDatabaseLogMapper DalDatabaseLogMapper { get; private set; }

		private ILogger logger;

		public AbstractDatabaseLogService(
			ILogger logger,
			IMediator mediator,
			IDatabaseLogRepository databaseLogRepository,
			IApiDatabaseLogServerRequestModelValidator databaseLogModelValidator,
			IDALDatabaseLogMapper dalDatabaseLogMapper)
			: base()
		{
			this.DatabaseLogRepository = databaseLogRepository;
			this.DatabaseLogModelValidator = databaseLogModelValidator;
			this.DalDatabaseLogMapper = dalDatabaseLogMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiDatabaseLogServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			var records = await this.DatabaseLogRepository.All(limit, offset, query);

			return this.DalDatabaseLogMapper.MapBOToModel(records);
		}

		public virtual async Task<ApiDatabaseLogServerResponseModel> Get(int databaseLogID)
		{
			var record = await this.DatabaseLogRepository.Get(databaseLogID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalDatabaseLogMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiDatabaseLogServerResponseModel>> Create(
			ApiDatabaseLogServerRequestModel model)
		{
			CreateResponse<ApiDatabaseLogServerResponseModel> response = ValidationResponseFactory<ApiDatabaseLogServerResponseModel>.CreateResponse(await this.DatabaseLogModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalDatabaseLogMapper.MapModelToBO(default(int), model);
				var record = await this.DatabaseLogRepository.Create(bo);

				response.SetRecord(this.DalDatabaseLogMapper.MapBOToModel(record));
				await this.mediator.Publish(new DatabaseLogCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDatabaseLogServerResponseModel>> Update(
			int databaseLogID,
			ApiDatabaseLogServerRequestModel model)
		{
			var validationResult = await this.DatabaseLogModelValidator.ValidateUpdateAsync(databaseLogID, model);

			if (validationResult.IsValid)
			{
				var bo = this.DalDatabaseLogMapper.MapModelToBO(databaseLogID, model);
				await this.DatabaseLogRepository.Update(bo);

				var record = await this.DatabaseLogRepository.Get(databaseLogID);

				var apiModel = this.DalDatabaseLogMapper.MapBOToModel(record);
				await this.mediator.Publish(new DatabaseLogUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiDatabaseLogServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiDatabaseLogServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int databaseLogID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.DatabaseLogModelValidator.ValidateDeleteAsync(databaseLogID));

			if (response.Success)
			{
				await this.DatabaseLogRepository.Delete(databaseLogID);

				await this.mediator.Publish(new DatabaseLogDeletedNotification(databaseLogID));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>192f4452a0c33ba38ab0b43d7b79a86d</Hash>
</Codenesium>*/