using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class PipelineStepStatusService : AbstractService, IPipelineStepStatusService
	{
		private MediatR.IMediator mediator;

		protected IPipelineStepStatusRepository PipelineStepStatusRepository { get; private set; }

		protected IApiPipelineStepStatusServerRequestModelValidator PipelineStepStatusModelValidator { get; private set; }

		protected IDALPipelineStepStatusMapper DalPipelineStepStatusMapper { get; private set; }

		protected IDALPipelineStepMapper DalPipelineStepMapper { get; private set; }

		private ILogger logger;

		public PipelineStepStatusService(
			ILogger<IPipelineStepStatusService> logger,
			MediatR.IMediator mediator,
			IPipelineStepStatusRepository pipelineStepStatusRepository,
			IApiPipelineStepStatusServerRequestModelValidator pipelineStepStatusModelValidator,
			IDALPipelineStepStatusMapper dalPipelineStepStatusMapper,
			IDALPipelineStepMapper dalPipelineStepMapper)
			: base()
		{
			this.PipelineStepStatusRepository = pipelineStepStatusRepository;
			this.PipelineStepStatusModelValidator = pipelineStepStatusModelValidator;
			this.DalPipelineStepStatusMapper = dalPipelineStepStatusMapper;
			this.DalPipelineStepMapper = dalPipelineStepMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPipelineStepStatusServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<PipelineStepStatus> records = await this.PipelineStepStatusRepository.All(limit, offset, query);

			return this.DalPipelineStepStatusMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPipelineStepStatusServerResponseModel> Get(int id)
		{
			PipelineStepStatus record = await this.PipelineStepStatusRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPipelineStepStatusMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPipelineStepStatusServerResponseModel>> Create(
			ApiPipelineStepStatusServerRequestModel model)
		{
			CreateResponse<ApiPipelineStepStatusServerResponseModel> response = ValidationResponseFactory<ApiPipelineStepStatusServerResponseModel>.CreateResponse(await this.PipelineStepStatusModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				PipelineStepStatus record = this.DalPipelineStepStatusMapper.MapModelToEntity(default(int), model);
				record = await this.PipelineStepStatusRepository.Create(record);

				response.SetRecord(this.DalPipelineStepStatusMapper.MapEntityToModel(record));
				await this.mediator.Publish(new PipelineStepStatusCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPipelineStepStatusServerResponseModel>> Update(
			int id,
			ApiPipelineStepStatusServerRequestModel model)
		{
			var validationResult = await this.PipelineStepStatusModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				PipelineStepStatus record = this.DalPipelineStepStatusMapper.MapModelToEntity(id, model);
				await this.PipelineStepStatusRepository.Update(record);

				record = await this.PipelineStepStatusRepository.Get(id);

				ApiPipelineStepStatusServerResponseModel apiModel = this.DalPipelineStepStatusMapper.MapEntityToModel(record);
				await this.mediator.Publish(new PipelineStepStatusUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPipelineStepStatusServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPipelineStepStatusServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PipelineStepStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PipelineStepStatusRepository.Delete(id);

				await this.mediator.Publish(new PipelineStepStatusDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiPipelineStepServerResponseModel>> PipelineStepsByPipelineStepStatusId(int pipelineStepStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStep> records = await this.PipelineStepStatusRepository.PipelineStepsByPipelineStepStatusId(pipelineStepStatusId, limit, offset);

			return this.DalPipelineStepMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>7994a35b22776a1f8dab264e1ddaf463</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/