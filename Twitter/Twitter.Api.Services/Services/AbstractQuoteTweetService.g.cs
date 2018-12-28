using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractQuoteTweetService : AbstractService
	{
		private IMediator mediator;

		protected IQuoteTweetRepository QuoteTweetRepository { get; private set; }

		protected IApiQuoteTweetServerRequestModelValidator QuoteTweetModelValidator { get; private set; }

		protected IBOLQuoteTweetMapper BolQuoteTweetMapper { get; private set; }

		protected IDALQuoteTweetMapper DalQuoteTweetMapper { get; private set; }

		private ILogger logger;

		public AbstractQuoteTweetService(
			ILogger logger,
			IMediator mediator,
			IQuoteTweetRepository quoteTweetRepository,
			IApiQuoteTweetServerRequestModelValidator quoteTweetModelValidator,
			IBOLQuoteTweetMapper bolQuoteTweetMapper,
			IDALQuoteTweetMapper dalQuoteTweetMapper)
			: base()
		{
			this.QuoteTweetRepository = quoteTweetRepository;
			this.QuoteTweetModelValidator = quoteTweetModelValidator;
			this.BolQuoteTweetMapper = bolQuoteTweetMapper;
			this.DalQuoteTweetMapper = dalQuoteTweetMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiQuoteTweetServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.QuoteTweetRepository.All(limit, offset);

			return this.BolQuoteTweetMapper.MapBOToModel(this.DalQuoteTweetMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiQuoteTweetServerResponseModel> Get(int quoteTweetId)
		{
			var record = await this.QuoteTweetRepository.Get(quoteTweetId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolQuoteTweetMapper.MapBOToModel(this.DalQuoteTweetMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiQuoteTweetServerResponseModel>> Create(
			ApiQuoteTweetServerRequestModel model)
		{
			CreateResponse<ApiQuoteTweetServerResponseModel> response = ValidationResponseFactory<ApiQuoteTweetServerResponseModel>.CreateResponse(await this.QuoteTweetModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolQuoteTweetMapper.MapModelToBO(default(int), model);
				var record = await this.QuoteTweetRepository.Create(this.DalQuoteTweetMapper.MapBOToEF(bo));

				var businessObject = this.DalQuoteTweetMapper.MapEFToBO(record);
				response.SetRecord(this.BolQuoteTweetMapper.MapBOToModel(businessObject));
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
				var bo = this.BolQuoteTweetMapper.MapModelToBO(quoteTweetId, model);
				await this.QuoteTweetRepository.Update(this.DalQuoteTweetMapper.MapBOToEF(bo));

				var record = await this.QuoteTweetRepository.Get(quoteTweetId);

				var businessObject = this.DalQuoteTweetMapper.MapEFToBO(record);
				var apiModel = this.BolQuoteTweetMapper.MapBOToModel(businessObject);
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

			return this.BolQuoteTweetMapper.MapBOToModel(this.DalQuoteTweetMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiQuoteTweetServerResponseModel>> BySourceTweetId(int sourceTweetId, int limit = 0, int offset = int.MaxValue)
		{
			List<QuoteTweet> records = await this.QuoteTweetRepository.BySourceTweetId(sourceTweetId, limit, offset);

			return this.BolQuoteTweetMapper.MapBOToModel(this.DalQuoteTweetMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>871e68371fae359317200e9a62712b2e</Hash>
</Codenesium>*/