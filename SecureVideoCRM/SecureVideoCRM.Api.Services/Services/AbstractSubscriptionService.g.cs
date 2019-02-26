using Microsoft.Extensions.Logging;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public abstract class AbstractSubscriptionService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ISubscriptionRepository SubscriptionRepository { get; private set; }

		protected IApiSubscriptionServerRequestModelValidator SubscriptionModelValidator { get; private set; }

		protected IDALSubscriptionMapper DalSubscriptionMapper { get; private set; }

		protected IDALUserMapper DalUserMapper { get; private set; }

		private ILogger logger;

		public AbstractSubscriptionService(
			ILogger logger,
			MediatR.IMediator mediator,
			ISubscriptionRepository subscriptionRepository,
			IApiSubscriptionServerRequestModelValidator subscriptionModelValidator,
			IDALSubscriptionMapper dalSubscriptionMapper,
			IDALUserMapper dalUserMapper)
			: base()
		{
			this.SubscriptionRepository = subscriptionRepository;
			this.SubscriptionModelValidator = subscriptionModelValidator;
			this.DalSubscriptionMapper = dalSubscriptionMapper;
			this.DalUserMapper = dalUserMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiSubscriptionServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Subscription> records = await this.SubscriptionRepository.All(limit, offset, query);

			return this.DalSubscriptionMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiSubscriptionServerResponseModel> Get(int id)
		{
			Subscription record = await this.SubscriptionRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalSubscriptionMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiSubscriptionServerResponseModel>> Create(
			ApiSubscriptionServerRequestModel model)
		{
			CreateResponse<ApiSubscriptionServerResponseModel> response = ValidationResponseFactory<ApiSubscriptionServerResponseModel>.CreateResponse(await this.SubscriptionModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Subscription record = this.DalSubscriptionMapper.MapModelToEntity(default(int), model);
				record = await this.SubscriptionRepository.Create(record);

				response.SetRecord(this.DalSubscriptionMapper.MapEntityToModel(record));
				await this.mediator.Publish(new SubscriptionCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSubscriptionServerResponseModel>> Update(
			int id,
			ApiSubscriptionServerRequestModel model)
		{
			var validationResult = await this.SubscriptionModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Subscription record = this.DalSubscriptionMapper.MapModelToEntity(id, model);
				await this.SubscriptionRepository.Update(record);

				record = await this.SubscriptionRepository.Get(id);

				ApiSubscriptionServerResponseModel apiModel = this.DalSubscriptionMapper.MapEntityToModel(record);
				await this.mediator.Publish(new SubscriptionUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiSubscriptionServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiSubscriptionServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.SubscriptionModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.SubscriptionRepository.Delete(id);

				await this.mediator.Publish(new SubscriptionDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiUserServerResponseModel>> UsersBySubscriptionId(int subscriptionId, int limit = int.MaxValue, int offset = 0)
		{
			List<User> records = await this.SubscriptionRepository.UsersBySubscriptionId(subscriptionId, limit, offset);

			return this.DalUserMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>f2780efa189ea36add9d2967b47bfebc</Hash>
</Codenesium>*/