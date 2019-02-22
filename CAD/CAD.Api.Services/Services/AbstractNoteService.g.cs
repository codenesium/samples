using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractNoteService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected INoteRepository NoteRepository { get; private set; }

		protected IApiNoteServerRequestModelValidator NoteModelValidator { get; private set; }

		protected IDALNoteMapper DalNoteMapper { get; private set; }

		private ILogger logger;

		public AbstractNoteService(
			ILogger logger,
			MediatR.IMediator mediator,
			INoteRepository noteRepository,
			IApiNoteServerRequestModelValidator noteModelValidator,
			IDALNoteMapper dalNoteMapper)
			: base()
		{
			this.NoteRepository = noteRepository;
			this.NoteModelValidator = noteModelValidator;
			this.DalNoteMapper = dalNoteMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiNoteServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Note> records = await this.NoteRepository.All(limit, offset, query);

			return this.DalNoteMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiNoteServerResponseModel> Get(int id)
		{
			Note record = await this.NoteRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalNoteMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiNoteServerResponseModel>> Create(
			ApiNoteServerRequestModel model)
		{
			CreateResponse<ApiNoteServerResponseModel> response = ValidationResponseFactory<ApiNoteServerResponseModel>.CreateResponse(await this.NoteModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Note record = this.DalNoteMapper.MapModelToEntity(default(int), model);
				record = await this.NoteRepository.Create(record);

				response.SetRecord(this.DalNoteMapper.MapEntityToModel(record));
				await this.mediator.Publish(new NoteCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiNoteServerResponseModel>> Update(
			int id,
			ApiNoteServerRequestModel model)
		{
			var validationResult = await this.NoteModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Note record = this.DalNoteMapper.MapModelToEntity(id, model);
				await this.NoteRepository.Update(record);

				record = await this.NoteRepository.Get(id);

				ApiNoteServerResponseModel apiModel = this.DalNoteMapper.MapEntityToModel(record);
				await this.mediator.Publish(new NoteUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiNoteServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiNoteServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.NoteModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.NoteRepository.Delete(id);

				await this.mediator.Publish(new NoteDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3b0a34eca7957d2c870beb32b92998ea</Hash>
</Codenesium>*/