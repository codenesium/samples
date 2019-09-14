using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class UserService : AbstractService, IUserService
	{
		private MediatR.IMediator mediator;

		protected IUserRepository UserRepository { get; private set; }

		protected IApiUserServerRequestModelValidator UserModelValidator { get; private set; }

		protected IDALUserMapper DalUserMapper { get; private set; }

		protected IDALBadgeMapper DalBadgeMapper { get; private set; }

		protected IDALCommentMapper DalCommentMapper { get; private set; }

		protected IDALPostMapper DalPostMapper { get; private set; }

		protected IDALVoteMapper DalVoteMapper { get; private set; }

		protected IDALPostHistoryMapper DalPostHistoryMapper { get; private set; }

		private ILogger logger;

		public UserService(
			ILogger<IUserService> logger,
			MediatR.IMediator mediator,
			IUserRepository userRepository,
			IApiUserServerRequestModelValidator userModelValidator,
			IDALUserMapper dalUserMapper,
			IDALBadgeMapper dalBadgeMapper,
			IDALCommentMapper dalCommentMapper,
			IDALPostMapper dalPostMapper,
			IDALVoteMapper dalVoteMapper,
			IDALPostHistoryMapper dalPostHistoryMapper)
			: base()
		{
			this.UserRepository = userRepository;
			this.UserModelValidator = userModelValidator;
			this.DalUserMapper = dalUserMapper;
			this.DalBadgeMapper = dalBadgeMapper;
			this.DalCommentMapper = dalCommentMapper;
			this.DalPostMapper = dalPostMapper;
			this.DalVoteMapper = dalVoteMapper;
			this.DalPostHistoryMapper = dalPostHistoryMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiUserServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<User> records = await this.UserRepository.All(limit, offset, query);

			return this.DalUserMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiUserServerResponseModel> Get(int id)
		{
			User record = await this.UserRepository.Get(id);

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
			int id,
			ApiUserServerRequestModel model)
		{
			var validationResult = await this.UserModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				User record = this.DalUserMapper.MapModelToEntity(id, model);
				await this.UserRepository.Update(record);

				record = await this.UserRepository.Get(id);

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
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.UserModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.UserRepository.Delete(id);

				await this.mediator.Publish(new UserDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiBadgeServerResponseModel>> BadgesByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			List<Badge> records = await this.UserRepository.BadgesByUserId(userId, limit, offset);

			return this.DalBadgeMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiCommentServerResponseModel>> CommentsByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			List<Comment> records = await this.UserRepository.CommentsByUserId(userId, limit, offset);

			return this.DalCommentMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostServerResponseModel>> PostsByLastEditorUserId(int lastEditorUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Post> records = await this.UserRepository.PostsByLastEditorUserId(lastEditorUserId, limit, offset);

			return this.DalPostMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostServerResponseModel>> PostsByOwnerUserId(int ownerUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Post> records = await this.UserRepository.PostsByOwnerUserId(ownerUserId, limit, offset);

			return this.DalPostMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiVoteServerResponseModel>> VotesByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			List<Vote> records = await this.UserRepository.VotesByUserId(userId, limit, offset);

			return this.DalVoteMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostHistoryServerResponseModel>> PostHistoriesByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			List<PostHistory> records = await this.UserRepository.PostHistoriesByUserId(userId, limit, offset);

			return this.DalPostHistoryMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>afe7a1028064c8111c5d7e9d27a07763</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/