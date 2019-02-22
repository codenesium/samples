using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractPipelineStatuService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IPipelineStatuRepository PipelineStatuRepository { get; private set; }

		protected IApiPipelineStatuServerRequestModelValidator PipelineStatuModelValidator { get; private set; }

		protected IDALPipelineStatuMapper DalPipelineStatuMapper { get; private set; }

		protected IDALPipelineMapper DalPipelineMapper { get; private set; }

		private ILogger logger;

		public AbstractPipelineStatuService(
			ILogger logger,
			MediatR.IMediator mediator,
			IPipelineStatuRepository pipelineStatuRepository,
			IApiPipelineStatuServerRequestModelValidator pipelineStatuModelValidator,
			IDALPipelineStatuMapper dalPipelineStatuMapper,
			IDALPipelineMapper dalPipelineMapper)
			: base()
		{
			this.PipelineStatuRepository = pipelineStatuRepository;
			this.PipelineStatuModelValidator = pipelineStatuModelValidator;
			this.DalPipelineStatuMapper = dalPipelineStatuMapper;
			this.DalPipelineMapper = dalPipelineMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPipelineStatuServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<PipelineStatu> records = await this.PipelineStatuRepository.All(limit, offset, query);

			return this.DalPipelineStatuMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPipelineStatuServerResponseModel> Get(int id)
		{
			PipelineStatu record = await this.PipelineStatuRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPipelineStatuMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPipelineStatuServerResponseModel>> Create(
			ApiPipelineStatuServerRequestModel model)
		{
			CreateResponse<ApiPipelineStatuServerResponseModel> response = ValidationResponseFactory<ApiPipelineStatuServerResponseModel>.CreateResponse(await this.PipelineStatuModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				PipelineStatu record = this.DalPipelineStatuMapper.MapModelToEntity(default(int), model);
				record = await this.PipelineStatuRepository.Create(record);

				response.SetRecord(this.DalPipelineStatuMapper.MapEntityToModel(record));
				await this.mediator.Publish(new PipelineStatuCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPipelineStatuServerResponseModel>> Update(
			int id,
			ApiPipelineStatuServerRequestModel model)
		{
			var validationResult = await this.PipelineStatuModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				PipelineStatu record = this.DalPipelineStatuMapper.MapModelToEntity(id, model);
				await this.PipelineStatuRepository.Update(record);

				record = await this.PipelineStatuRepository.Get(id);

				ApiPipelineStatuServerResponseModel apiModel = this.DalPipelineStatuMapper.MapEntityToModel(record);
				await this.mediator.Publish(new PipelineStatuUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPipelineStatuServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPipelineStatuServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PipelineStatuModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PipelineStatuRepository.Delete(id);

				await this.mediator.Publish(new PipelineStatuDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiPipelineServerResponseModel>> PipelinesByPipelineStatusId(int pipelineStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Pipeline> records = await this.PipelineStatuRepository.PipelinesByPipelineStatusId(pipelineStatusId, limit, offset);

			return this.DalPipelineMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>41d62ab4e355787c6843a9092c6ab04f</Hash>
</Codenesium>*/