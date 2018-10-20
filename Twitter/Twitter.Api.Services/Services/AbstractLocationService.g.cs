using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractLocationService : AbstractService
	{
		protected ILocationRepository LocationRepository { get; private set; }

		protected IApiLocationRequestModelValidator LocationModelValidator { get; private set; }

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
			IApiLocationRequestModelValidator locationModelValidator,
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

		public virtual async Task<List<ApiLocationResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.LocationRepository.All(limit, offset);

			return this.BolLocationMapper.MapBOToModel(this.DalLocationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLocationResponseModel> Get(int locationId)
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

		public virtual async Task<CreateResponse<ApiLocationResponseModel>> Create(
			ApiLocationRequestModel model)
		{
			CreateResponse<ApiLocationResponseModel> response = new CreateResponse<ApiLocationResponseModel>(await this.LocationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolLocationMapper.MapModelToBO(default(int), model);
				var record = await this.LocationRepository.Create(this.DalLocationMapper.MapBOToEF(bo));

				response.SetRecord(this.BolLocationMapper.MapBOToModel(this.DalLocationMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLocationResponseModel>> Update(
			int locationId,
			ApiLocationRequestModel model)
		{
			var validationResult = await this.LocationModelValidator.ValidateUpdateAsync(locationId, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolLocationMapper.MapModelToBO(locationId, model);
				await this.LocationRepository.Update(this.DalLocationMapper.MapBOToEF(bo));

				var record = await this.LocationRepository.Get(locationId);

				return new UpdateResponse<ApiLocationResponseModel>(this.BolLocationMapper.MapBOToModel(this.DalLocationMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiLocationResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int locationId)
		{
			ActionResponse response = new ActionResponse(await this.LocationModelValidator.ValidateDeleteAsync(locationId));
			if (response.Success)
			{
				await this.LocationRepository.Delete(locationId);
			}

			return response;
		}

		public async virtual Task<List<ApiTweetResponseModel>> TweetsByLocationId(int locationId, int limit = int.MaxValue, int offset = 0)
		{
			List<Tweet> records = await this.LocationRepository.TweetsByLocationId(locationId, limit, offset);

			return this.BolTweetMapper.MapBOToModel(this.DalTweetMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiUserResponseModel>> UsersByLocationLocationId(int locationLocationId, int limit = int.MaxValue, int offset = 0)
		{
			List<User> records = await this.LocationRepository.UsersByLocationLocationId(locationLocationId, limit, offset);

			return this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>df3c4d6d6ad25c6cf706faa9db9ce2f7</Hash>
</Codenesium>*/