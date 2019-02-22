using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractRetweetService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IRetweetRepository RetweetRepository { get; private set; }

		protected IApiRetweetServerRequestModelValidator RetweetModelValidator { get; private set; }

		protected IDALRetweetMapper DalRetweetMapper { get; private set; }

		private ILogger logger;

		public AbstractRetweetService(
			ILogger logger,
			MediatR.IMediator mediator,
			IRetweetRepository retweetRepository,
			IApiRetweetServerRequestModelValidator retweetModelValidator,
			IDALRetweetMapper dalRetweetMapper)
			: base()
		{
			this.RetweetRepository = retweetRepository;
			this.RetweetModelValidator = retweetModelValidator;
			this.DalRetweetMapper = dalRetweetMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiRetweetServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Retweet> records = await this.RetweetRepository.All(limit, offset, query);

			return this.DalRetweetMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiRetweetServerResponseModel> Get(int id)
		{
			Retweet record = await this.RetweetRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalRetweetMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiRetweetServerResponseModel>> Create(
			ApiRetweetServerRequestModel model)
		{
			CreateResponse<ApiRetweetServerResponseModel> response = ValidationResponseFactory<ApiRetweetServerResponseModel>.CreateResponse(await this.RetweetModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Retweet record = this.DalRetweetMapper.MapModelToEntity(default(int), model);
				record = await this.RetweetRepository.Create(record);

				response.SetRecord(this.DalRetweetMapper.MapEntityToModel(record));
				await this.mediator.Publish(new RetweetCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiRetweetServerResponseModel>> Update(
			int id,
			ApiRetweetServerRequestModel model)
		{
			var validationResult = await this.RetweetModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Retweet record = this.DalRetweetMapper.MapModelToEntity(id, model);
				await this.RetweetRepository.Update(record);

				record = await this.RetweetRepository.Get(id);

				ApiRetweetServerResponseModel apiModel = this.DalRetweetMapper.MapEntityToModel(record);
				await this.mediator.Publish(new RetweetUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiRetweetServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiRetweetServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.RetweetModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.RetweetRepository.Delete(id);

				await this.mediator.Publish(new RetweetDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiRetweetServerResponseModel>> ByRetwitterUserId(int? retwitterUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Retweet> records = await this.RetweetRepository.ByRetwitterUserId(retwitterUserId, limit, offset);

			return this.DalRetweetMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiRetweetServerResponseModel>> ByTweetTweetId(int tweetTweetId, int limit = 0, int offset = int.MaxValue)
		{
			List<Retweet> records = await this.RetweetRepository.ByTweetTweetId(tweetTweetId, limit, offset);

			return this.DalRetweetMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>cb44c5bda0b93b6ee918284af7e40eb7</Hash>
</Codenesium>*/