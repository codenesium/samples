using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractPostsService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IPostsRepository PostsRepository { get; private set; }

		protected IApiPostsServerRequestModelValidator PostsModelValidator { get; private set; }

		protected IDALPostsMapper DalPostsMapper { get; private set; }

		protected IDALCommentsMapper DalCommentsMapper { get; private set; }

		protected IDALTagsMapper DalTagsMapper { get; private set; }

		protected IDALVotesMapper DalVotesMapper { get; private set; }

		protected IDALPostHistoryMapper DalPostHistoryMapper { get; private set; }

		protected IDALPostLinksMapper DalPostLinksMapper { get; private set; }

		private ILogger logger;

		public AbstractPostsService(
			ILogger logger,
			MediatR.IMediator mediator,
			IPostsRepository postsRepository,
			IApiPostsServerRequestModelValidator postsModelValidator,
			IDALPostsMapper dalPostsMapper,
			IDALCommentsMapper dalCommentsMapper,
			IDALTagsMapper dalTagsMapper,
			IDALVotesMapper dalVotesMapper,
			IDALPostHistoryMapper dalPostHistoryMapper,
			IDALPostLinksMapper dalPostLinksMapper)
			: base()
		{
			this.PostsRepository = postsRepository;
			this.PostsModelValidator = postsModelValidator;
			this.DalPostsMapper = dalPostsMapper;
			this.DalCommentsMapper = dalCommentsMapper;
			this.DalTagsMapper = dalTagsMapper;
			this.DalVotesMapper = dalVotesMapper;
			this.DalPostHistoryMapper = dalPostHistoryMapper;
			this.DalPostLinksMapper = dalPostLinksMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPostsServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Posts> records = await this.PostsRepository.All(limit, offset, query);

			return this.DalPostsMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPostsServerResponseModel> Get(int id)
		{
			Posts record = await this.PostsRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPostsMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPostsServerResponseModel>> Create(
			ApiPostsServerRequestModel model)
		{
			CreateResponse<ApiPostsServerResponseModel> response = ValidationResponseFactory<ApiPostsServerResponseModel>.CreateResponse(await this.PostsModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Posts record = this.DalPostsMapper.MapModelToEntity(default(int), model);
				record = await this.PostsRepository.Create(record);

				response.SetRecord(this.DalPostsMapper.MapEntityToModel(record));
				await this.mediator.Publish(new PostsCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostsServerResponseModel>> Update(
			int id,
			ApiPostsServerRequestModel model)
		{
			var validationResult = await this.PostsModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Posts record = this.DalPostsMapper.MapModelToEntity(id, model);
				await this.PostsRepository.Update(record);

				record = await this.PostsRepository.Get(id);

				ApiPostsServerResponseModel apiModel = this.DalPostsMapper.MapEntityToModel(record);
				await this.mediator.Publish(new PostsUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPostsServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPostsServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PostsModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PostsRepository.Delete(id);

				await this.mediator.Publish(new PostsDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiPostsServerResponseModel>> ByOwnerUserId(int? ownerUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Posts> records = await this.PostsRepository.ByOwnerUserId(ownerUserId, limit, offset);

			return this.DalPostsMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostsServerResponseModel>> ByLastEditorUserId(int? lastEditorUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Posts> records = await this.PostsRepository.ByLastEditorUserId(lastEditorUserId, limit, offset);

			return this.DalPostsMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostsServerResponseModel>> ByPostTypeId(int postTypeId, int limit = 0, int offset = int.MaxValue)
		{
			List<Posts> records = await this.PostsRepository.ByPostTypeId(postTypeId, limit, offset);

			return this.DalPostsMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostsServerResponseModel>> ByParentId(int? parentId, int limit = 0, int offset = int.MaxValue)
		{
			List<Posts> records = await this.PostsRepository.ByParentId(parentId, limit, offset);

			return this.DalPostsMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiCommentsServerResponseModel>> CommentsByPostId(int postId, int limit = int.MaxValue, int offset = 0)
		{
			List<Comments> records = await this.PostsRepository.CommentsByPostId(postId, limit, offset);

			return this.DalCommentsMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostsServerResponseModel>> PostsByParentId(int parentId, int limit = int.MaxValue, int offset = 0)
		{
			List<Posts> records = await this.PostsRepository.PostsByParentId(parentId, limit, offset);

			return this.DalPostsMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiTagsServerResponseModel>> TagsByExcerptPostId(int excerptPostId, int limit = int.MaxValue, int offset = 0)
		{
			List<Tags> records = await this.PostsRepository.TagsByExcerptPostId(excerptPostId, limit, offset);

			return this.DalTagsMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiTagsServerResponseModel>> TagsByWikiPostId(int wikiPostId, int limit = int.MaxValue, int offset = 0)
		{
			List<Tags> records = await this.PostsRepository.TagsByWikiPostId(wikiPostId, limit, offset);

			return this.DalTagsMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiVotesServerResponseModel>> VotesByPostId(int postId, int limit = int.MaxValue, int offset = 0)
		{
			List<Votes> records = await this.PostsRepository.VotesByPostId(postId, limit, offset);

			return this.DalVotesMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostHistoryServerResponseModel>> PostHistoryByPostId(int postId, int limit = int.MaxValue, int offset = 0)
		{
			List<PostHistory> records = await this.PostsRepository.PostHistoryByPostId(postId, limit, offset);

			return this.DalPostHistoryMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostLinksServerResponseModel>> PostLinksByPostId(int postId, int limit = int.MaxValue, int offset = 0)
		{
			List<PostLinks> records = await this.PostsRepository.PostLinksByPostId(postId, limit, offset);

			return this.DalPostLinksMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostLinksServerResponseModel>> PostLinksByRelatedPostId(int relatedPostId, int limit = int.MaxValue, int offset = 0)
		{
			List<PostLinks> records = await this.PostsRepository.PostLinksByRelatedPostId(relatedPostId, limit, offset);

			return this.DalPostLinksMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>65da1e75f017b0e7f819575126fe821c</Hash>
</Codenesium>*/