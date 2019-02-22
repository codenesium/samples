using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractCallDispositionService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ICallDispositionRepository CallDispositionRepository { get; private set; }

		protected IApiCallDispositionServerRequestModelValidator CallDispositionModelValidator { get; private set; }

		protected IDALCallDispositionMapper DalCallDispositionMapper { get; private set; }

		protected IDALCallMapper DalCallMapper { get; private set; }

		private ILogger logger;

		public AbstractCallDispositionService(
			ILogger logger,
			MediatR.IMediator mediator,
			ICallDispositionRepository callDispositionRepository,
			IApiCallDispositionServerRequestModelValidator callDispositionModelValidator,
			IDALCallDispositionMapper dalCallDispositionMapper,
			IDALCallMapper dalCallMapper)
			: base()
		{
			this.CallDispositionRepository = callDispositionRepository;
			this.CallDispositionModelValidator = callDispositionModelValidator;
			this.DalCallDispositionMapper = dalCallDispositionMapper;
			this.DalCallMapper = dalCallMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCallDispositionServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<CallDisposition> records = await this.CallDispositionRepository.All(limit, offset, query);

			return this.DalCallDispositionMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiCallDispositionServerResponseModel> Get(int id)
		{
			CallDisposition record = await this.CallDispositionRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCallDispositionMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiCallDispositionServerResponseModel>> Create(
			ApiCallDispositionServerRequestModel model)
		{
			CreateResponse<ApiCallDispositionServerResponseModel> response = ValidationResponseFactory<ApiCallDispositionServerResponseModel>.CreateResponse(await this.CallDispositionModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				CallDisposition record = this.DalCallDispositionMapper.MapModelToEntity(default(int), model);
				record = await this.CallDispositionRepository.Create(record);

				response.SetRecord(this.DalCallDispositionMapper.MapEntityToModel(record));
				await this.mediator.Publish(new CallDispositionCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCallDispositionServerResponseModel>> Update(
			int id,
			ApiCallDispositionServerRequestModel model)
		{
			var validationResult = await this.CallDispositionModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				CallDisposition record = this.DalCallDispositionMapper.MapModelToEntity(id, model);
				await this.CallDispositionRepository.Update(record);

				record = await this.CallDispositionRepository.Get(id);

				ApiCallDispositionServerResponseModel apiModel = this.DalCallDispositionMapper.MapEntityToModel(record);
				await this.mediator.Publish(new CallDispositionUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiCallDispositionServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiCallDispositionServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CallDispositionModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.CallDispositionRepository.Delete(id);

				await this.mediator.Publish(new CallDispositionDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiCallServerResponseModel>> CallsByCallDispositionId(int callDispositionId, int limit = int.MaxValue, int offset = 0)
		{
			List<Call> records = await this.CallDispositionRepository.CallsByCallDispositionId(callDispositionId, limit, offset);

			return this.DalCallMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>be23128c143fd791dee19075815ee17b</Hash>
</Codenesium>*/