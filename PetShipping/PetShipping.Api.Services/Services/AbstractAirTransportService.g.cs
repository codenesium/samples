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
		private MediatR.IMediator mediator;

		protected IAirTransportRepository AirTransportRepository { get; private set; }

		protected IApiAirTransportServerRequestModelValidator AirTransportModelValidator { get; private set; }

		protected IDALAirTransportMapper DalAirTransportMapper { get; private set; }

		private ILogger logger;

		public AbstractAirTransportService(
			ILogger logger,
			MediatR.IMediator mediator,
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

		public virtual async Task<ApiAirTransportServerResponseModel> Get(int id)
		{
			AirTransport record = await this.AirTransportRepository.Get(id);

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
			int id,
			ApiAirTransportServerRequestModel model)
		{
			var validationResult = await this.AirTransportModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				AirTransport record = this.DalAirTransportMapper.MapModelToEntity(id, model);
				await this.AirTransportRepository.Update(record);

				record = await this.AirTransportRepository.Get(id);

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
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.AirTransportModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.AirTransportRepository.Delete(id);

				await this.mediator.Publish(new AirTransportDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ae787c05a0311d35892fec6f5cb23a66</Hash>
</Codenesium>*/