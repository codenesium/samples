using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class PipelineStepService : AbstractService, IPipelineStepService
	{
		private MediatR.IMediator mediator;

		protected IPipelineStepRepository PipelineStepRepository { get; private set; }

		protected IApiPipelineStepServerRequestModelValidator PipelineStepModelValidator { get; private set; }

		protected IDALPipelineStepMapper DalPipelineStepMapper { get; private set; }

		protected IDALHandlerPipelineStepMapper DalHandlerPipelineStepMapper { get; private set; }

		protected IDALOtherTransportMapper DalOtherTransportMapper { get; private set; }

		protected IDALPipelineStepDestinationMapper DalPipelineStepDestinationMapper { get; private set; }

		protected IDALPipelineStepNoteMapper DalPipelineStepNoteMapper { get; private set; }

		protected IDALPipelineStepStepRequirementMapper DalPipelineStepStepRequirementMapper { get; private set; }

		private ILogger logger;

		public PipelineStepService(
			ILogger<IPipelineStepService> logger,
			MediatR.IMediator mediator,
			IPipelineStepRepository pipelineStepRepository,
			IApiPipelineStepServerRequestModelValidator pipelineStepModelValidator,
			IDALPipelineStepMapper dalPipelineStepMapper,
			IDALHandlerPipelineStepMapper dalHandlerPipelineStepMapper,
			IDALOtherTransportMapper dalOtherTransportMapper,
			IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper,
			IDALPipelineStepNoteMapper dalPipelineStepNoteMapper,
			IDALPipelineStepStepRequirementMapper dalPipelineStepStepRequirementMapper)
			: base()
		{
			this.PipelineStepRepository = pipelineStepRepository;
			this.PipelineStepModelValidator = pipelineStepModelValidator;
			this.DalPipelineStepMapper = dalPipelineStepMapper;
			this.DalHandlerPipelineStepMapper = dalHandlerPipelineStepMapper;
			this.DalOtherTransportMapper = dalOtherTransportMapper;
			this.DalPipelineStepDestinationMapper = dalPipelineStepDestinationMapper;
			this.DalPipelineStepNoteMapper = dalPipelineStepNoteMapper;
			this.DalPipelineStepStepRequirementMapper = dalPipelineStepStepRequirementMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPipelineStepServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<PipelineStep> records = await this.PipelineStepRepository.All(limit, offset, query);

			return this.DalPipelineStepMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPipelineStepServerResponseModel> Get(int id)
		{
			PipelineStep record = await this.PipelineStepRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPipelineStepMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPipelineStepServerResponseModel>> Create(
			ApiPipelineStepServerRequestModel model)
		{
			CreateResponse<ApiPipelineStepServerResponseModel> response = ValidationResponseFactory<ApiPipelineStepServerResponseModel>.CreateResponse(await this.PipelineStepModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				PipelineStep record = this.DalPipelineStepMapper.MapModelToEntity(default(int), model);
				record = await this.PipelineStepRepository.Create(record);

				response.SetRecord(this.DalPipelineStepMapper.MapEntityToModel(record));
				await this.mediator.Publish(new PipelineStepCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPipelineStepServerResponseModel>> Update(
			int id,
			ApiPipelineStepServerRequestModel model)
		{
			var validationResult = await this.PipelineStepModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				PipelineStep record = this.DalPipelineStepMapper.MapModelToEntity(id, model);
				await this.PipelineStepRepository.Update(record);

				record = await this.PipelineStepRepository.Get(id);

				ApiPipelineStepServerResponseModel apiModel = this.DalPipelineStepMapper.MapEntityToModel(record);
				await this.mediator.Publish(new PipelineStepUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPipelineStepServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPipelineStepServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PipelineStepModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PipelineStepRepository.Delete(id);

				await this.mediator.Publish(new PipelineStepDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiHandlerPipelineStepServerResponseModel>> HandlerPipelineStepsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
		{
			List<HandlerPipelineStep> records = await this.PipelineStepRepository.HandlerPipelineStepsByPipelineStepId(pipelineStepId, limit, offset);

			return this.DalHandlerPipelineStepMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiOtherTransportServerResponseModel>> OtherTransportsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
		{
			List<OtherTransport> records = await this.PipelineStepRepository.OtherTransportsByPipelineStepId(pipelineStepId, limit, offset);

			return this.DalOtherTransportMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPipelineStepDestinationServerResponseModel>> PipelineStepDestinationsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStepDestination> records = await this.PipelineStepRepository.PipelineStepDestinationsByPipelineStepId(pipelineStepId, limit, offset);

			return this.DalPipelineStepDestinationMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPipelineStepNoteServerResponseModel>> PipelineStepNotesByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStepNote> records = await this.PipelineStepRepository.PipelineStepNotesByPipelineStepId(pipelineStepId, limit, offset);

			return this.DalPipelineStepNoteMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPipelineStepStepRequirementServerResponseModel>> PipelineStepStepRequirementsByPipelineStepId(int pipelineStepId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStepStepRequirement> records = await this.PipelineStepRepository.PipelineStepStepRequirementsByPipelineStepId(pipelineStepId, limit, offset);

			return this.DalPipelineStepStepRequirementMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>c86ba5f37031719f6036bd2630ab940d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/