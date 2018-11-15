using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractUserService : AbstractService
	{
		protected IUserRepository UserRepository { get; private set; }

		protected IApiUserServerRequestModelValidator UserModelValidator { get; private set; }

		protected IBOLUserMapper BolUserMapper { get; private set; }

		protected IDALUserMapper DalUserMapper { get; private set; }

		protected IBOLDirectTweetMapper BolDirectTweetMapper { get; private set; }

		protected IDALDirectTweetMapper DalDirectTweetMapper { get; private set; }

		protected IBOLFollowerMapper BolFollowerMapper { get; private set; }

		protected IDALFollowerMapper DalFollowerMapper { get; private set; }

		protected IBOLMessageMapper BolMessageMapper { get; private set; }

		protected IDALMessageMapper DalMessageMapper { get; private set; }

		protected IBOLMessengerMapper BolMessengerMapper { get; private set; }

		protected IDALMessengerMapper DalMessengerMapper { get; private set; }

		protected IBOLQuoteTweetMapper BolQuoteTweetMapper { get; private set; }

		protected IDALQuoteTweetMapper DalQuoteTweetMapper { get; private set; }

		protected IBOLReplyMapper BolReplyMapper { get; private set; }

		protected IDALReplyMapper DalReplyMapper { get; private set; }

		protected IBOLRetweetMapper BolRetweetMapper { get; private set; }

		protected IDALRetweetMapper DalRetweetMapper { get; private set; }

		protected IBOLTweetMapper BolTweetMapper { get; private set; }

		protected IDALTweetMapper DalTweetMapper { get; private set; }

		private ILogger logger;

		public AbstractUserService(
			ILogger logger,
			IUserRepository userRepository,
			IApiUserServerRequestModelValidator userModelValidator,
			IBOLUserMapper bolUserMapper,
			IDALUserMapper dalUserMapper,
			IBOLDirectTweetMapper bolDirectTweetMapper,
			IDALDirectTweetMapper dalDirectTweetMapper,
			IBOLFollowerMapper bolFollowerMapper,
			IDALFollowerMapper dalFollowerMapper,
			IBOLMessageMapper bolMessageMapper,
			IDALMessageMapper dalMessageMapper,
			IBOLMessengerMapper bolMessengerMapper,
			IDALMessengerMapper dalMessengerMapper,
			IBOLQuoteTweetMapper bolQuoteTweetMapper,
			IDALQuoteTweetMapper dalQuoteTweetMapper,
			IBOLReplyMapper bolReplyMapper,
			IDALReplyMapper dalReplyMapper,
			IBOLRetweetMapper bolRetweetMapper,
			IDALRetweetMapper dalRetweetMapper,
			IBOLTweetMapper bolTweetMapper,
			IDALTweetMapper dalTweetMapper)
			: base()
		{
			this.UserRepository = userRepository;
			this.UserModelValidator = userModelValidator;
			this.BolUserMapper = bolUserMapper;
			this.DalUserMapper = dalUserMapper;
			this.BolDirectTweetMapper = bolDirectTweetMapper;
			this.DalDirectTweetMapper = dalDirectTweetMapper;
			this.BolFollowerMapper = bolFollowerMapper;
			this.DalFollowerMapper = dalFollowerMapper;
			this.BolMessageMapper = bolMessageMapper;
			this.DalMessageMapper = dalMessageMapper;
			this.BolMessengerMapper = bolMessengerMapper;
			this.DalMessengerMapper = dalMessengerMapper;
			this.BolQuoteTweetMapper = bolQuoteTweetMapper;
			this.DalQuoteTweetMapper = dalQuoteTweetMapper;
			this.BolReplyMapper = bolReplyMapper;
			this.DalReplyMapper = dalReplyMapper;
			this.BolRetweetMapper = bolRetweetMapper;
			this.DalRetweetMapper = dalRetweetMapper;
			this.BolTweetMapper = bolTweetMapper;
			this.DalTweetMapper = dalTweetMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiUserServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.UserRepository.All(limit, offset);

			return this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiUserServerResponseModel> Get(int userId)
		{
			var record = await this.UserRepository.Get(userId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiUserServerResponseModel>> Create(
			ApiUserServerRequestModel model)
		{
			CreateResponse<ApiUserServerResponseModel> response = ValidationResponseFactory<ApiUserServerResponseModel>.CreateResponse(await this.UserModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolUserMapper.MapModelToBO(default(int), model);
				var record = await this.UserRepository.Create(this.DalUserMapper.MapBOToEF(bo));

				response.SetRecord(this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiUserServerResponseModel>> Update(
			int userId,
			ApiUserServerRequestModel model)
		{
			var validationResult = await this.UserModelValidator.ValidateUpdateAsync(userId, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolUserMapper.MapModelToBO(userId, model);
				await this.UserRepository.Update(this.DalUserMapper.MapBOToEF(bo));

				var record = await this.UserRepository.Get(userId);

				return ValidationResponseFactory<ApiUserServerResponseModel>.UpdateResponse(this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiUserServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int userId)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.UserModelValidator.ValidateDeleteAsync(userId));

			if (response.Success)
			{
				await this.UserRepository.Delete(userId);
			}

			return response;
		}

		public async virtual Task<List<ApiUserServerResponseModel>> ByLocationLocationId(int locationLocationId, int limit = 0, int offset = int.MaxValue)
		{
			List<User> records = await this.UserRepository.ByLocationLocationId(locationLocationId, limit, offset);

			return this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiDirectTweetServerResponseModel>> DirectTweetsByTaggedUserId(int taggedUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<DirectTweet> records = await this.UserRepository.DirectTweetsByTaggedUserId(taggedUserId, limit, offset);

			return this.BolDirectTweetMapper.MapBOToModel(this.DalDirectTweetMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiFollowerServerResponseModel>> FollowersByFollowedUserId(int followedUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Follower> records = await this.UserRepository.FollowersByFollowedUserId(followedUserId, limit, offset);

			return this.BolFollowerMapper.MapBOToModel(this.DalFollowerMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiFollowerServerResponseModel>> FollowersByFollowingUserId(int followingUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Follower> records = await this.UserRepository.FollowersByFollowingUserId(followingUserId, limit, offset);

			return this.BolFollowerMapper.MapBOToModel(this.DalFollowerMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiMessageServerResponseModel>> MessagesBySenderUserId(int senderUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Message> records = await this.UserRepository.MessagesBySenderUserId(senderUserId, limit, offset);

			return this.BolMessageMapper.MapBOToModel(this.DalMessageMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiMessengerServerResponseModel>> MessengersByToUserId(int toUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Messenger> records = await this.UserRepository.MessengersByToUserId(toUserId, limit, offset);

			return this.BolMessengerMapper.MapBOToModel(this.DalMessengerMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiMessengerServerResponseModel>> MessengersByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			List<Messenger> records = await this.UserRepository.MessengersByUserId(userId, limit, offset);

			return this.BolMessengerMapper.MapBOToModel(this.DalMessengerMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiQuoteTweetServerResponseModel>> QuoteTweetsByRetweeterUserId(int retweeterUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<QuoteTweet> records = await this.UserRepository.QuoteTweetsByRetweeterUserId(retweeterUserId, limit, offset);

			return this.BolQuoteTweetMapper.MapBOToModel(this.DalQuoteTweetMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiReplyServerResponseModel>> RepliesByReplierUserId(int replierUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Reply> records = await this.UserRepository.RepliesByReplierUserId(replierUserId, limit, offset);

			return this.BolReplyMapper.MapBOToModel(this.DalReplyMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiRetweetServerResponseModel>> RetweetsByRetwitterUserId(int retwitterUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Retweet> records = await this.UserRepository.RetweetsByRetwitterUserId(retwitterUserId, limit, offset);

			return this.BolRetweetMapper.MapBOToModel(this.DalRetweetMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiTweetServerResponseModel>> TweetsByUserUserId(int userUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Tweet> records = await this.UserRepository.TweetsByUserUserId(userUserId, limit, offset);

			return this.BolTweetMapper.MapBOToModel(this.DalTweetMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiUserServerResponseModel>> ByLocationId(int locationId, int limit = int.MaxValue, int offset = 0)
		{
			List<User> records = await this.UserRepository.ByLocationId(locationId, limit, offset);

			return this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiUserServerResponseModel>> BySourceTweetId(int sourceTweetId, int limit = int.MaxValue, int offset = 0)
		{
			List<User> records = await this.UserRepository.BySourceTweetId(sourceTweetId, limit, offset);

			return this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>48d7d01d800ee14ab1555e65a593e535</Hash>
</Codenesium>*/