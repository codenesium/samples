using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractAirTransportService : AbstractService
	{
		private IMediator mediator;

		protected IAirTransportRepository AirTransportRepository { get; private set; }

		protected IApiAirTransportServerRequestModelValidator AirTransportModelValidator { get; private set; }

		protected IDALAirTransportMapper DalAirTransportMapper { get; private set; }

		private ILogger logger;

		public AbstractAirTransportService(
			ILogger logger,
			IMediator mediator,
			IAirTransportRepository airTransportRepository,
			IApiAirTransportServerRequestModelValidator airTransportModelValidator,
			IDALAirTransportMapper dalAirTransportMapper)
			: base()
		{
			this.AirTransportRepository = airTransportRepository;
			this.AirTransportModelValidator = airTransportModelValidator;
			this.DalAirTransportMapper = dalAirTransportMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiAirTransportServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<AirTransport> records = await this.AirTransportRepository.All(limit, offset, query);

			return this.DalAirTransportMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiAirTransportServerResponseModel> Get(int airlineId)
		{
			AirTransport record = await this.AirTransportRepository.Get(airlineId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalAirTransportMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiAirTransportServerResponseModel>> Create(
			ApiAirTransportServerRequestModel model)
		{
			CreateResponse<ApiAirTransportServerResponseModel> response = ValidationResponseFactory<ApiAirTransportServerResponseModel>.CreateResponse(await this.AirTransportModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				AirTransport record = this.DalAirTransportMapper.MapModelToEntity(default(int), model);
				record = await this.AirTransportRepository.Create(record);

				response.SetRecord(this.DalAirTransportMapper.MapEntityToModel(record));
				await this.mediator.Publish(new AirTransportCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiAirTransportServerResponseModel>> Update(
			int airlineId,
			ApiAirTransportServerRequestModel model)
		{
			var validationResult = await this.AirTransportModelValidator.ValidateUpdateAsync(airlineId, model);

			if (validationResult.IsValid)
			{
				AirTransport record = this.DalAirTransportMapper.MapModelToEntity(airlineId, model);
				await this.AirTransportRepository.Update(record);

				record = await this.AirTransportRepository.Get(airlineId);

				ApiAirTransportServerResponseModel apiModel = this.DalAirTransportMapper.MapEntityToModel(record);
				await this.mediator.Publish(new AirTransportUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiAirTransportServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiAirTransportServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int airlineId)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.AirTransportModelValidator.ValidateDeleteAsync(airlineId));

			if (response.Success)
			{
				await this.AirTransportRepository.Delete(airlineId);

				await this.mediator.Publish(new AirTransportDeletedNotification(airlineId));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>96586d25d5543107c6df56aeda680521</Hash>
</Codenesium>*/