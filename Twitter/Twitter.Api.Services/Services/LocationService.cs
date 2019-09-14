using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class LocationService : AbstractService, ILocationService
	{
		private MediatR.IMediator mediator;

		protected ILocationRepository LocationRepository { get; private set; }

		protected IApiLocationServerRequestModelValidator LocationModelValidator { get; private set; }

		protected IDALLocationMapper DalLocationMapper { get; private set; }

		protected IDALTweetMapper DalTweetMapper { get; private set; }

		protected IDALUserMapper DalUserMapper { get; private set; }

		private ILogger logger;

		public LocationService(
			ILogger<ILocationService> logger,
			MediatR.IMediator mediator,
			ILocationRepository locationRepository,
			IApiLocationServerRequestModelValidator locationModelValidator,
			IDALLocationMapper dalLocationMapper,
			IDALTweetMapper dalTweetMapper,
			IDALUserMapper dalUserMapper)
			: base()
		{
			this.LocationRepository = locationRepository;
			this.LocationModelValidator = locationModelValidator;
			this.DalLocationMapper = dalLocationMapper;
			this.DalTweetMapper = dalTweetMapper;
			this.DalUserMapper = dalUserMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiLocationServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Location> records = await this.LocationRepository.All(limit, offset, query);

			return this.DalLocationMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiLocationServerResponseModel> Get(int locationId)
		{
			Location record = await this.LocationRepository.Get(locationId);

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
				Location record = this.DalLocationMapper.MapModelToEntity(default(int), model);
				record = await this.LocationRepository.Create(record);

				response.SetRecord(this.DalLocationMapper.MapEntityToModel(record));
				await this.mediator.Publish(new LocationCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLocationServerResponseModel>> Update(
			int locationId,
			ApiLocationServerRequestModel model)
		{
			var validationResult = await this.LocationModelValidator.ValidateUpdateAsync(locationId, model);

			if (validationResult.IsValid)
			{
				Location record = this.DalLocationMapper.MapModelToEntity(locationId, model);
				await this.LocationRepository.Update(record);

				record = await this.LocationRepository.Get(locationId);

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
			int locationId)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.LocationModelValidator.ValidateDeleteAsync(locationId));

			if (response.Success)
			{
				await this.LocationRepository.Delete(locationId);

				await this.mediator.Publish(new LocationDeletedNotification(locationId));
			}

			return response;
		}

		public async virtual Task<List<ApiTweetServerResponseModel>> TweetsByLocationId(int locationId, int limit = int.MaxValue, int offset = 0)
		{
			List<Tweet> records = await this.LocationRepository.TweetsByLocationId(locationId, limit, offset);

			return this.DalTweetMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiUserServerResponseModel>> UsersByLocationLocationId(int locationLocationId, int limit = int.MaxValue, int offset = 0)
		{
			List<User> records = await this.LocationRepository.UsersByLocationLocationId(locationLocationId, limit, offset);

			return this.DalUserMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>4e12ce6eb0b6580d62b15c0e2b097691</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/