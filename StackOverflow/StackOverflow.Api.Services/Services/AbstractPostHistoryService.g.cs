using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractPostHistoryService : AbstractService
	{
		private IMediator mediator;

		protected IPostHistoryRepository PostHistoryRepository { get; private set; }

		protected IApiPostHistoryServerRequestModelValidator PostHistoryModelValidator { get; private set; }

		protected IDALPostHistoryMapper DalPostHistoryMapper { get; private set; }

		private ILogger logger;

		public AbstractPostHistoryService(
			ILogger logger,
			IMediator mediator,
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
	}
}

/*<Codenesium>
    <Hash>c3229da7c7020563b22967aa50d521af</Hash>
</Codenesium>*/