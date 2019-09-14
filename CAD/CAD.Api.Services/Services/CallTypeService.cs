using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class CallTypeService : AbstractService, ICallTypeService
	{
		private MediatR.IMediator mediator;

		protected ICallTypeRepository CallTypeRepository { get; private set; }

		protected IApiCallTypeServerRequestModelValidator CallTypeModelValidator { get; private set; }

		protected IDALCallTypeMapper DalCallTypeMapper { get; private set; }

		protected IDALCallMapper DalCallMapper { get; private set; }

		private ILogger logger;

		public CallTypeService(
			ILogger<ICallTypeService> logger,
			MediatR.IMediator mediator,
			ICallTypeRepository callTypeRepository,
			IApiCallTypeServerRequestModelValidator callTypeModelValidator,
			IDALCallTypeMapper dalCallTypeMapper,
			IDALCallMapper dalCallMapper)
			: base()
		{
			this.CallTypeRepository = callTypeRepository;
			this.CallTypeModelValidator = callTypeModelValidator;
			this.DalCallTypeMapper = dalCallTypeMapper;
			this.DalCallMapper = dalCallMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCallTypeServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<CallType> records = await this.CallTypeRepository.All(limit, offset, query);

			return this.DalCallTypeMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiCallTypeServerResponseModel> Get(int id)
		{
			CallType record = await this.CallTypeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCallTypeMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiCallTypeServerResponseModel>> Create(
			ApiCallTypeServerRequestModel model)
		{
			CreateResponse<ApiCallTypeServerResponseModel> response = ValidationResponseFactory<ApiCallTypeServerResponseModel>.CreateResponse(await this.CallTypeModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				CallType record = this.DalCallTypeMapper.MapModelToEntity(default(int), model);
				record = await this.CallTypeRepository.Create(record);

				response.SetRecord(this.DalCallTypeMapper.MapEntityToModel(record));
				await this.mediator.Publish(new CallTypeCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCallTypeServerResponseModel>> Update(
			int id,
			ApiCallTypeServerRequestModel model)
		{
			var validationResult = await this.CallTypeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				CallType record = this.DalCallTypeMapper.MapModelToEntity(id, model);
				await this.CallTypeRepository.Update(record);

				record = await this.CallTypeRepository.Get(id);

				ApiCallTypeServerResponseModel apiModel = this.DalCallTypeMapper.MapEntityToModel(record);
				await this.mediator.Publish(new CallTypeUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiCallTypeServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiCallTypeServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CallTypeModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.CallTypeRepository.Delete(id);

				await this.mediator.Publish(new CallTypeDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiCallServerResponseModel>> CallsByCallTypeId(int callTypeId, int limit = int.MaxValue, int offset = 0)
		{
			List<Call> records = await this.CallTypeRepository.CallsByCallTypeId(callTypeId, limit, offset);

			return this.DalCallMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>378bb10427d476465323dc722bf676c9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/