using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class AirlineService : AbstractService, IAirlineService
	{
		private MediatR.IMediator mediator;

		protected IAirlineRepository AirlineRepository { get; private set; }

		protected IApiAirlineServerRequestModelValidator AirlineModelValidator { get; private set; }

		protected IDALAirlineMapper DalAirlineMapper { get; private set; }

		private ILogger logger;

		public AirlineService(
			ILogger<IAirlineService> logger,
			MediatR.IMediator mediator,
			IAirlineRepository airlineRepository,
			IApiAirlineServerRequestModelValidator airlineModelValidator,
			IDALAirlineMapper dalAirlineMapper)
			: base()
		{
			this.AirlineRepository = airlineRepository;
			this.AirlineModelValidator = airlineModelValidator;
			this.DalAirlineMapper = dalAirlineMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiAirlineServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Airline> records = await this.AirlineRepository.All(limit, offset, query);

			return this.DalAirlineMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiAirlineServerResponseModel> Get(int id)
		{
			Airline record = await this.AirlineRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalAirlineMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiAirlineServerResponseModel>> Create(
			ApiAirlineServerRequestModel model)
		{
			CreateResponse<ApiAirlineServerResponseModel> response = ValidationResponseFactory<ApiAirlineServerResponseModel>.CreateResponse(await this.AirlineModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Airline record = this.DalAirlineMapper.MapModelToEntity(default(int), model);
				record = await this.AirlineRepository.Create(record);

				response.SetRecord(this.DalAirlineMapper.MapEntityToModel(record));
				await this.mediator.Publish(new AirlineCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiAirlineServerResponseModel>> Update(
			int id,
			ApiAirlineServerRequestModel model)
		{
			var validationResult = await this.AirlineModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Airline record = this.DalAirlineMapper.MapModelToEntity(id, model);
				await this.AirlineRepository.Update(record);

				record = await this.AirlineRepository.Get(id);

				ApiAirlineServerResponseModel apiModel = this.DalAirlineMapper.MapEntityToModel(record);
				await this.mediator.Publish(new AirlineUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiAirlineServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiAirlineServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.AirlineModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.AirlineRepository.Delete(id);

				await this.mediator.Publish(new AirlineDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>54aff0311beaf0606bc23937132254f6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/