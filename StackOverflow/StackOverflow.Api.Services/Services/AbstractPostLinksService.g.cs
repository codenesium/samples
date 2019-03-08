using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractPostLinksService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IPostLinksRepository PostLinksRepository { get; private set; }

		protected IApiPostLinksServerRequestModelValidator PostLinksModelValidator { get; private set; }

		protected IDALPostLinksMapper DalPostLinksMapper { get; private set; }

		private ILogger logger;

		public AbstractPostLinksService(
			ILogger logger,
			MediatR.IMediator mediator,
			IPostLinksRepository postLinksRepository,
			IApiPostLinksServerRequestModelValidator postLinksModelValidator,
			IDALPostLinksMapper dalPostLinksMapper)
			: base()
		{
			this.PostLinksRepository = postLinksRepository;
			this.PostLinksModelValidator = postLinksModelValidator;
			this.DalPostLinksMapper = dalPostLinksMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPostLinksServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<PostLinks> records = await this.PostLinksRepository.All(limit, offset, query);

			return this.DalPostLinksMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPostLinksServerResponseModel> Get(int id)
		{
			PostLinks record = await this.PostLinksRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPostLinksMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPostLinksServerResponseModel>> Create(
			ApiPostLinksServerRequestModel model)
		{
			CreateResponse<ApiPostLinksServerResponseModel> response = ValidationResponseFactory<ApiPostLinksServerResponseModel>.CreateResponse(await this.PostLinksModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				PostLinks record = this.DalPostLinksMapper.MapModelToEntity(default(int), model);
				record = await this.PostLinksRepository.Create(record);

				response.SetRecord(this.DalPostLinksMapper.MapEntityToModel(record));
				await this.mediator.Publish(new PostLinksCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostLinksServerResponseModel>> Update(
			int id,
			ApiPostLinksServerRequestModel model)
		{
			var validationResult = await this.PostLinksModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				PostLinks record = this.DalPostLinksMapper.MapModelToEntity(id, model);
				await this.PostLinksRepository.Update(record);

				record = await this.PostLinksRepository.Get(id);

				ApiPostLinksServerResponseModel apiModel = this.DalPostLinksMapper.MapEntityToModel(record);
				await this.mediator.Publish(new PostLinksUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPostLinksServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPostLinksServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PostLinksModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PostLinksRepository.Delete(id);

				await this.mediator.Publish(new PostLinksDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiPostLinksServerResponseModel>> ByLinkTypeId(int linkTypeId, int limit = 0, int offset = int.MaxValue)
		{
			List<PostLinks> records = await this.PostLinksRepository.ByLinkTypeId(linkTypeId, limit, offset);

			return this.DalPostLinksMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostLinksServerResponseModel>> ByPostId(int postId, int limit = 0, int offset = int.MaxValue)
		{
			List<PostLinks> records = await this.PostLinksRepository.ByPostId(postId, limit, offset);

			return this.DalPostLinksMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostLinksServerResponseModel>> ByRelatedPostId(int relatedPostId, int limit = 0, int offset = int.MaxValue)
		{
			List<PostLinks> records = await this.PostLinksRepository.ByRelatedPostId(relatedPostId, limit, offset);

			return this.DalPostLinksMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>281508da54f2d58c2e00dfbeefd2c867</Hash>
</Codenesium>*/