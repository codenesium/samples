using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractPostService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IPostRepository PostRepository { get; private set; }

		protected IApiPostServerRequestModelValidator PostModelValidator { get; private set; }

		protected IDALPostMapper DalPostMapper { get; private set; }

		private ILogger logger;

		public AbstractPostService(
			ILogger logger,
			MediatR.IMediator mediator,
			IPostRepository postRepository,
			IApiPostServerRequestModelValidator postModelValidator,
			IDALPostMapper dalPostMapper)
			: base()
		{
			this.PostRepository = postRepository;
			this.PostModelValidator = postModelValidator;
			this.DalPostMapper = dalPostMapper;
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
	}
}

/*<Codenesium>
    <Hash>8ad0774c2fcae7988c8b612b2b49086a</Hash>
</Codenesium>*/