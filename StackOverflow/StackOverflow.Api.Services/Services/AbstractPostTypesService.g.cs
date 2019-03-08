using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractPostTypesService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IPostTypesRepository PostTypesRepository { get; private set; }

		protected IApiPostTypesServerRequestModelValidator PostTypesModelValidator { get; private set; }

		protected IDALPostTypesMapper DalPostTypesMapper { get; private set; }

		protected IDALPostsMapper DalPostsMapper { get; private set; }

		private ILogger logger;

		public AbstractPostTypesService(
			ILogger logger,
			MediatR.IMediator mediator,
			IPostTypesRepository postTypesRepository,
			IApiPostTypesServerRequestModelValidator postTypesModelValidator,
			IDALPostTypesMapper dalPostTypesMapper,
			IDALPostsMapper dalPostsMapper)
			: base()
		{
			this.PostTypesRepository = postTypesRepository;
			this.PostTypesModelValidator = postTypesModelValidator;
			this.DalPostTypesMapper = dalPostTypesMapper;
			this.DalPostsMapper = dalPostsMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPostTypesServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<PostTypes> records = await this.PostTypesRepository.All(limit, offset, query);

			return this.DalPostTypesMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPostTypesServerResponseModel> Get(int id)
		{
			PostTypes record = await this.PostTypesRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPostTypesMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPostTypesServerResponseModel>> Create(
			ApiPostTypesServerRequestModel model)
		{
			CreateResponse<ApiPostTypesServerResponseModel> response = ValidationResponseFactory<ApiPostTypesServerResponseModel>.CreateResponse(await this.PostTypesModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				PostTypes record = this.DalPostTypesMapper.MapModelToEntity(default(int), model);
				record = await this.PostTypesRepository.Create(record);

				response.SetRecord(this.DalPostTypesMapper.MapEntityToModel(record));
				await this.mediator.Publish(new PostTypesCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostTypesServerResponseModel>> Update(
			int id,
			ApiPostTypesServerRequestModel model)
		{
			var validationResult = await this.PostTypesModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				PostTypes record = this.DalPostTypesMapper.MapModelToEntity(id, model);
				await this.PostTypesRepository.Update(record);

				record = await this.PostTypesRepository.Get(id);

				ApiPostTypesServerResponseModel apiModel = this.DalPostTypesMapper.MapEntityToModel(record);
				await this.mediator.Publish(new PostTypesUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPostTypesServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPostTypesServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PostTypesModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PostTypesRepository.Delete(id);

				await this.mediator.Publish(new PostTypesDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiPostsServerResponseModel>> PostsByPostTypeId(int postTypeId, int limit = int.MaxValue, int offset = 0)
		{
			List<Posts> records = await this.PostTypesRepository.PostsByPostTypeId(postTypeId, limit, offset);

			return this.DalPostsMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>72309f0ba4cebc7cd08e5cdd2608be62</Hash>
</Codenesium>*/