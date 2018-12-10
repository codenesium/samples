using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractLocationService : AbstractService
	{
		protected ILocationRepository LocationRepository { get; private set; }

		protected IApiLocationServerRequestModelValidator LocationModelValidator { get; private set; }

		protected IBOLLocationMapper BolLocationMapper { get; private set; }

		protected IDALLocationMapper DalLocationMapper { get; private set; }

		protected IBOLTweetMapper BolTweetMapper { get; private set; }

		protected IDALTweetMapper DalTweetMapper { get; private set; }

		protected IBOLUserMapper BolUserMapper { get; private set; }

		protected IDALUserMapper DalUserMapper { get; private set; }

		private ILogger logger;

		public AbstractLocationService(
			ILogger logger,
			ILocationRepository locationRepository,
			IApiLocationServerRequestModelValidator locationModelValidator,
			IBOLLocationMapper bolLocationMapper,
			IDALLocationMapper dalLocationMapper,
			IBOLTweetMapper bolTweetMapper,
			IDALTweetMapper dalTweetMapper,
			IBOLUserMapper bolUserMapper,
			IDALUserMapper dalUserMapper)
			: base()
		{
			this.LocationRepository = locationRepository;
			this.LocationModelValidator = locationModelValidator;
			this.BolLocationMapper = bolLocationMapper;
			this.DalLocationMapper = dalLocationMapper;
			this.BolTweetMapper = bolTweetMapper;
			this.DalTweetMapper = dalTweetMapper;
			this.BolUserMapper = bolUserMapper;
			this.DalUserMapper = dalUserMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLocationServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.LocationRepository.All(limit, offset);

			return this.BolLocationMapper.MapBOToModel(this.DalLocationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLocationServerResponseModel> Get(int locationId)
		{
			var record = await this.LocationRepository.Get(locationId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLocationMapper.MapBOToModel(this.DalLocationMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiLocationServerResponseModel>> Create(
			ApiLocationServerRequestModel model)
		{
			CreateResponse<ApiLocationServerResponseModel> response = ValidationResponseFactory<ApiLocationServerResponseModel>.CreateResponse(await this.LocationModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolLocationMapper.MapModelToBO(default(int), model);
				var record = await this.LocationRepository.Create(this.DalLocationMapper.MapBOToEF(bo));

				response.SetRecord(this.BolLocationMapper.MapBOToModel(this.DalLocationMapper.MapEFToBO(record)));
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
				var bo = this.BolLocationMapper.MapModelToBO(locationId, model);
				await this.LocationRepository.Update(this.DalLocationMapper.MapBOToEF(bo));

				var record = await this.LocationRepository.Get(locationId);

				return ValidationResponseFactory<ApiLocationServerResponseModel>.UpdateResponse(this.BolLocationMapper.MapBOToModel(this.DalLocationMapper.MapEFToBO(record)));
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
			}

			return response;
		}

		public async virtual Task<List<ApiTweetServerResponseModel>> TweetsByLocationId(int locationId, int limit = int.MaxValue, int offset = 0)
		{
			List<Tweet> records = await this.LocationRepository.TweetsByLocationId(locationId, limit, offset);

			return this.BolTweetMapper.MapBOToModel(this.DalTweetMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiUserServerResponseModel>> UsersByLocationLocationId(int locationLocationId, int limit = int.MaxValue, int offset = 0)
		{
			List<User> records = await this.LocationRepository.UsersByLocationLocationId(locationLocationId, limit, offset);

			return this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>d8f68792a5ea43adeb2128cf2beaf884</Hash>
</Codenesium>*/