using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractPostLinkService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IPostLinkRepository PostLinkRepository { get; private set; }

		protected IApiPostLinkServerRequestModelValidator PostLinkModelValidator { get; private set; }

		protected IDALPostLinkMapper DalPostLinkMapper { get; private set; }

		private ILogger logger;

		public AbstractPostLinkService(
			ILogger logger,
			MediatR.IMediator mediator,
			IPostLinkRepository postLinkRepository,
			IApiPostLinkServerRequestModelValidator postLinkModelValidator,
			IDALPostLinkMapper dalPostLinkMapper)
			: base()
		{
			this.PostLinkRepository = postLinkRepository;
			this.PostLinkModelValidator = postLinkModelValidator;
			this.DalPostLinkMapper = dalPostLinkMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPostLinkServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<PostLink> records = await this.PostLinkRepository.All(limit, offset, query);

			return this.DalPostLinkMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPostLinkServerResponseModel> Get(int id)
		{
			PostLink record = await this.PostLinkRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPostLinkMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPostLinkServerResponseModel>> Create(
			ApiPostLinkServerRequestModel model)
		{
			CreateResponse<ApiPostLinkServerResponseModel> response = ValidationResponseFactory<ApiPostLinkServerResponseModel>.CreateResponse(await this.PostLinkModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				PostLink record = this.DalPostLinkMapper.MapModelToEntity(default(int), model);
				record = await this.PostLinkRepository.Create(record);

				response.SetRecord(this.DalPostLinkMapper.MapEntityToModel(record));
				await this.mediator.Publish(new PostLinkCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostLinkServerResponseModel>> Update(
			int id,
			ApiPostLinkServerRequestModel model)
		{
			var validationResult = await this.PostLinkModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				PostLink record = this.DalPostLinkMapper.MapModelToEntity(id, model);
				await this.PostLinkRepository.Update(record);

				record = await this.PostLinkRepository.Get(id);

				ApiPostLinkServerResponseModel apiModel = this.DalPostLinkMapper.MapEntityToModel(record);
				await this.mediator.Publish(new PostLinkUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPostLinkServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPostLinkServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PostLinkModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PostLinkRepository.Delete(id);

				await this.mediator.Publish(new PostLinkDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiPostLinkServerResponseModel>> ByLinkTypeId(int linkTypeId, int limit = 0, int offset = int.MaxValue)
		{
			List<PostLink> records = await this.PostLinkRepository.ByLinkTypeId(linkTypeId, limit, offset);

			return this.DalPostLinkMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostLinkServerResponseModel>> ByPostId(int postId, int limit = 0, int offset = int.MaxValue)
		{
			List<PostLink> records = await this.PostLinkRepository.ByPostId(postId, limit, offset);

			return this.DalPostLinkMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostLinkServerResponseModel>> ByRelatedPostId(int relatedPostId, int limit = 0, int offset = int.MaxValue)
		{
			List<PostLink> records = await this.PostLinkRepository.ByRelatedPostId(relatedPostId, limit, offset);

			return this.DalPostLinkMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>d2ea887dee3750db5fb78e8b966f50c4</Hash>
</Codenesium>*/