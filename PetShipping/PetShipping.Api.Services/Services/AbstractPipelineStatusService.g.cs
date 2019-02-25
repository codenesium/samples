using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractPipelineStatusService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IPipelineStatusRepository PipelineStatusRepository { get; private set; }

		protected IApiPipelineStatusServerRequestModelValidator PipelineStatusModelValidator { get; private set; }

		protected IDALPipelineStatusMapper DalPipelineStatusMapper { get; private set; }

		protected IDALPipelineMapper DalPipelineMapper { get; private set; }

		private ILogger logger;

		public AbstractPipelineStatusService(
			ILogger logger,
			MediatR.IMediator mediator,
			IPipelineStatusRepository pipelineStatusRepository,
			IApiPipelineStatusServerRequestModelValidator pipelineStatusModelValidator,
			IDALPipelineStatusMapper dalPipelineStatusMapper,
			IDALPipelineMapper dalPipelineMapper)
			: base()
		{
			this.PipelineStatusRepository = pipelineStatusRepository;
			this.PipelineStatusModelValidator = pipelineStatusModelValidator;
			this.DalPipelineStatusMapper = dalPipelineStatusMapper;
			this.DalPipelineMapper = dalPipelineMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPipelineStatusServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<PipelineStatus> records = await this.PipelineStatusRepository.All(limit, offset, query);

			return this.DalPipelineStatusMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPipelineStatusServerResponseModel> Get(int id)
		{
			PipelineStatus record = await this.PipelineStatusRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPipelineStatusMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPipelineStatusServerResponseModel>> Create(
			ApiPipelineStatusServerRequestModel model)
		{
			CreateResponse<ApiPipelineStatusServerResponseModel> response = ValidationResponseFactory<ApiPipelineStatusServerResponseModel>.CreateResponse(await this.PipelineStatusModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				PipelineStatus record = this.DalPipelineStatusMapper.MapModelToEntity(default(int), model);
				record = await this.PipelineStatusRepository.Create(record);

				response.SetRecord(this.DalPipelineStatusMapper.MapEntityToModel(record));
				await this.mediator.Publish(new PipelineStatusCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPipelineStatusServerResponseModel>> Update(
			int id,
			ApiPipelineStatusServerRequestModel model)
		{
			var validationResult = await this.PipelineStatusModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				PipelineStatus record = this.DalPipelineStatusMapper.MapModelToEntity(id, model);
				await this.PipelineStatusRepository.Update(record);

				record = await this.PipelineStatusRepository.Get(id);

				ApiPipelineStatusServerResponseModel apiModel = this.DalPipelineStatusMapper.MapEntityToModel(record);
				await this.mediator.Publish(new PipelineStatusUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPipelineStatusServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPipelineStatusServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PipelineStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PipelineStatusRepository.Delete(id);

				await this.mediator.Publish(new PipelineStatusDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiPipelineServerResponseModel>> PipelinesByPipelineStatusId(int pipelineStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Pipeline> records = await this.PipelineStatusRepository.PipelinesByPipelineStatusId(pipelineStatusId, limit, offset);

			return this.DalPipelineMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>7e0c9166a4e332b19a5a3131a8c7d52c</Hash>
</Codenesium>*/