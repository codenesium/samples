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

		protected IBOLDatabaseLogMapper BolDatabaseLogMapper { get; private set; }

		protected IDALDatabaseLogMapper DalDatabaseLogMapper { get; private set; }

		private ILogger logger;

		public AbstractDatabaseLogService(
			ILogger logger,
			IMediator mediator,
			IDatabaseLogRepository databaseLogRepository,
			IApiDatabaseLogServerRequestModelValidator databaseLogModelValidator,
			IBOLDatabaseLogMapper bolDatabaseLogMapper,
			IDALDatabaseLogMapper dalDatabaseLogMapper)
			: base()
		{
			this.DatabaseLogRepository = databaseLogRepository;
			this.DatabaseLogModelValidator = databaseLogModelValidator;
			this.BolDatabaseLogMapper = bolDatabaseLogMapper;
			this.DalDatabaseLogMapper = dalDatabaseLogMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiDatabaseLogServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.DatabaseLogRepository.All(limit, offset);

			return this.BolDatabaseLogMapper.MapBOToModel(this.DalDatabaseLogMapper.MapEFToBO(records));
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
				return this.BolDatabaseLogMapper.MapBOToModel(this.DalDatabaseLogMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiDatabaseLogServerResponseModel>> Create(
			ApiDatabaseLogServerRequestModel model)
		{
			CreateResponse<ApiDatabaseLogServerResponseModel> response = ValidationResponseFactory<ApiDatabaseLogServerResponseModel>.CreateResponse(await this.DatabaseLogModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolDatabaseLogMapper.MapModelToBO(default(int), model);
				var record = await this.DatabaseLogRepository.Create(this.DalDatabaseLogMapper.MapBOToEF(bo));

				var businessObject = this.DalDatabaseLogMapper.MapEFToBO(record);
				response.SetRecord(this.BolDatabaseLogMapper.MapBOToModel(businessObject));
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
				var bo = this.BolDatabaseLogMapper.MapModelToBO(databaseLogID, model);
				await this.DatabaseLogRepository.Update(this.DalDatabaseLogMapper.MapBOToEF(bo));

				var record = await this.DatabaseLogRepository.Get(databaseLogID);

				var businessObject = this.DalDatabaseLogMapper.MapEFToBO(record);
				var apiModel = this.BolDatabaseLogMapper.MapBOToModel(businessObject);
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
    <Hash>cdb3a3ed2839de84410aaafc88210554</Hash>
</Codenesium>*/