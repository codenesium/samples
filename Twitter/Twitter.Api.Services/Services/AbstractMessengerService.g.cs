using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractMessengerService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IMessengerRepository MessengerRepository { get; private set; }

		protected IApiMessengerServerRequestModelValidator MessengerModelValidator { get; private set; }

		protected IDALMessengerMapper DalMessengerMapper { get; private set; }

		private ILogger logger;

		public AbstractMessengerService(
			ILogger logger,
			MediatR.IMediator mediator,
			IMessengerRepository messengerRepository,
			IApiMessengerServerRequestModelValidator messengerModelValidator,
			IDALMessengerMapper dalMessengerMapper)
			: base()
		{
			this.MessengerRepository = messengerRepository;
			this.MessengerModelValidator = messengerModelValidator;
			this.DalMessengerMapper = dalMessengerMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiMessengerServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Messenger> records = await this.MessengerRepository.All(limit, offset, query);

			return this.DalMessengerMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiMessengerServerResponseModel> Get(int id)
		{
			Messenger record = await this.MessengerRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalMessengerMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiMessengerServerResponseModel>> Create(
			ApiMessengerServerRequestModel model)
		{
			CreateResponse<ApiMessengerServerResponseModel> response = ValidationResponseFactory<ApiMessengerServerResponseModel>.CreateResponse(await this.MessengerModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Messenger record = this.DalMessengerMapper.MapModelToEntity(default(int), model);
				record = await this.MessengerRepository.Create(record);

				response.SetRecord(this.DalMessengerMapper.MapEntityToModel(record));
				await this.mediator.Publish(new MessengerCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiMessengerServerResponseModel>> Update(
			int id,
			ApiMessengerServerRequestModel model)
		{
			var validationResult = await this.MessengerModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Messenger record = this.DalMessengerMapper.MapModelToEntity(id, model);
				await this.MessengerRepository.Update(record);

				record = await this.MessengerRepository.Get(id);

				ApiMessengerServerResponseModel apiModel = this.DalMessengerMapper.MapEntityToModel(record);
				await this.mediator.Publish(new MessengerUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiMessengerServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiMessengerServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.MessengerModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.MessengerRepository.Delete(id);

				await this.mediator.Publish(new MessengerDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiMessengerServerResponseModel>> ByMessageId(int? messageId, int limit = 0, int offset = int.MaxValue)
		{
			List<Messenger> records = await this.MessengerRepository.ByMessageId(messageId, limit, offset);

			return this.DalMessengerMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiMessengerServerResponseModel>> ByToUserId(int toUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Messenger> records = await this.MessengerRepository.ByToUserId(toUserId, limit, offset);

			return this.DalMessengerMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiMessengerServerResponseModel>> ByUserId(int? userId, int limit = 0, int offset = int.MaxValue)
		{
			List<Messenger> records = await this.MessengerRepository.ByUserId(userId, limit, offset);

			return this.DalMessengerMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>1af2931c92d41643ec24b86b9e5f23e6</Hash>
</Codenesium>*/