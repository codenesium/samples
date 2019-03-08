using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractTagsService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected ITagsRepository TagsRepository { get; private set; }

		protected IApiTagsServerRequestModelValidator TagsModelValidator { get; private set; }

		protected IDALTagsMapper DalTagsMapper { get; private set; }

		private ILogger logger;

		public AbstractTagsService(
			ILogger logger,
			MediatR.IMediator mediator,
			ITagsRepository tagsRepository,
			IApiTagsServerRequestModelValidator tagsModelValidator,
			IDALTagsMapper dalTagsMapper)
			: base()
		{
			this.TagsRepository = tagsRepository;
			this.TagsModelValidator = tagsModelValidator;
			this.DalTagsMapper = dalTagsMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTagsServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Tags> records = await this.TagsRepository.All(limit, offset, query);

			return this.DalTagsMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiTagsServerResponseModel> Get(int id)
		{
			Tags record = await this.TagsRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalTagsMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiTagsServerResponseModel>> Create(
			ApiTagsServerRequestModel model)
		{
			CreateResponse<ApiTagsServerResponseModel> response = ValidationResponseFactory<ApiTagsServerResponseModel>.CreateResponse(await this.TagsModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Tags record = this.DalTagsMapper.MapModelToEntity(default(int), model);
				record = await this.TagsRepository.Create(record);

				response.SetRecord(this.DalTagsMapper.MapEntityToModel(record));
				await this.mediator.Publish(new TagsCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTagsServerResponseModel>> Update(
			int id,
			ApiTagsServerRequestModel model)
		{
			var validationResult = await this.TagsModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Tags record = this.DalTagsMapper.MapModelToEntity(id, model);
				await this.TagsRepository.Update(record);

				record = await this.TagsRepository.Get(id);

				ApiTagsServerResponseModel apiModel = this.DalTagsMapper.MapEntityToModel(record);
				await this.mediator.Publish(new TagsUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiTagsServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiTagsServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TagsModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.TagsRepository.Delete(id);

				await this.mediator.Publish(new TagsDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiTagsServerResponseModel>> ByExcerptPostId(int excerptPostId, int limit = 0, int offset = int.MaxValue)
		{
			List<Tags> records = await this.TagsRepository.ByExcerptPostId(excerptPostId, limit, offset);

			return this.DalTagsMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiTagsServerResponseModel>> ByWikiPostId(int wikiPostId, int limit = 0, int offset = int.MaxValue)
		{
			List<Tags> records = await this.TagsRepository.ByWikiPostId(wikiPostId, limit, offset);

			return this.DalTagsMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>55e00be30c54966af4608088131f08ad</Hash>
</Codenesium>*/