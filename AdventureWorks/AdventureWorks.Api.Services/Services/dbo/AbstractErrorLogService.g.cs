using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractErrorLogService : AbstractService
	{
		private IMediator mediator;

		protected IErrorLogRepository ErrorLogRepository { get; private set; }

		protected IApiErrorLogServerRequestModelValidator ErrorLogModelValidator { get; private set; }

		protected IDALErrorLogMapper DalErrorLogMapper { get; private set; }

		private ILogger logger;

		public AbstractErrorLogService(
			ILogger logger,
			IMediator mediator,
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
			var records = await this.ErrorLogRepository.All(limit, offset, query);

			return this.DalErrorLogMapper.MapBOToModel(records);
		}

		public virtual async Task<ApiErrorLogServerResponseModel> Get(int errorLogID)
		{
			var record = await this.ErrorLogRepository.Get(errorLogID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalErrorLogMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiErrorLogServerResponseModel>> Create(
			ApiErrorLogServerRequestModel model)
		{
			CreateResponse<ApiErrorLogServerResponseModel> response = ValidationResponseFactory<ApiErrorLogServerResponseModel>.CreateResponse(await this.ErrorLogModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalErrorLogMapper.MapModelToBO(default(int), model);
				var record = await this.ErrorLogRepository.Create(bo);

				response.SetRecord(this.DalErrorLogMapper.MapBOToModel(record));
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
				var bo = this.DalErrorLogMapper.MapModelToBO(errorLogID, model);
				await this.ErrorLogRepository.Update(bo);

				var record = await this.ErrorLogRepository.Get(errorLogID);

				var apiModel = this.DalErrorLogMapper.MapBOToModel(record);
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
    <Hash>703c7b3189fca351be1142be409484e4</Hash>
</Codenesium>*/