using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractErrorLogService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IErrorLogRepository ErrorLogRepository { get; private set; }

		protected IApiErrorLogServerRequestModelValidator ErrorLogModelValidator { get; private set; }

		protected IDALErrorLogMapper DalErrorLogMapper { get; private set; }

		private ILogger logger;

		public AbstractErrorLogService(
			ILogger logger,
			MediatR.IMediator mediator,
			IErrorLogRepository errorLogRepository,
			IApiErrorLogServerRequestModelValidator errorLogModelValidator,
			IDALErrorLogMapper dalErrorLogMapper)
			: base()
		{
			this.ErrorLogRepository = errorLogRepository;
			this.ErrorLogModelValidator = errorLogModelValidator;
			this.DalErrorLogMapper = dalErrorLogMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiErrorLogServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<ErrorLog> records = await this.ErrorLogRepository.All(limit, offset, query);

			return this.DalErrorLogMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiErrorLogServerResponseModel> Get(int errorLogID)
		{
			ErrorLog record = await this.ErrorLogRepository.Get(errorLogID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalErrorLogMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiErrorLogServerResponseModel>> Create(
			ApiErrorLogServerRequestModel model)
		{
			CreateResponse<ApiErrorLogServerResponseModel> response = ValidationResponseFactory<ApiErrorLogServerResponseModel>.CreateResponse(await this.ErrorLogModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				ErrorLog record = this.DalErrorLogMapper.MapModelToEntity(default(int), model);
				record = await this.ErrorLogRepository.Create(record);

				response.SetRecord(this.DalErrorLogMapper.MapEntityToModel(record));
				await this.mediator.Publish(new ErrorLogCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiErrorLogServerResponseModel>> Update(
			int errorLogID,
			ApiErrorLogServerRequestModel model)
		{
			var validationResult = await this.ErrorLogModelValidator.ValidateUpdateAsync(errorLogID, model);

			if (validationResult.IsValid)
			{
				ErrorLog record = this.DalErrorLogMapper.MapModelToEntity(errorLogID, model);
				await this.ErrorLogRepository.Update(record);

				record = await this.ErrorLogRepository.Get(errorLogID);

				ApiErrorLogServerResponseModel apiModel = this.DalErrorLogMapper.MapEntityToModel(record);
				await this.mediator.Publish(new ErrorLogUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiErrorLogServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiErrorLogServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int errorLogID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ErrorLogModelValidator.ValidateDeleteAsync(errorLogID));

			if (response.Success)
			{
				await this.ErrorLogRepository.Delete(errorLogID);

				await this.mediator.Publish(new ErrorLogDeletedNotification(errorLogID));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>136ec3fcf80d090c5fca77a3107928b3</Hash>
</Codenesium>*/