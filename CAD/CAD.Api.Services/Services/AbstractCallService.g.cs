using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractCallService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ICallRepository CallRepository { get; private set; }

		protected IApiCallServerRequestModelValidator CallModelValidator { get; private set; }

		protected IDALCallMapper DalCallMapper { get; private set; }

		protected IDALNoteMapper DalNoteMapper { get; private set; }

		protected IDALCallAssignmentMapper DalCallAssignmentMapper { get; private set; }

		private ILogger logger;

		public AbstractCallService(
			ILogger logger,
			MediatR.IMediator mediator,
			ICallRepository callRepository,
			IApiCallServerRequestModelValidator callModelValidator,
			IDALCallMapper dalCallMapper,
			IDALNoteMapper dalNoteMapper,
			IDALCallAssignmentMapper dalCallAssignmentMapper)
			: base()
		{
			this.CallRepository = callRepository;
			this.CallModelValidator = callModelValidator;
			this.DalCallMapper = dalCallMapper;
			this.DalNoteMapper = dalNoteMapper;
			this.DalCallAssignmentMapper = dalCallAssignmentMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCallServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Call> records = await this.CallRepository.All(limit, offset, query);

			return this.DalCallMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiCallServerResponseModel> Get(int id)
		{
			Call record = await this.CallRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCallMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiCallServerResponseModel>> Create(
			ApiCallServerRequestModel model)
		{
			CreateResponse<ApiCallServerResponseModel> response = ValidationResponseFactory<ApiCallServerResponseModel>.CreateResponse(await this.CallModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Call record = this.DalCallMapper.MapModelToEntity(default(int), model);
				record = await this.CallRepository.Create(record);

				response.SetRecord(this.DalCallMapper.MapEntityToModel(record));
				await this.mediator.Publish(new CallCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCallServerResponseModel>> Update(
			int id,
			ApiCallServerRequestModel model)
		{
			var validationResult = await this.CallModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Call record = this.DalCallMapper.MapModelToEntity(id, model);
				await this.CallRepository.Update(record);

				record = await this.CallRepository.Get(id);

				ApiCallServerResponseModel apiModel = this.DalCallMapper.MapEntityToModel(record);
				await this.mediator.Publish(new CallUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiCallServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiCallServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CallModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.CallRepository.Delete(id);

				await this.mediator.Publish(new CallDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiNoteServerResponseModel>> NotesByCallId(int callId, int limit = int.MaxValue, int offset = 0)
		{
			List<Note> records = await this.CallRepository.NotesByCallId(callId, limit, offset);

			return this.DalNoteMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiCallAssignmentServerResponseModel>> CallAssignmentsByCallId(int callId, int limit = int.MaxValue, int offset = 0)
		{
			List<CallAssignment> records = await this.CallRepository.CallAssignmentsByCallId(callId, limit, offset);

			return this.DalCallAssignmentMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>ce880e27429f89fdb388a6573754dcee</Hash>
</Codenesium>*/