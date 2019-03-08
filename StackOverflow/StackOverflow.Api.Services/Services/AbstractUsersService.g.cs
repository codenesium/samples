using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractUsersService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IUsersRepository UsersRepository { get; private set; }

		protected IApiUsersServerRequestModelValidator UsersModelValidator { get; private set; }

		protected IDALUsersMapper DalUsersMapper { get; private set; }

		protected IDALBadgesMapper DalBadgesMapper { get; private set; }

		protected IDALCommentsMapper DalCommentsMapper { get; private set; }

		protected IDALPostsMapper DalPostsMapper { get; private set; }

		protected IDALVotesMapper DalVotesMapper { get; private set; }

		protected IDALPostHistoryMapper DalPostHistoryMapper { get; private set; }

		private ILogger logger;

		public AbstractUsersService(
			ILogger logger,
			MediatR.IMediator mediator,
			IUsersRepository usersRepository,
			IApiUsersServerRequestModelValidator usersModelValidator,
			IDALUsersMapper dalUsersMapper,
			IDALBadgesMapper dalBadgesMapper,
			IDALCommentsMapper dalCommentsMapper,
			IDALPostsMapper dalPostsMapper,
			IDALVotesMapper dalVotesMapper,
			IDALPostHistoryMapper dalPostHistoryMapper)
			: base()
		{
			this.UsersRepository = usersRepository;
			this.UsersModelValidator = usersModelValidator;
			this.DalUsersMapper = dalUsersMapper;
			this.DalBadgesMapper = dalBadgesMapper;
			this.DalCommentsMapper = dalCommentsMapper;
			this.DalPostsMapper = dalPostsMapper;
			this.DalVotesMapper = dalVotesMapper;
			this.DalPostHistoryMapper = dalPostHistoryMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiUsersServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Users> records = await this.UsersRepository.All(limit, offset, query);

			return this.DalUsersMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiUsersServerResponseModel> Get(int id)
		{
			Users record = await this.UsersRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalUsersMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiUsersServerResponseModel>> Create(
			ApiUsersServerRequestModel model)
		{
			CreateResponse<ApiUsersServerResponseModel> response = ValidationResponseFactory<ApiUsersServerResponseModel>.CreateResponse(await this.UsersModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Users record = this.DalUsersMapper.MapModelToEntity(default(int), model);
				record = await this.UsersRepository.Create(record);

				response.SetRecord(this.DalUsersMapper.MapEntityToModel(record));
				await this.mediator.Publish(new UsersCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiUsersServerResponseModel>> Update(
			int id,
			ApiUsersServerRequestModel model)
		{
			var validationResult = await this.UsersModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Users record = this.DalUsersMapper.MapModelToEntity(id, model);
				await this.UsersRepository.Update(record);

				record = await this.UsersRepository.Get(id);

				ApiUsersServerResponseModel apiModel = this.DalUsersMapper.MapEntityToModel(record);
				await this.mediator.Publish(new UsersUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiUsersServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiUsersServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.UsersModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.UsersRepository.Delete(id);

				await this.mediator.Publish(new UsersDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiBadgesServerResponseModel>> BadgesByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			List<Badges> records = await this.UsersRepository.BadgesByUserId(userId, limit, offset);

			return this.DalBadgesMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiCommentsServerResponseModel>> CommentsByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			List<Comments> records = await this.UsersRepository.CommentsByUserId(userId, limit, offset);

			return this.DalCommentsMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostsServerResponseModel>> PostsByLastEditorUserId(int lastEditorUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Posts> records = await this.UsersRepository.PostsByLastEditorUserId(lastEditorUserId, limit, offset);

			return this.DalPostsMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostsServerResponseModel>> PostsByOwnerUserId(int ownerUserId, int limit = int.MaxValue, int offset = 0)
		{
			List<Posts> records = await this.UsersRepository.PostsByOwnerUserId(ownerUserId, limit, offset);

			return this.DalPostsMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiVotesServerResponseModel>> VotesByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			List<Votes> records = await this.UsersRepository.VotesByUserId(userId, limit, offset);

			return this.DalVotesMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostHistoryServerResponseModel>> PostHistoryByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			List<PostHistory> records = await this.UsersRepository.PostHistoryByUserId(userId, limit, offset);

			return this.DalPostHistoryMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>7c227582207d320e51063a9aae667d0a</Hash>
</Codenesium>*/