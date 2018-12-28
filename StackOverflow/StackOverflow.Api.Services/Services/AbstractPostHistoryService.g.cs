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

		protected IBOLPostHistoryMapper BolPostHistoryMapper { get; private set; }

		protected IDALPostHistoryMapper DalPostHistoryMapper { get; private set; }

		private ILogger logger;

		public AbstractPostHistoryService(
			ILogger logger,
			IMediator mediator,
			IPostHistoryRepository postHistoryRepository,
			IApiPostHistoryServerRequestModelValidator postHistoryModelValidator,
			IBOLPostHistoryMapper bolPostHistoryMapper,
			IDALPostHistoryMapper dalPostHistoryMapper)
			: base()
		{
			this.PostHistoryRepository = postHistoryRepository;
			this.PostHistoryModelValidator = postHistoryModelValidator;
			this.BolPostHistoryMapper = bolPostHistoryMapper;
			this.DalPostHistoryMapper = dalPostHistoryMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiPostHistoryServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PostHistoryRepository.All(limit, offset);

			return this.BolPostHistoryMapper.MapBOToModel(this.DalPostHistoryMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPostHistoryServerResponseModel> Get(int id)
		{
			var record = await this.PostHistoryRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPostHistoryMapper.MapBOToModel(this.DalPostHistoryMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPostHistoryServerResponseModel>> Create(
			ApiPostHistoryServerRequestModel model)
		{
			CreateResponse<ApiPostHistoryServerResponseModel> response = ValidationResponseFactory<ApiPostHistoryServerResponseModel>.CreateResponse(await this.PostHistoryModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPostHistoryMapper.MapModelToBO(default(int), model);
				var record = await this.PostHistoryRepository.Create(this.DalPostHistoryMapper.MapBOToEF(bo));

				var businessObject = this.DalPostHistoryMapper.MapEFToBO(record);
				response.SetRecord(this.BolPostHistoryMapper.MapBOToModel(businessObject));
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
				var bo = this.BolPostHistoryMapper.MapModelToBO(id, model);
				await this.PostHistoryRepository.Update(this.DalPostHistoryMapper.MapBOToEF(bo));

				var record = await this.PostHistoryRepository.Get(id);

				var businessObject = this.DalPostHistoryMapper.MapEFToBO(record);
				var apiModel = this.BolPostHistoryMapper.MapBOToModel(businessObject);
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
    <Hash>afa745aef2b73b3bf1a925022895e4b5</Hash>
</Codenesium>*/