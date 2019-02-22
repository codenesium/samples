using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractCallStatuService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ICallStatuRepository CallStatuRepository { get; private set; }

		protected IApiCallStatuServerRequestModelValidator CallStatuModelValidator { get; private set; }

		protected IDALCallStatuMapper DalCallStatuMapper { get; private set; }

		protected IDALCallMapper DalCallMapper { get; private set; }

		private ILogger logger;

		public AbstractCallStatuService(
			ILogger logger,
			MediatR.IMediator mediator,
			ICallStatuRepository callStatuRepository,
			IApiCallStatuServerRequestModelValidator callStatuModelValidator,
			IDALCallStatuMapper dalCallStatuMapper,
			IDALCallMapper dalCallMapper)
			: base()
		{
			this.CallStatuRepository = callStatuRepository;
			this.CallStatuModelValidator = callStatuModelValidator;
			this.DalCallStatuMapper = dalCallStatuMapper;
			this.DalCallMapper = dalCallMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCallStatuServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<CallStatu> records = await this.CallStatuRepository.All(limit, offset, query);

			return this.DalCallStatuMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiCallStatuServerResponseModel> Get(int id)
		{
			CallStatu record = await this.CallStatuRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCallStatuMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiCallStatuServerResponseModel>> Create(
			ApiCallStatuServerRequestModel model)
		{
			CreateResponse<ApiCallStatuServerResponseModel> response = ValidationResponseFactory<ApiCallStatuServerResponseModel>.CreateResponse(await this.CallStatuModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				CallStatu record = this.DalCallStatuMapper.MapModelToEntity(default(int), model);
				record = await this.CallStatuRepository.Create(record);

				response.SetRecord(this.DalCallStatuMapper.MapEntityToModel(record));
				await this.mediator.Publish(new CallStatuCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCallStatuServerResponseModel>> Update(
			int id,
			ApiCallStatuServerRequestModel model)
		{
			var validationResult = await this.CallStatuModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				CallStatu record = this.DalCallStatuMapper.MapModelToEntity(id, model);
				await this.CallStatuRepository.Update(record);

				record = await this.CallStatuRepository.Get(id);

				ApiCallStatuServerResponseModel apiModel = this.DalCallStatuMapper.MapEntityToModel(record);
				await this.mediator.Publish(new CallStatuUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiCallStatuServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiCallStatuServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CallStatuModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.CallStatuRepository.Delete(id);

				await this.mediator.Publish(new CallStatuDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiCallServerResponseModel>> CallsByCallStatusId(int callStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Call> records = await this.CallStatuRepository.CallsByCallStatusId(callStatusId, limit, offset);

			return this.DalCallMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>e6f174954cc2697141ebaf96abf31ad4</Hash>
</Codenesium>*/