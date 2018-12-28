using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractTweetService : AbstractService
	{
		private IMediator mediator;

		protected ITweetRepository TweetRepository { get; private set; }

		protected IApiTweetServerRequestModelValidator TweetModelValidator { get; private set; }

		protected IBOLTweetMapper BolTweetMapper { get; private set; }

		protected IDALTweetMapper DalTweetMapper { get; private set; }

		protected IBOLQuoteTweetMapper BolQuoteTweetMapper { get; private set; }

		protected IDALQuoteTweetMapper DalQuoteTweetMapper { get; private set; }

		protected IBOLRetweetMapper BolRetweetMapper { get; private set; }

		protected IDALRetweetMapper DalRetweetMapper { get; private set; }

		private ILogger logger;

		public AbstractTweetService(
			ILogger logger,
			IMediator mediator,
			ITweetRepository tweetRepository,
			IApiTweetServerRequestModelValidator tweetModelValidator,
			IBOLTweetMapper bolTweetMapper,
			IDALTweetMapper dalTweetMapper,
			IBOLQuoteTweetMapper bolQuoteTweetMapper,
			IDALQuoteTweetMapper dalQuoteTweetMapper,
			IBOLRetweetMapper bolRetweetMapper,
			IDALRetweetMapper dalRetweetMapper)
			: base()
		{
			this.TweetRepository = tweetRepository;
			this.TweetModelValidator = tweetModelValidator;
			this.BolTweetMapper = bolTweetMapper;
			this.DalTweetMapper = dalTweetMapper;
			this.BolQuoteTweetMapper = bolQuoteTweetMapper;
			this.DalQuoteTweetMapper = dalQuoteTweetMapper;
			this.BolRetweetMapper = bolRetweetMapper;
			this.DalRetweetMapper = dalRetweetMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTweetServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TweetRepository.All(limit, offset);

			return this.BolTweetMapper.MapBOToModel(this.DalTweetMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTweetServerResponseModel> Get(int tweetId)
		{
			var record = await this.TweetRepository.Get(tweetId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTweetMapper.MapBOToModel(this.DalTweetMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTweetServerResponseModel>> Create(
			ApiTweetServerRequestModel model)
		{
			CreateResponse<ApiTweetServerResponseModel> response = ValidationResponseFactory<ApiTweetServerResponseModel>.CreateResponse(await this.TweetModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolTweetMapper.MapModelToBO(default(int), model);
				var record = await this.TweetRepository.Create(this.DalTweetMapper.MapBOToEF(bo));

				var businessObject = this.DalTweetMapper.MapEFToBO(record);
				response.SetRecord(this.BolTweetMapper.MapBOToModel(businessObject));
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
				var bo = this.BolTweetMapper.MapModelToBO(tweetId, model);
				await this.TweetRepository.Update(this.DalTweetMapper.MapBOToEF(bo));

				var record = await this.TweetRepository.Get(tweetId);

				var businessObject = this.DalTweetMapper.MapEFToBO(record);
				var apiModel = this.BolTweetMapper.MapBOToModel(businessObject);
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

			return this.BolTweetMapper.MapBOToModel(this.DalTweetMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiTweetServerResponseModel>> ByUserUserId(int userUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Tweet> records = await this.TweetRepository.ByUserUserId(userUserId, limit, offset);

			return this.BolTweetMapper.MapBOToModel(this.DalTweetMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiQuoteTweetServerResponseModel>> QuoteTweetsBySourceTweetId(int sourceTweetId, int limit = int.MaxValue, int offset = 0)
		{
			List<QuoteTweet> records = await this.TweetRepository.QuoteTweetsBySourceTweetId(sourceTweetId, limit, offset);

			return this.BolQuoteTweetMapper.MapBOToModel(this.DalQuoteTweetMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiRetweetServerResponseModel>> RetweetsByTweetTweetId(int tweetTweetId, int limit = int.MaxValue, int offset = 0)
		{
			List<Retweet> records = await this.TweetRepository.RetweetsByTweetTweetId(tweetTweetId, limit, offset);

			return this.BolRetweetMapper.MapBOToModel(this.DalRetweetMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>261fd960cc10476652afdc50b6502e38</Hash>
</Codenesium>*/