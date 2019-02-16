using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractPipelineStepStatuService : AbstractService
	{
		private IMediator mediator;

		protected IPipelineStepStatuRepository PipelineStepStatuRepository { get; private set; }

		protected IApiPipelineStepStatuServerRequestModelValidator PipelineStepStatuModelValidator { get; private set; }

		protected IDALPipelineStepStatuMapper DalPipelineStepStatuMapper { get; private set; }

		protected IDALPipelineStepMapper DalPipelineStepMapper { get; private set; }

		private ILogger logger;

		public AbstractPipelineStepStatuService(
			ILogger logger,
			IMediator mediator,
			IPipelineStepStatuRepository pipelineStepStatuRepository,
			IApiPipelineStepStatuServerRequestModelValidator pipelineStepStatuModelValidator,
			IDALPipelineStepStatuMapper dalPipelineStepStatuMapper,
			IDALPipelineStepMapper dalPipelineStepMapper)
			: base()
		{
			this.PipelineStepStatuRepository = pipelineStepStatuRepository;
			this.PipelineStepStatuModelValidator = pipelineStepStatuModelValidator;
			this.DalPipelineStepStatuMapper = dalPipelineStepStatuMapper;
			this.DalPipelineStepMapper = dalPipelineStepMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPipelineStepStatuServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<PipelineStepStatu> records = await this.PipelineStepStatuRepository.All(limit, offset, query);

			return this.DalPipelineStepStatuMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPipelineStepStatuServerResponseModel> Get(int id)
		{
			PipelineStepStatu record = await this.PipelineStepStatuRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPipelineStepStatuMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPipelineStepStatuServerResponseModel>> Create(
			ApiPipelineStepStatuServerRequestModel model)
		{
			CreateResponse<ApiPipelineStepStatuServerResponseModel> response = ValidationResponseFactory<ApiPipelineStepStatuServerResponseModel>.CreateResponse(await this.PipelineStepStatuModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				PipelineStepStatu record = this.DalPipelineStepStatuMapper.MapModelToEntity(default(int), model);
				record = await this.PipelineStepStatuRepository.Create(record);

				response.SetRecord(this.DalPipelineStepStatuMapper.MapEntityToModel(record));
				await this.mediator.Publish(new PipelineStepStatuCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPipelineStepStatuServerResponseModel>> Update(
			int id,
			ApiPipelineStepStatuServerRequestModel model)
		{
			var validationResult = await this.PipelineStepStatuModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				PipelineStepStatu record = this.DalPipelineStepStatuMapper.MapModelToEntity(id, model);
				await this.PipelineStepStatuRepository.Update(record);

				record = await this.PipelineStepStatuRepository.Get(id);

				ApiPipelineStepStatuServerResponseModel apiModel = this.DalPipelineStepStatuMapper.MapEntityToModel(record);
				await this.mediator.Publish(new PipelineStepStatuUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPipelineStepStatuServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPipelineStepStatuServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PipelineStepStatuModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PipelineStepStatuRepository.Delete(id);

				await this.mediator.Publish(new PipelineStepStatuDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiPipelineStepServerResponseModel>> PipelineStepsByPipelineStepStatusId(int pipelineStepStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStep> records = await this.PipelineStepStatuRepository.PipelineStepsByPipelineStepStatusId(pipelineStepStatusId, limit, offset);

			return this.DalPipelineStepMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>9c52cf4b01b8dfbd06fd8f2fa907abe8</Hash>
</Codenesium>*/