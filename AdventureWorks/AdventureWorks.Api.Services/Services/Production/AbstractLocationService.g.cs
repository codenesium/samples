using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractLocationService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ILocationRepository LocationRepository { get; private set; }

		protected IApiLocationServerRequestModelValidator LocationModelValidator { get; private set; }

		protected IDALLocationMapper DalLocationMapper { get; private set; }

		private ILogger logger;

		public AbstractLocationService(
			ILogger logger,
			MediatR.IMediator mediator,
			ILocationRepository locationRepository,
			IApiLocationServerRequestModelValidator locationModelValidator,
			IDALLocationMapper dalLocationMapper)
			: base()
		{
			this.LocationRepository = locationRepository;
			this.LocationModelValidator = locationModelValidator;
			this.DalLocationMapper = dalLocationMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiLocationServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Location> records = await this.LocationRepository.All(limit, offset, query);

			return this.DalLocationMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiLocationServerResponseModel> Get(short locationID)
		{
			Location record = await this.LocationRepository.Get(locationID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalLocationMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiLocationServerResponseModel>> Create(
			ApiLocationServerRequestModel model)
		{
			CreateResponse<ApiLocationServerResponseModel> response = ValidationResponseFactory<ApiLocationServerResponseModel>.CreateResponse(await this.LocationModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Location record = this.DalLocationMapper.MapModelToEntity(default(short), model);
				record = await this.LocationRepository.Create(record);

				response.SetRecord(this.DalLocationMapper.MapEntityToModel(record));
				await this.mediator.Publish(new LocationCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLocationServerResponseModel>> Update(
			short locationID,
			ApiLocationServerRequestModel model)
		{
			var validationResult = await this.LocationModelValidator.ValidateUpdateAsync(locationID, model);

			if (validationResult.IsValid)
			{
				Location record = this.DalLocationMapper.MapModelToEntity(locationID, model);
				await this.LocationRepository.Update(record);

				record = await this.LocationRepository.Get(locationID);

				ApiLocationServerResponseModel apiModel = this.DalLocationMapper.MapEntityToModel(record);
				await this.mediator.Publish(new LocationUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiLocationServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiLocationServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			short locationID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.LocationModelValidator.ValidateDeleteAsync(locationID));

			if (response.Success)
			{
				await this.LocationRepository.Delete(locationID);

				await this.mediator.Publish(new LocationDeletedNotification(locationID));
			}

			return response;
		}

		public async virtual Task<ApiLocationServerResponseModel> ByName(string name)
		{
			Location record = await this.LocationRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalLocationMapper.MapEntityToModel(record);
			}
		}
	}
}

/*<Codenesium>
    <Hash>b53b83f4d42617d9c6d0e20aa94bc91a</Hash>
</Codenesium>*/