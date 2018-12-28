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

		protected IBOLPipelineStepStatuMapper BolPipelineStepStatuMapper { get; private set; }

		protected IDALPipelineStepStatuMapper DalPipelineStepStatuMapper { get; private set; }

		protected IBOLPipelineStepMapper BolPipelineStepMapper { get; private set; }

		protected IDALPipelineStepMapper DalPipelineStepMapper { get; private set; }

		private ILogger logger;

		public AbstractPipelineStepStatuService(
			ILogger logger,
			IMediator mediator,
			IPipelineStepStatuRepository pipelineStepStatuRepository,
			IApiPipelineStepStatuServerRequestModelValidator pipelineStepStatuModelValidator,
			IBOLPipelineStepStatuMapper bolPipelineStepStatuMapper,
			IDALPipelineStepStatuMapper dalPipelineStepStatuMapper,
			IBOLPipelineStepMapper bolPipelineStepMapper,
			IDALPipelineStepMapper dalPipelineStepMapper)
			: base()
		{
			this.PipelineStepStatuRepository = pipelineStepStatuRepository;
			this.PipelineStepStatuModelValidator = pipelineStepStatuModelValidator;
			this.BolPipelineStepStatuMapper = bolPipelineStepStatuMapper;
			this.DalPipelineStepStatuMapper = dalPipelineStepStatuMapper;
			this.BolPipelineStepMapper = bolPipelineStepMapper;
			this.DalPipelineStepMapper = dalPipelineStepMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPipelineStepStatuServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PipelineStepStatuRepository.All(limit, offset);

			return this.BolPipelineStepStatuMapper.MapBOToModel(this.DalPipelineStepStatuMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPipelineStepStatuServerResponseModel> Get(int id)
		{
			var record = await this.PipelineStepStatuRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPipelineStepStatuMapper.MapBOToModel(this.DalPipelineStepStatuMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPipelineStepStatuServerResponseModel>> Create(
			ApiPipelineStepStatuServerRequestModel model)
		{
			CreateResponse<ApiPipelineStepStatuServerResponseModel> response = ValidationResponseFactory<ApiPipelineStepStatuServerResponseModel>.CreateResponse(await this.PipelineStepStatuModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPipelineStepStatuMapper.MapModelToBO(default(int), model);
				var record = await this.PipelineStepStatuRepository.Create(this.DalPipelineStepStatuMapper.MapBOToEF(bo));

				var businessObject = this.DalPipelineStepStatuMapper.MapEFToBO(record);
				response.SetRecord(this.BolPipelineStepStatuMapper.MapBOToModel(businessObject));
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
				var bo = this.BolPipelineStepStatuMapper.MapModelToBO(id, model);
				await this.PipelineStepStatuRepository.Update(this.DalPipelineStepStatuMapper.MapBOToEF(bo));

				var record = await this.PipelineStepStatuRepository.Get(id);

				var businessObject = this.DalPipelineStepStatuMapper.MapEFToBO(record);
				var apiModel = this.BolPipelineStepStatuMapper.MapBOToModel(businessObject);
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

			return this.BolPipelineStepMapper.MapBOToModel(this.DalPipelineStepMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>38c7030f3d2a20b7589f06656a43fbc8</Hash>
</Codenesium>*/