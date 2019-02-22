using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractMessageService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IMessageRepository MessageRepository { get; private set; }

		protected IApiMessageServerRequestModelValidator MessageModelValidator { get; private set; }

		protected IDALMessageMapper DalMessageMapper { get; private set; }

		protected IDALMessengerMapper DalMessengerMapper { get; private set; }

		private ILogger logger;

		public AbstractMessageService(
			ILogger logger,
			MediatR.IMediator mediator,
			IMessageRepository messageRepository,
			IApiMessageServerRequestModelValidator messageModelValidator,
			IDALMessageMapper dalMessageMapper,
			IDALMessengerMapper dalMessengerMapper)
			: base()
		{
			this.MessageRepository = messageRepository;
			this.MessageModelValidator = messageModelValidator;
			this.DalMessageMapper = dalMessageMapper;
			this.DalMessengerMapper = dalMessengerMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiMessageServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Message> records = await this.MessageRepository.All(limit, offset, query);

			return this.DalMessageMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiMessageServerResponseModel> Get(int messageId)
		{
			Message record = await this.MessageRepository.Get(messageId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalMessageMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiMessageServerResponseModel>> Create(
			ApiMessageServerRequestModel model)
		{
			CreateResponse<ApiMessageServerResponseModel> response = ValidationResponseFactory<ApiMessageServerResponseModel>.CreateResponse(await this.MessageModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Message record = this.DalMessageMapper.MapModelToEntity(default(int), model);
				record = await this.MessageRepository.Create(record);

				response.SetRecord(this.DalMessageMapper.MapEntityToModel(record));
				await this.mediator.Publish(new MessageCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiMessageServerResponseModel>> Update(
			int messageId,
			ApiMessageServerRequestModel model)
		{
			var validationResult = await this.MessageModelValidator.ValidateUpdateAsync(messageId, model);

			if (validationResult.IsValid)
			{
				Message record = this.DalMessageMapper.MapModelToEntity(messageId, model);
				await this.MessageRepository.Update(record);

				record = await this.MessageRepository.Get(messageId);

				ApiMessageServerResponseModel apiModel = this.DalMessageMapper.MapEntityToModel(record);
				await this.mediator.Publish(new MessageUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiMessageServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiMessageServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int messageId)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.MessageModelValidator.ValidateDeleteAsync(messageId));

			if (response.Success)
			{
				await this.MessageRepository.Delete(messageId);

				await this.mediator.Publish(new MessageDeletedNotification(messageId));
			}

			return response;
		}

		public async virtual Task<List<ApiMessageServerResponseModel>> BySenderUserId(int? senderUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Message> records = await this.MessageRepository.BySenderUserId(senderUserId, limit, offset);

			return this.DalMessageMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiMessengerServerResponseModel>> MessengersByMessageId(int messageId, int limit = int.MaxValue, int offset = 0)
		{
			List<Messenger> records = await this.MessageRepository.MessengersByMessageId(messageId, limit, offset);

			return this.DalMessengerMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>5e3545d3e27b20f3f7f13d17a999c585</Hash>
</Codenesium>*/