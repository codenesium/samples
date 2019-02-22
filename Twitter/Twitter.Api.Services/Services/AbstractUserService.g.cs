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
		private MediatR.IMediator mediator;

		protected IUserRepository UserRepository { get; private set; }

		protected IApiUserServerRequestModelValidator UserModelValidator { get; private set; }

		protected IDALUserMapper DalUserMapper { get; private set; }

		protected IDALDirectTweetMapper DalDirectTweetMapper { get; private set; }

		protected IDALFollowerMapper DalFollowerMapper { get; private set; }

		protected IDALMessageMapper DalMessageMapper { get; private set; }

		protected IDALMessengerMapper DalMessengerMapper { get; private set; }

		protected IDALQuoteTweetMapper DalQuoteTweetMapper { get; private set; }

		protected IDALReplyMapper DalReplyMapper { get; private set; }

		protected IDALRetweetMapper DalRetweetMapper { get; private set; }

		protected IDALTweetMapper DalTweetMapper { get; private set; }

		private ILogger logger;

		public AbstractUserService(
			ILogger logger,
			MediatR.IMediator mediator,
			IUserRepository userRepository,
			IApiUserServerRequestModelValidator userModelValidator,
			IDALUserMapper dalUserMapper,
			IDALDirectTweetMapper dalDirectTweetMapper,
			IDALFollowerMapper dalFollowerMapper,
			IDALMessageMapper dalMessageMapper,
			IDALMessengerMapper dalMessengerMapper,
			IDALQuoteTweetMapper dalQuoteTweetMapper,
			IDALReplyMapper dalReplyMapper,
			IDALRetweetMapper dalRetweetMapper,
			IDALTweetMapper dalTweetMapper)
			: base()
		{
			this.UserRepository = userRepository;
			this.UserModelValidator = userModelValidator;
			this.DalUserMapper = dalUserMapper;
			this.DalDirectTweetMapper = dalDirectTweetMapper;
			this.DalFollowerMapper = dalFollowerMapper;
			this.DalMessageMapper = dalMessageMapper;
			this.DalMessengerMapper = dalMessengerMapper;
			this.DalQuoteTweetMapper = dalQuoteTweetMapper;
			this.DalReplyMapper = dalReplyMapper;
			this.DalRetweetMapper = dalRetweetMapper;
			this.DalTweetMapper = dalTweetMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiUserServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<User> records = await this.UserRepository.All(limit, offset, query);

			return this.DalUserMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiUserServerResponseModel> Get(int userId)
		{
			User record = await this.UserRepository.Get(userId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalUserMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiUserServerResponseModel>> Create(
			ApiUserServerRequestModel model)
		{
			CreateResponse<ApiUserServerResponseModel> response = ValidationResponseFactory<ApiUserServerResponseModel>.CreateResponse(await this.UserModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				User record = this.DalUserMapper.MapModelToEntity(default(int), model);
				record = await this.UserRepository.Create(record);

				response.SetRecord(this.DalUserMapper.MapEntityToModel(record));
				await this.mediator.Publish(new UserCreatedNotification(response.Record));
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
				User record = this.DalUserMapper.MapModelToEntity(userId, model);
				await this.UserRepository.Update(record);

				record = await this.UserRepository.Get(userId);

				ApiUserServerResponseModel apiModel = this.DalUserMapper.MapEntityToModel(record);
				await this.mediator.Publish(new UserUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiUserServerResponseModel>.UpdateResponse(apiModel);
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

				await this.mediator.Publish(new UserDeletedNotification(userId));
			}

			return response;
		}

		public async virtual Task<List<ApiUserServerResponseModel>> ByLocationLocationId(int locationLocationId, int limit = 0, int offset = int.MaxValue)
		{
			List<User> records = await this.UserRepository.ByLocationLocationId(locationLocationId, limit, offset);

			return this.DalUserMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiDirectTweetServerResponseModel>> DirectTweetsByTaggedUserId(int taggedUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<DirectTweet> records = await this.UserRepository.DirectTweetsByTaggedUserId(taggedUserId, limit, offset);

			return this.DalDirectTweetMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiFollowerServerResponseModel>> FollowersByFollowedUserId(int followedUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Follower> records = await this.UserRepository.FollowersByFollowedUserId(followedUserId, limit, offset);

			return this.DalFollowerMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiFollowerServerResponseModel>> FollowersByFollowingUserId(int followingUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Follower> records = await this.UserRepository.FollowersByFollowingUserId(followingUserId, limit, offset);

			return this.DalFollowerMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiMessageServerResponseModel>> MessagesBySenderUserId(int senderUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Message> records = await this.UserRepository.MessagesBySenderUserId(senderUserId, limit, offset);

			return this.DalMessageMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiMessengerServerResponseModel>> MessengersByToUserId(int toUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Messenger> records = await this.UserRepository.MessengersByToUserId(toUserId, limit, offset);

			return this.DalMessengerMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiMessengerServerResponseModel>> MessengersByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			List<Messenger> records = await this.UserRepository.MessengersByUserId(userId, limit, offset);

			return this.DalMessengerMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiQuoteTweetServerResponseModel>> QuoteTweetsByRetweeterUserId(int retweeterUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<QuoteTweet> records = await this.UserRepository.QuoteTweetsByRetweeterUserId(retweeterUserId, limit, offset);

			return this.DalQuoteTweetMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiReplyServerResponseModel>> RepliesByReplierUserId(int replierUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Reply> records = await this.UserRepository.RepliesByReplierUserId(replierUserId, limit, offset);

			return this.DalReplyMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiRetweetServerResponseModel>> RetweetsByRetwitterUserId(int retwitterUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Retweet> records = await this.UserRepository.RetweetsByRetwitterUserId(retwitterUserId, limit, offset);

			return this.DalRetweetMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiTweetServerResponseModel>> TweetsByUserUserId(int userUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Tweet> records = await this.UserRepository.TweetsByUserUserId(userUserId, limit, offset);

			return this.DalTweetMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiUserServerResponseModel>> ByTweetId(int tweetId, int limit = int.MaxValue, int offset = 0)
		{
			List<User> records = await this.UserRepository.ByTweetId(tweetId, limit, offset);

			return this.DalUserMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>de2674d28c086c2f124d89fa889086bf</Hash>
</Codenesium>*/