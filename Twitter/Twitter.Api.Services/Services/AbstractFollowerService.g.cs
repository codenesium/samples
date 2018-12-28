using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractFollowerService : AbstractService
	{
		private IMediator mediator;

		protected IFollowerRepository FollowerRepository { get; private set; }

		protected IApiFollowerServerRequestModelValidator FollowerModelValidator { get; private set; }

		protected IBOLFollowerMapper BolFollowerMapper { get; private set; }

		protected IDALFollowerMapper DalFollowerMapper { get; private set; }

		private ILogger logger;

		public AbstractFollowerService(
			ILogger logger,
			IMediator mediator,
			IFollowerRepository followerRepository,
			IApiFollowerServerRequestModelValidator followerModelValidator,
			IBOLFollowerMapper bolFollowerMapper,
			IDALFollowerMapper dalFollowerMapper)
			: base()
		{
			this.FollowerRepository = followerRepository;
			this.FollowerModelValidator = followerModelValidator;
			this.BolFollowerMapper = bolFollowerMapper;
			this.DalFollowerMapper = dalFollowerMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiFollowerServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.FollowerRepository.All(limit, offset);

			return this.BolFollowerMapper.MapBOToModel(this.DalFollowerMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiFollowerServerResponseModel> Get(int id)
		{
			var record = await this.FollowerRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolFollowerMapper.MapBOToModel(this.DalFollowerMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiFollowerServerResponseModel>> Create(
			ApiFollowerServerRequestModel model)
		{
			CreateResponse<ApiFollowerServerResponseModel> response = ValidationResponseFactory<ApiFollowerServerResponseModel>.CreateResponse(await this.FollowerModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolFollowerMapper.MapModelToBO(default(int), model);
				var record = await this.FollowerRepository.Create(this.DalFollowerMapper.MapBOToEF(bo));

				var businessObject = this.DalFollowerMapper.MapEFToBO(record);
				response.SetRecord(this.BolFollowerMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new FollowerCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiFollowerServerResponseModel>> Update(
			int id,
			ApiFollowerServerRequestModel model)
		{
			var validationResult = await this.FollowerModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolFollowerMapper.MapModelToBO(id, model);
				await this.FollowerRepository.Update(this.DalFollowerMapper.MapBOToEF(bo));

				var record = await this.FollowerRepository.Get(id);

				var businessObject = this.DalFollowerMapper.MapEFToBO(record);
				var apiModel = this.BolFollowerMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new FollowerUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiFollowerServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiFollowerServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.FollowerModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.FollowerRepository.Delete(id);

				await this.mediator.Publish(new FollowerDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiFollowerServerResponseModel>> ByFollowedUserId(int followedUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Follower> records = await this.FollowerRepository.ByFollowedUserId(followedUserId, limit, offset);

			return this.BolFollowerMapper.MapBOToModel(this.DalFollowerMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiFollowerServerResponseModel>> ByFollowingUserId(int followingUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Follower> records = await this.FollowerRepository.ByFollowingUserId(followingUserId, limit, offset);

			return this.BolFollowerMapper.MapBOToModel(this.DalFollowerMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>8918cbb02bac594d5abffd64a700020b</Hash>
</Codenesium>*/