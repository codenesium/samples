using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class PostHistoryService : AbstractService, IPostHistoryService
	{
		private MediatR.IMediator mediator;

		protected IPostHistoryRepository PostHistoryRepository { get; private set; }

		protected IApiPostHistoryServerRequestModelValidator PostHistoryModelValidator { get; private set; }

		protected IDALPostHistoryMapper DalPostHistoryMapper { get; private set; }

		private ILogger logger;

		public PostHistoryService(
			ILogger<IPostHistoryService> logger,
			MediatR.IMediator mediator,
			IPostHistoryRepository postHistoryRepository,
			IApiPostHistoryServerRequestModelValidator postHistoryModelValidator,
			IDALPostHistoryMapper dalPostHistoryMapper)
			: base()
		{
			this.PostHistoryRepository = postHistoryRepository;
			this.PostHistoryModelValidator = postHistoryModelValidator;
			this.DalPostHistoryMapper = dalPostHistoryMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPostHistoryServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<PostHistory> records = await this.PostHistoryRepository.All(limit, offset, query);

			return this.DalPostHistoryMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiPostHistoryServerResponseModel> Get(int id)
		{
			PostHistory record = await this.PostHistoryRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalPostHistoryMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiPostHistoryServerResponseModel>> Create(
			ApiPostHistoryServerRequestModel model)
		{
			CreateResponse<ApiPostHistoryServerResponseModel> response = ValidationResponseFactory<ApiPostHistoryServerResponseModel>.CreateResponse(await this.PostHistoryModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				PostHistory record = this.DalPostHistoryMapper.MapModelToEntity(default(int), model);
				record = await this.PostHistoryRepository.Create(record);

				response.SetRecord(this.DalPostHistoryMapper.MapEntityToModel(record));
				await this.mediator.Publish(new PostHistoryCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPostHistoryServerResponseModel>> Update(
			int id,
			ApiPostHistoryServerRequestModel model)
		{
			var validationResult = await this.PostHistoryModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				PostHistory record = this.DalPostHistoryMapper.MapModelToEntity(id, model);
				await this.PostHistoryRepository.Update(record);

				record = await this.PostHistoryRepository.Get(id);

				ApiPostHistoryServerResponseModel apiModel = this.DalPostHistoryMapper.MapEntityToModel(record);
				await this.mediator.Publish(new PostHistoryUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiPostHistoryServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiPostHistoryServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PostHistoryModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PostHistoryRepository.Delete(id);

				await this.mediator.Publish(new PostHistoryDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiPostHistoryServerResponseModel>> ByPostHistoryTypeId(int postHistoryTypeId, int limit = 0, int offset = int.MaxValue)
		{
			List<PostHistory> records = await this.PostHistoryRepository.ByPostHistoryTypeId(postHistoryTypeId, limit, offset);

			return this.DalPostHistoryMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostHistoryServerResponseModel>> ByPostId(int postId, int limit = 0, int offset = int.MaxValue)
		{
			List<PostHistory> records = await this.PostHistoryRepository.ByPostId(postId, limit, offset);

			return this.DalPostHistoryMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiPostHistoryServerResponseModel>> ByUserId(int? userId, int limit = 0, int offset = int.MaxValue)
		{
			List<PostHistory> records = await this.PostHistoryRepository.ByUserId(userId, limit, offset);

			return this.DalPostHistoryMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>fb1000068e47e73b4bf6ae4cf8017a88</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/