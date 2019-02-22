using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractDirectTweetService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IDirectTweetRepository DirectTweetRepository { get; private set; }

		protected IApiDirectTweetServerRequestModelValidator DirectTweetModelValidator { get; private set; }

		protected IDALDirectTweetMapper DalDirectTweetMapper { get; private set; }

		private ILogger logger;

		public AbstractDirectTweetService(
			ILogger logger,
			MediatR.IMediator mediator,
			IDirectTweetRepository directTweetRepository,
			IApiDirectTweetServerRequestModelValidator directTweetModelValidator,
			IDALDirectTweetMapper dalDirectTweetMapper)
			: base()
		{
			this.DirectTweetRepository = directTweetRepository;
			this.DirectTweetModelValidator = directTweetModelValidator;
			this.DalDirectTweetMapper = dalDirectTweetMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiDirectTweetServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<DirectTweet> records = await this.DirectTweetRepository.All(limit, offset, query);

			return this.DalDirectTweetMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiDirectTweetServerResponseModel> Get(int tweetId)
		{
			DirectTweet record = await this.DirectTweetRepository.Get(tweetId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalDirectTweetMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiDirectTweetServerResponseModel>> Create(
			ApiDirectTweetServerRequestModel model)
		{
			CreateResponse<ApiDirectTweetServerResponseModel> response = ValidationResponseFactory<ApiDirectTweetServerResponseModel>.CreateResponse(await this.DirectTweetModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				DirectTweet record = this.DalDirectTweetMapper.MapModelToEntity(default(int), model);
				record = await this.DirectTweetRepository.Create(record);

				response.SetRecord(this.DalDirectTweetMapper.MapEntityToModel(record));
				await this.mediator.Publish(new DirectTweetCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDirectTweetServerResponseModel>> Update(
			int tweetId,
			ApiDirectTweetServerRequestModel model)
		{
			var validationResult = await this.DirectTweetModelValidator.ValidateUpdateAsync(tweetId, model);

			if (validationResult.IsValid)
			{
				DirectTweet record = this.DalDirectTweetMapper.MapModelToEntity(tweetId, model);
				await this.DirectTweetRepository.Update(record);

				record = await this.DirectTweetRepository.Get(tweetId);

				ApiDirectTweetServerResponseModel apiModel = this.DalDirectTweetMapper.MapEntityToModel(record);
				await this.mediator.Publish(new DirectTweetUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiDirectTweetServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiDirectTweetServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int tweetId)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.DirectTweetModelValidator.ValidateDeleteAsync(tweetId));

			if (response.Success)
			{
				await this.DirectTweetRepository.Delete(tweetId);

				await this.mediator.Publish(new DirectTweetDeletedNotification(tweetId));
			}

			return response;
		}

		public async virtual Task<List<ApiDirectTweetServerResponseModel>> ByTaggedUserId(int taggedUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<DirectTweet> records = await this.DirectTweetRepository.ByTaggedUserId(taggedUserId, limit, offset);

			return this.DalDirectTweetMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>5ac93a5610adfabf8643bfab7de0fc7c</Hash>
</Codenesium>*/