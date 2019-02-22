using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractPipelineStepNoteService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IPipelineStepNoteRepository PipelineStepNoteRepository { get; private set; }

		protected IApiPipelineStepNoteServerRequestModelValidator PipelineStepNoteModelValidator { get; private set; }

		protected IDALPipelineStepNoteMapper DalPipelineStepNoteMapper { get; private set; }

		private ILogger logger;

		public AbstractPipelineStepNoteService(
			ILogger logger,
			MediatR.IMediator mediator,
			IPipelineStepNoteRepository pipelineStepNoteRepository,
			IApiPipelineStepNoteServerRequestModelValidator pipelineStepNoteModelValidator,
			IDALPipelineStepNoteMapper dalPipelineStepNoteMapper)
			: base()
		{
			this.PipelineStepNoteRepository = pipelineStepNoteRepository;
			this.PipelineStepNoteModelValidator = pipelineStepNoteModelValidator;
			this.DalPipelineStepNoteMapper = dalPipelineStepNoteMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPipelineStepNoteServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<PipelineStepNote> records = await this.PipelineStepNoteRepository.All(limit, offset, query);

			return this.DalPipelineStepNoteMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPipelineStepNoteServerResponseModel> Get(int id)
		{
			PipelineStepNote record = await this.PipelineStepNoteRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPipelineStepNoteMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPipelineStepNoteServerResponseModel>> Create(
			ApiPipelineStepNoteServerRequestModel model)
		{
			CreateResponse<ApiPipelineStepNoteServerResponseModel> response = ValidationResponseFactory<ApiPipelineStepNoteServerResponseModel>.CreateResponse(await this.PipelineStepNoteModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				PipelineStepNote record = this.DalPipelineStepNoteMapper.MapModelToEntity(default(int), model);
				record = await this.PipelineStepNoteRepository.Create(record);

				response.SetRecord(this.DalPipelineStepNoteMapper.MapEntityToModel(record));
				await this.mediator.Publish(new PipelineStepNoteCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPipelineStepNoteServerResponseModel>> Update(
			int id,
			ApiPipelineStepNoteServerRequestModel model)
		{
			var validationResult = await this.PipelineStepNoteModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				PipelineStepNote record = this.DalPipelineStepNoteMapper.MapModelToEntity(id, model);
				await this.PipelineStepNoteRepository.Update(record);

				record = await this.PipelineStepNoteRepository.Get(id);

				ApiPipelineStepNoteServerResponseModel apiModel = this.DalPipelineStepNoteMapper.MapEntityToModel(record);
				await this.mediator.Publish(new PipelineStepNoteUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPipelineStepNoteServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPipelineStepNoteServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PipelineStepNoteModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PipelineStepNoteRepository.Delete(id);

				await this.mediator.Publish(new PipelineStepNoteDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6b042bfb225ca4c3f75b6b61e32b5ec4</Hash>
</Codenesium>*/