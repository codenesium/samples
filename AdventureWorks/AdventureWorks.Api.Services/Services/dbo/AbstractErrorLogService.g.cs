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

		protected IBOLErrorLogMapper BolErrorLogMapper { get; private set; }

		protected IDALErrorLogMapper DalErrorLogMapper { get; private set; }

		private ILogger logger;

		public AbstractErrorLogService(
			ILogger logger,
			IMediator mediator,
			IErrorLogRepository errorLogRepository,
			IApiErrorLogServerRequestModelValidator errorLogModelValidator,
			IBOLErrorLogMapper bolErrorLogMapper,
			IDALErrorLogMapper dalErrorLogMapper)
			: base()
		{
			this.ErrorLogRepository = errorLogRepository;
			this.ErrorLogModelValidator = errorLogModelValidator;
			this.BolErrorLogMapper = bolErrorLogMapper;
			this.DalErrorLogMapper = dalErrorLogMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiErrorLogServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ErrorLogRepository.All(limit, offset);

			return this.BolErrorLogMapper.MapBOToModel(this.DalErrorLogMapper.MapEFToBO(records));
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
				return this.BolErrorLogMapper.MapBOToModel(this.DalErrorLogMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiErrorLogServerResponseModel>> Create(
			ApiErrorLogServerRequestModel model)
		{
			CreateResponse<ApiErrorLogServerResponseModel> response = ValidationResponseFactory<ApiErrorLogServerResponseModel>.CreateResponse(await this.ErrorLogModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolErrorLogMapper.MapModelToBO(default(int), model);
				var record = await this.ErrorLogRepository.Create(this.DalErrorLogMapper.MapBOToEF(bo));

				var businessObject = this.DalErrorLogMapper.MapEFToBO(record);
				response.SetRecord(this.BolErrorLogMapper.MapBOToModel(businessObject));
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
				var bo = this.BolErrorLogMapper.MapModelToBO(errorLogID, model);
				await this.ErrorLogRepository.Update(this.DalErrorLogMapper.MapBOToEF(bo));

				var record = await this.ErrorLogRepository.Get(errorLogID);

				var businessObject = this.DalErrorLogMapper.MapEFToBO(record);
				var apiModel = this.BolErrorLogMapper.MapBOToModel(businessObject);
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
    <Hash>84b28c05532c2d395c1ec09679b952d0</Hash>
</Codenesium>*/