using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class CallAssignmentService : AbstractService, ICallAssignmentService
	{
		private MediatR.IMediator mediator;

		protected ICallAssignmentRepository CallAssignmentRepository { get; private set; }

		protected IApiCallAssignmentServerRequestModelValidator CallAssignmentModelValidator { get; private set; }

		protected IDALCallAssignmentMapper DalCallAssignmentMapper { get; private set; }

		private ILogger logger;

		public CallAssignmentService(
			ILogger<ICallAssignmentService> logger,
			MediatR.IMediator mediator,
			ICallAssignmentRepository callAssignmentRepository,
			IApiCallAssignmentServerRequestModelValidator callAssignmentModelValidator,
			IDALCallAssignmentMapper dalCallAssignmentMapper)
			: base()
		{
			this.CallAssignmentRepository = callAssignmentRepository;
			this.CallAssignmentModelValidator = callAssignmentModelValidator;
			this.DalCallAssignmentMapper = dalCallAssignmentMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCallAssignmentServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<CallAssignment> records = await this.CallAssignmentRepository.All(limit, offset, query);

			return this.DalCallAssignmentMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiCallAssignmentServerResponseModel> Get(int id)
		{
			CallAssignment record = await this.CallAssignmentRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCallAssignmentMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiCallAssignmentServerResponseModel>> Create(
			ApiCallAssignmentServerRequestModel model)
		{
			CreateResponse<ApiCallAssignmentServerResponseModel> response = ValidationResponseFactory<ApiCallAssignmentServerResponseModel>.CreateResponse(await this.CallAssignmentModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				CallAssignment record = this.DalCallAssignmentMapper.MapModelToEntity(default(int), model);
				record = await this.CallAssignmentRepository.Create(record);

				response.SetRecord(this.DalCallAssignmentMapper.MapEntityToModel(record));
				await this.mediator.Publish(new CallAssignmentCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCallAssignmentServerResponseModel>> Update(
			int id,
			ApiCallAssignmentServerRequestModel model)
		{
			var validationResult = await this.CallAssignmentModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				CallAssignment record = this.DalCallAssignmentMapper.MapModelToEntity(id, model);
				await this.CallAssignmentRepository.Update(record);

				record = await this.CallAssignmentRepository.Get(id);

				ApiCallAssignmentServerResponseModel apiModel = this.DalCallAssignmentMapper.MapEntityToModel(record);
				await this.mediator.Publish(new CallAssignmentUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiCallAssignmentServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiCallAssignmentServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CallAssignmentModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.CallAssignmentRepository.Delete(id);

				await this.mediator.Publish(new CallAssignmentDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiCallAssignmentServerResponseModel>> ByCallId(int callId, int limit = 0, int offset = int.MaxValue)
		{
			List<CallAssignment> records = await this.CallAssignmentRepository.ByCallId(callId, limit, offset);

			return this.DalCallAssignmentMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiCallAssignmentServerResponseModel>> ByUnitId(int unitId, int limit = 0, int offset = int.MaxValue)
		{
			List<CallAssignment> records = await this.CallAssignmentRepository.ByUnitId(unitId, limit, offset);

			return this.DalCallAssignmentMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>9219bc7d05f3d24e1c8ab596e21a5bdf</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/