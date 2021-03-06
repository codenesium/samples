using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class TagService : AbstractService, ITagService
	{
		private MediatR.IMediator mediator;

		protected ITagRepository TagRepository { get; private set; }

		protected IApiTagServerRequestModelValidator TagModelValidator { get; private set; }

		protected IDALTagMapper DalTagMapper { get; private set; }

		private ILogger logger;

		public TagService(
			ILogger<ITagService> logger,
			MediatR.IMediator mediator,
			ITagRepository tagRepository,
			IApiTagServerRequestModelValidator tagModelValidator,
			IDALTagMapper dalTagMapper)
			: base()
		{
			this.TagRepository = tagRepository;
			this.TagModelValidator = tagModelValidator;
			this.DalTagMapper = dalTagMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTagServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Tag> records = await this.TagRepository.All(limit, offset, query);

			return this.DalTagMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiTagServerResponseModel> Get(int id)
		{
			Tag record = await this.TagRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalTagMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiTagServerResponseModel>> Create(
			ApiTagServerRequestModel model)
		{
			CreateResponse<ApiTagServerResponseModel> response = ValidationResponseFactory<ApiTagServerResponseModel>.CreateResponse(await this.TagModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Tag record = this.DalTagMapper.MapModelToEntity(default(int), model);
				record = await this.TagRepository.Create(record);

				response.SetRecord(this.DalTagMapper.MapEntityToModel(record));
				await this.mediator.Publish(new TagCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTagServerResponseModel>> Update(
			int id,
			ApiTagServerRequestModel model)
		{
			var validationResult = await this.TagModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Tag record = this.DalTagMapper.MapModelToEntity(id, model);
				await this.TagRepository.Update(record);

				record = await this.TagRepository.Get(id);

				ApiTagServerResponseModel apiModel = this.DalTagMapper.MapEntityToModel(record);
				await this.mediator.Publish(new TagUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiTagServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiTagServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TagModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.TagRepository.Delete(id);

				await this.mediator.Publish(new TagDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiTagServerResponseModel>> ByExcerptPostId(int excerptPostId, int limit = 0, int offset = int.MaxValue)
		{
			List<Tag> records = await this.TagRepository.ByExcerptPostId(excerptPostId, limit, offset);

			return this.DalTagMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiTagServerResponseModel>> ByWikiPostId(int wikiPostId, int limit = 0, int offset = int.MaxValue)
		{
			List<Tag> records = await this.TagRepository.ByWikiPostId(wikiPostId, limit, offset);

			return this.DalTagMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>a0e939e3a482e7ec760074ba42e5117d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/