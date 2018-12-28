using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractPipelineService : AbstractService
	{
		private IMediator mediator;

		protected IPipelineRepository PipelineRepository { get; private set; }

		protected IApiPipelineServerRequestModelValidator PipelineModelValidator { get; private set; }

		protected IBOLPipelineMapper BolPipelineMapper { get; private set; }

		protected IDALPipelineMapper DalPipelineMapper { get; private set; }

		private ILogger logger;

		public AbstractPipelineService(
			ILogger logger,
			IMediator mediator,
			IPipelineRepository pipelineRepository,
			IApiPipelineServerRequestModelValidator pipelineModelValidator,
			IBOLPipelineMapper bolPipelineMapper,
			IDALPipelineMapper dalPipelineMapper)
			: base()
		{
			this.PipelineRepository = pipelineRepository;
			this.PipelineModelValidator = pipelineModelValidator;
			this.BolPipelineMapper = bolPipelineMapper;
			this.DalPipelineMapper = dalPipelineMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPipelineServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PipelineRepository.All(limit, offset);

			return this.BolPipelineMapper.MapBOToModel(this.DalPipelineMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPipelineServerResponseModel> Get(int id)
		{
			var record = await this.PipelineRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPipelineMapper.MapBOToModel(this.DalPipelineMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPipelineServerResponseModel>> Create(
			ApiPipelineServerRequestModel model)
		{
			CreateResponse<ApiPipelineServerResponseModel> response = ValidationResponseFactory<ApiPipelineServerResponseModel>.CreateResponse(await this.PipelineModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPipelineMapper.MapModelToBO(default(int), model);
				var record = await this.PipelineRepository.Create(this.DalPipelineMapper.MapBOToEF(bo));

				var businessObject = this.DalPipelineMapper.MapEFToBO(record);
				response.SetRecord(this.BolPipelineMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new PipelineCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPipelineServerResponseModel>> Update(
			int id,
			ApiPipelineServerRequestModel model)
		{
			var validationResult = await this.PipelineModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPipelineMapper.MapModelToBO(id, model);
				await this.PipelineRepository.Update(this.DalPipelineMapper.MapBOToEF(bo));

				var record = await this.PipelineRepository.Get(id);

				var businessObject = this.DalPipelineMapper.MapEFToBO(record);
				var apiModel = this.BolPipelineMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new PipelineUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPipelineServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPipelineServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PipelineModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PipelineRepository.Delete(id);

				await this.mediator.Publish(new PipelineDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>28fe857c1b3121897e1f3c868df8ba1e</Hash>
</Codenesium>*/