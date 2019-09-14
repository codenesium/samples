using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class QuoteTweetService : AbstractService, IQuoteTweetService
	{
		private MediatR.IMediator mediator;

		protected IQuoteTweetRepository QuoteTweetRepository { get; private set; }

		protected IApiQuoteTweetServerRequestModelValidator QuoteTweetModelValidator { get; private set; }

		protected IDALQuoteTweetMapper DalQuoteTweetMapper { get; private set; }

		private ILogger logger;

		public QuoteTweetService(
			ILogger<IQuoteTweetService> logger,
			MediatR.IMediator mediator,
			IQuoteTweetRepository quoteTweetRepository,
			IApiQuoteTweetServerRequestModelValidator quoteTweetModelValidator,
			IDALQuoteTweetMapper dalQuoteTweetMapper)
			: base()
		{
			this.QuoteTweetRepository = quoteTweetRepository;
			this.QuoteTweetModelValidator = quoteTweetModelValidator;
			this.DalQuoteTweetMapper = dalQuoteTweetMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiQuoteTweetServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<QuoteTweet> records = await this.QuoteTweetRepository.All(limit, offset, query);

			return this.DalQuoteTweetMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiQuoteTweetServerResponseModel> Get(int quoteTweetId)
		{
			QuoteTweet record = await this.QuoteTweetRepository.Get(quoteTweetId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalQuoteTweetMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiQuoteTweetServerResponseModel>> Create(
			ApiQuoteTweetServerRequestModel model)
		{
			CreateResponse<ApiQuoteTweetServerResponseModel> response = ValidationResponseFactory<ApiQuoteTweetServerResponseModel>.CreateResponse(await this.QuoteTweetModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				QuoteTweet record = this.DalQuoteTweetMapper.MapModelToEntity(default(int), model);
				record = await this.QuoteTweetRepository.Create(record);

				response.SetRecord(this.DalQuoteTweetMapper.MapEntityToModel(record));
				await this.mediator.Publish(new QuoteTweetCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiQuoteTweetServerResponseModel>> Update(
			int quoteTweetId,
			ApiQuoteTweetServerRequestModel model)
		{
			var validationResult = await this.QuoteTweetModelValidator.ValidateUpdateAsync(quoteTweetId, model);

			if (validationResult.IsValid)
			{
				QuoteTweet record = this.DalQuoteTweetMapper.MapModelToEntity(quoteTweetId, model);
				await this.QuoteTweetRepository.Update(record);

				record = await this.QuoteTweetRepository.Get(quoteTweetId);

				ApiQuoteTweetServerResponseModel apiModel = this.DalQuoteTweetMapper.MapEntityToModel(record);
				await this.mediator.Publish(new QuoteTweetUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiQuoteTweetServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiQuoteTweetServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int quoteTweetId)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.QuoteTweetModelValidator.ValidateDeleteAsync(quoteTweetId));

			if (response.Success)
			{
				await this.QuoteTweetRepository.Delete(quoteTweetId);

				await this.mediator.Publish(new QuoteTweetDeletedNotification(quoteTweetId));
			}

			return response;
		}

		public async virtual Task<List<ApiQuoteTweetServerResponseModel>> ByRetweeterUserId(int retweeterUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<QuoteTweet> records = await this.QuoteTweetRepository.ByRetweeterUserId(retweeterUserId, limit, offset);

			return this.DalQuoteTweetMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiQuoteTweetServerResponseModel>> BySourceTweetId(int sourceTweetId, int limit = 0, int offset = int.MaxValue)
		{
			List<QuoteTweet> records = await this.QuoteTweetRepository.BySourceTweetId(sourceTweetId, limit, offset);

			return this.DalQuoteTweetMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>5ad6c543ba2903e28e936f580e6720ff</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/