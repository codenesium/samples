using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class PostService : AbstractService, IPostService
	{
		private MediatR.IMediator mediator;

		protected IPostRepository PostRepository { get; private set; }

		protected IApiPostServerRequestModelValidator PostModelValidator { get; private set; }

		protected IDALPostMapper DalPostMapper { get; private set; }

		protected IDALCommentMapper DalCommentMapper { get; private set; }

		protected IDALTagMapper DalTagMapper { get; private set; }

		protected IDALVoteMapper DalVoteMapper { get; private set; }

		protected IDALPostHistoryMapper DalPostHistoryMapper { get; private set; }

		protected IDALPostLinkMapper DalPostLinkMapper { get; private set; }

		private ILogger logger;

		public PostService(
			ILogger<IPostService> logger,
			MediatR.IMediator mediator,
			IPostRepository postRepository,
			IApiPostServerRequestModelValidator postModelValidator,
			IDALPostMapper dalPostMapper,
			IDALCommentMapper dalCommentMapper,
			IDALTagMapper dalTagMapper,
			IDALVoteMapper dalVoteMapper,
			IDALPostHistoryMapper dalPostHistoryMapper,
			IDALPostLinkMapper dalPostLinkMapper)
			: base()
		{
			this.PostRepository = postRepository;
			this.PostModelValidator = postModelValidator;
			this.DalPostMapper = dalPostMapper;
			this.DalCommentMapper = dalCommentMapper;
			this.DalTagMapper = dalTagMapper;
			this.DalVoteMapper = dalVoteMapper;
			this.DalPostHistoryMapper = dalPostHistoryMapper;
			this.DalPostLinkMapper = dalPostLinkMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPostServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Post> records = await this.PostRepository.All(limit, offset, query);

			return this.DalPostMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPostServerResponseModel> Get(int id)
		{
			Post record = await this.PostRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPostMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPostServerResponseModel>> Create(
			ApiPostServerRequestModel model)
		{
			CreateResponse<ApiPostServerResponseModel> response = ValidationResponseFactory<ApiPostServerResponseModel>.CreateResponse(await this.PostModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Post record = this.DalPostMapper.MapModelToEntity(default(int), model);
				record = await this.PostRepository.Create(record);

				response.SetRecord(this.DalPostMapper.MapEntityToModel(record));
				await this.mediator.Publish(new PostCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostServerResponseModel>> Update(
			int id,
			ApiPostServerRequestModel model)
		{
			var validationResult = await this.PostModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Post record = this.DalPostMapper.MapModelToEntity(id, model);
				await this.PostRepository.Update(record);

				record = await this.PostRepository.Get(id);

				ApiPostServerResponseModel apiModel = this.DalPostMapper.MapEntityToModel(record);
				await this.mediator.Publish(new PostUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPostServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPostServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PostModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PostRepository.Delete(id);

				await this.mediator.Publish(new PostDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiPostServerResponseModel>> ByOwnerUserId(int? ownerUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Post> records = await this.PostRepository.ByOwnerUserId(ownerUserId, limit, offset);

			return this.DalPostMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostServerResponseModel>> ByLastEditorUserId(int? lastEditorUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Post> records = await this.PostRepository.ByLastEditorUserId(lastEditorUserId, limit, offset);

			return this.DalPostMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostServerResponseModel>> ByPostTypeId(int postTypeId, int limit = 0, int offset = int.MaxValue)
		{
			List<Post> records = await this.PostRepository.ByPostTypeId(postTypeId, limit, offset);

			return this.DalPostMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostServerResponseModel>> ByParentId(int? parentId, int limit = 0, int offset = int.MaxValue)
		{
			List<Post> records = await this.PostRepository.ByParentId(parentId, limit, offset);

			return this.DalPostMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiCommentServerResponseModel>> CommentsByPostId(int postId, int limit = int.MaxValue, int offset = 0)
		{
			List<Comment> records = await this.PostRepository.CommentsByPostId(postId, limit, offset);

			return this.DalCommentMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostServerResponseModel>> PostsByParentId(int parentId, int limit = int.MaxValue, int offset = 0)
		{
			List<Post> records = await this.PostRepository.PostsByParentId(parentId, limit, offset);

			return this.DalPostMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiTagServerResponseModel>> TagsByExcerptPostId(int excerptPostId, int limit = int.MaxValue, int offset = 0)
		{
			List<Tag> records = await this.PostRepository.TagsByExcerptPostId(excerptPostId, limit, offset);

			return this.DalTagMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiTagServerResponseModel>> TagsByWikiPostId(int wikiPostId, int limit = int.MaxValue, int offset = 0)
		{
			List<Tag> records = await this.PostRepository.TagsByWikiPostId(wikiPostId, limit, offset);

			return this.DalTagMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiVoteServerResponseModel>> VotesByPostId(int postId, int limit = int.MaxValue, int offset = 0)
		{
			List<Vote> records = await this.PostRepository.VotesByPostId(postId, limit, offset);

			return this.DalVoteMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostHistoryServerResponseModel>> PostHistoriesByPostId(int postId, int limit = int.MaxValue, int offset = 0)
		{
			List<PostHistory> records = await this.PostRepository.PostHistoriesByPostId(postId, limit, offset);

			return this.DalPostHistoryMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostLinkServerResponseModel>> PostLinksByPostId(int postId, int limit = int.MaxValue, int offset = 0)
		{
			List<PostLink> records = await this.PostRepository.PostLinksByPostId(postId, limit, offset);

			return this.DalPostLinkMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostLinkServerResponseModel>> PostLinksByRelatedPostId(int relatedPostId, int limit = int.MaxValue, int offset = 0)
		{
			List<PostLink> records = await this.PostRepository.PostLinksByRelatedPostId(relatedPostId, limit, offset);

			return this.DalPostLinkMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>1939da7169ecf7ce37cca235bd6dff0b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/