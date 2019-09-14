using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class RateService : AbstractService, IRateService
	{
		private MediatR.IMediator mediator;

		protected IRateRepository RateRepository { get; private set; }

		protected IApiRateServerRequestModelValidator RateModelValidator { get; private set; }

		protected IDALRateMapper DalRateMapper { get; private set; }

		private ILogger logger;

		public RateService(
			ILogger<IRateService> logger,
			MediatR.IMediator mediator,
			IRateRepository rateRepository,
			IApiRateServerRequestModelValidator rateModelValidator,
			IDALRateMapper dalRateMapper)
			: base()
		{
			this.RateRepository = rateRepository;
			this.RateModelValidator = rateModelValidator;
			this.DalRateMapper = dalRateMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiRateServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Rate> records = await this.RateRepository.All(limit, offset, query);

			return this.DalRateMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiRateServerResponseModel> Get(int id)
		{
			Rate record = await this.RateRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalRateMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiRateServerResponseModel>> Create(
			ApiRateServerRequestModel model)
		{
			CreateResponse<ApiRateServerResponseModel> response = ValidationResponseFactory<ApiRateServerResponseModel>.CreateResponse(await this.RateModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Rate record = this.DalRateMapper.MapModelToEntity(default(int), model);
				record = await this.RateRepository.Create(record);

				response.SetRecord(this.DalRateMapper.MapEntityToModel(record));
				await this.mediator.Publish(new RateCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiRateServerResponseModel>> Update(
			int id,
			ApiRateServerRequestModel model)
		{
			var validationResult = await this.RateModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Rate record = this.DalRateMapper.MapModelToEntity(id, model);
				await this.RateRepository.Update(record);

				record = await this.RateRepository.Get(id);

				ApiRateServerResponseModel apiModel = this.DalRateMapper.MapEntityToModel(record);
				await this.mediator.Publish(new RateUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiRateServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiRateServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.RateModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.RateRepository.Delete(id);

				await this.mediator.Publish(new RateDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>04f2d70471d6ccb5692cbf0ee38f6c8e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/