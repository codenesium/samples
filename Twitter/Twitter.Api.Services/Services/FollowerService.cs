using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class FollowerService : AbstractService, IFollowerService
	{
		private MediatR.IMediator mediator;

		protected IFollowerRepository FollowerRepository { get; private set; }

		protected IApiFollowerServerRequestModelValidator FollowerModelValidator { get; private set; }

		protected IDALFollowerMapper DalFollowerMapper { get; private set; }

		private ILogger logger;

		public FollowerService(
			ILogger<IFollowerService> logger,
			MediatR.IMediator mediator,
			IFollowerRepository followerRepository,
			IApiFollowerServerRequestModelValidator followerModelValidator,
			IDALFollowerMapper dalFollowerMapper)
			: base()
		{
			this.FollowerRepository = followerRepository;
			this.FollowerModelValidator = followerModelValidator;
			this.DalFollowerMapper = dalFollowerMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiFollowerServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Follower> records = await this.FollowerRepository.All(limit, offset, query);

			return this.DalFollowerMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiFollowerServerResponseModel> Get(int id)
		{
			Follower record = await this.FollowerRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalFollowerMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiFollowerServerResponseModel>> Create(
			ApiFollowerServerRequestModel model)
		{
			CreateResponse<ApiFollowerServerResponseModel> response = ValidationResponseFactory<ApiFollowerServerResponseModel>.CreateResponse(await this.FollowerModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Follower record = this.DalFollowerMapper.MapModelToEntity(default(int), model);
				record = await this.FollowerRepository.Create(record);

				response.SetRecord(this.DalFollowerMapper.MapEntityToModel(record));
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
				Follower record = this.DalFollowerMapper.MapModelToEntity(id, model);
				await this.FollowerRepository.Update(record);

				record = await this.FollowerRepository.Get(id);

				ApiFollowerServerResponseModel apiModel = this.DalFollowerMapper.MapEntityToModel(record);
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

			return this.DalFollowerMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiFollowerServerResponseModel>> ByFollowingUserId(int followingUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Follower> records = await this.FollowerRepository.ByFollowingUserId(followingUserId, limit, offset);

			return this.DalFollowerMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>1811557a746eaeec4e94069074b01d3e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/