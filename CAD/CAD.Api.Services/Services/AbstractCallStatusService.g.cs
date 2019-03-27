using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractCallStatusService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ICallStatusRepository CallStatusRepository { get; private set; }

		protected IApiCallStatusServerRequestModelValidator CallStatusModelValidator { get; private set; }

		protected IDALCallStatusMapper DalCallStatusMapper { get; private set; }

		protected IDALCallMapper DalCallMapper { get; private set; }

		private ILogger logger;

		public AbstractCallStatusService(
			ILogger logger,
			MediatR.IMediator mediator,
			ICallStatusRepository callStatusRepository,
			IApiCallStatusServerRequestModelValidator callStatusModelValidator,
			IDALCallStatusMapper dalCallStatusMapper,
			IDALCallMapper dalCallMapper)
			: base()
		{
			this.CallStatusRepository = callStatusRepository;
			this.CallStatusModelValidator = callStatusModelValidator;
			this.DalCallStatusMapper = dalCallStatusMapper;
			this.DalCallMapper = dalCallMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCallStatusServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<CallStatus> records = await this.CallStatusRepository.All(limit, offset, query);

			return this.DalCallStatusMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiCallStatusServerResponseModel> Get(int id)
		{
			CallStatus record = await this.CallStatusRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCallStatusMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiCallStatusServerResponseModel>> Create(
			ApiCallStatusServerRequestModel model)
		{
			CreateResponse<ApiCallStatusServerResponseModel> response = ValidationResponseFactory<ApiCallStatusServerResponseModel>.CreateResponse(await this.CallStatusModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				CallStatus record = this.DalCallStatusMapper.MapModelToEntity(default(int), model);
				record = await this.CallStatusRepository.Create(record);

				response.SetRecord(this.DalCallStatusMapper.MapEntityToModel(record));
				await this.mediator.Publish(new CallStatusCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCallStatusServerResponseModel>> Update(
			int id,
			ApiCallStatusServerRequestModel model)
		{
			var validationResult = await this.CallStatusModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				CallStatus record = this.DalCallStatusMapper.MapModelToEntity(id, model);
				await this.CallStatusRepository.Update(record);

				record = await this.CallStatusRepository.Get(id);

				ApiCallStatusServerResponseModel apiModel = this.DalCallStatusMapper.MapEntityToModel(record);
				await this.mediator.Publish(new CallStatusUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiCallStatusServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiCallStatusServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CallStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.CallStatusRepository.Delete(id);

				await this.mediator.Publish(new CallStatusDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiCallServerResponseModel>> CallsByCallStatusId(int callStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Call> records = await this.CallStatusRepository.CallsByCallStatusId(callStatusId, limit, offset);

			return this.DalCallMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>95eb28ec22412def091d1cc5c00e65d9</Hash>
</Codenesium>*/