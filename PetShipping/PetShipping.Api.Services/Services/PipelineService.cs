using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class PipelineService : AbstractService, IPipelineService
	{
		private MediatR.IMediator mediator;

		protected IPipelineRepository PipelineRepository { get; private set; }

		protected IApiPipelineServerRequestModelValidator PipelineModelValidator { get; private set; }

		protected IDALPipelineMapper DalPipelineMapper { get; private set; }

		private ILogger logger;

		public PipelineService(
			ILogger<IPipelineService> logger,
			MediatR.IMediator mediator,
			IPipelineRepository pipelineRepository,
			IApiPipelineServerRequestModelValidator pipelineModelValidator,
			IDALPipelineMapper dalPipelineMapper)
			: base()
		{
			this.PipelineRepository = pipelineRepository;
			this.PipelineModelValidator = pipelineModelValidator;
			this.DalPipelineMapper = dalPipelineMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPipelineServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Pipeline> records = await this.PipelineRepository.All(limit, offset, query);

			return this.DalPipelineMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPipelineServerResponseModel> Get(int id)
		{
			Pipeline record = await this.PipelineRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPipelineMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPipelineServerResponseModel>> Create(
			ApiPipelineServerRequestModel model)
		{
			CreateResponse<ApiPipelineServerResponseModel> response = ValidationResponseFactory<ApiPipelineServerResponseModel>.CreateResponse(await this.PipelineModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Pipeline record = this.DalPipelineMapper.MapModelToEntity(default(int), model);
				record = await this.PipelineRepository.Create(record);

				response.SetRecord(this.DalPipelineMapper.MapEntityToModel(record));
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
				Pipeline record = this.DalPipelineMapper.MapModelToEntity(id, model);
				await this.PipelineRepository.Update(record);

				record = await this.PipelineRepository.Get(id);

				ApiPipelineServerResponseModel apiModel = this.DalPipelineMapper.MapEntityToModel(record);
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
    <Hash>cf5a8869461bfc07af82e0277fc9c48c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/