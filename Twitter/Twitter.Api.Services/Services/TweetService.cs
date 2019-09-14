using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class TweetService : AbstractService, ITweetService
	{
		private MediatR.IMediator mediator;

		protected ITweetRepository TweetRepository { get; private set; }

		protected IApiTweetServerRequestModelValidator TweetModelValidator { get; private set; }

		protected IDALTweetMapper DalTweetMapper { get; private set; }

		protected IDALQuoteTweetMapper DalQuoteTweetMapper { get; private set; }

		protected IDALRetweetMapper DalRetweetMapper { get; private set; }

		private ILogger logger;

		public TweetService(
			ILogger<ITweetService> logger,
			MediatR.IMediator mediator,
			ITweetRepository tweetRepository,
			IApiTweetServerRequestModelValidator tweetModelValidator,
			IDALTweetMapper dalTweetMapper,
			IDALQuoteTweetMapper dalQuoteTweetMapper,
			IDALRetweetMapper dalRetweetMapper)
			: base()
		{
			this.TweetRepository = tweetRepository;
			this.TweetModelValidator = tweetModelValidator;
			this.DalTweetMapper = dalTweetMapper;
			this.DalQuoteTweetMapper = dalQuoteTweetMapper;
			this.DalRetweetMapper = dalRetweetMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTweetServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Tweet> records = await this.TweetRepository.All(limit, offset, query);

			return this.DalTweetMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiTweetServerResponseModel> Get(int tweetId)
		{
			Tweet record = await this.TweetRepository.Get(tweetId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalTweetMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiTweetServerResponseModel>> Create(
			ApiTweetServerRequestModel model)
		{
			CreateResponse<ApiTweetServerResponseModel> response = ValidationResponseFactory<ApiTweetServerResponseModel>.CreateResponse(await this.TweetModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Tweet record = this.DalTweetMapper.MapModelToEntity(default(int), model);
				record = await this.TweetRepository.Create(record);

				response.SetRecord(this.DalTweetMapper.MapEntityToModel(record));
				await this.mediator.Publish(new TweetCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTweetServerResponseModel>> Update(
			int tweetId,
			ApiTweetServerRequestModel model)
		{
			var validationResult = await this.TweetModelValidator.ValidateUpdateAsync(tweetId, model);

			if (validationResult.IsValid)
			{
				Tweet record = this.DalTweetMapper.MapModelToEntity(tweetId, model);
				await this.TweetRepository.Update(record);

				record = await this.TweetRepository.Get(tweetId);

				ApiTweetServerResponseModel apiModel = this.DalTweetMapper.MapEntityToModel(record);
				await this.mediator.Publish(new TweetUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiTweetServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiTweetServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int tweetId)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TweetModelValidator.ValidateDeleteAsync(tweetId));

			if (response.Success)
			{
				await this.TweetRepository.Delete(tweetId);

				await this.mediator.Publish(new TweetDeletedNotification(tweetId));
			}

			return response;
		}

		public async virtual Task<List<ApiTweetServerResponseModel>> ByLocationId(int locationId, int limit = 0, int offset = int.MaxValue)
		{
			List<Tweet> records = await this.TweetRepository.ByLocationId(locationId, limit, offset);

			return this.DalTweetMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiTweetServerResponseModel>> ByUserUserId(int userUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Tweet> records = await this.TweetRepository.ByUserUserId(userUserId, limit, offset);

			return this.DalTweetMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiQuoteTweetServerResponseModel>> QuoteTweetsBySourceTweetId(int sourceTweetId, int limit = int.MaxValue, int offset = 0)
		{
			List<QuoteTweet> records = await this.TweetRepository.QuoteTweetsBySourceTweetId(sourceTweetId, limit, offset);

			return this.DalQuoteTweetMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiRetweetServerResponseModel>> RetweetsByTweetTweetId(int tweetTweetId, int limit = int.MaxValue, int offset = 0)
		{
			List<Retweet> records = await this.TweetRepository.RetweetsByTweetTweetId(tweetTweetId, limit, offset);

			return this.DalRetweetMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiTweetServerResponseModel>> ByLikerUserId(int likerUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Tweet> records = await this.TweetRepository.ByLikerUserId(likerUserId, limit, offset);

			return this.DalTweetMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>c81c0ccea764b5a9d37ed0848d7acfab</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/