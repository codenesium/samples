using MediatR;
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
		private IMediator mediator;

		protected IMessageRepository MessageRepository { get; private set; }

		protected IApiMessageServerRequestModelValidator MessageModelValidator { get; private set; }

		protected IBOLMessageMapper BolMessageMapper { get; private set; }

		protected IDALMessageMapper DalMessageMapper { get; private set; }

		protected IBOLMessengerMapper BolMessengerMapper { get; private set; }

		protected IDALMessengerMapper DalMessengerMapper { get; private set; }

		private ILogger logger;

		public AbstractMessageService(
			ILogger logger,
			IMediator mediator,
			IMessageRepository messageRepository,
			IApiMessageServerRequestModelValidator messageModelValidator,
			IBOLMessageMapper bolMessageMapper,
			IDALMessageMapper dalMessageMapper,
			IBOLMessengerMapper bolMessengerMapper,
			IDALMessengerMapper dalMessengerMapper)
			: base()
		{
			this.MessageRepository = messageRepository;
			this.MessageModelValidator = messageModelValidator;
			this.BolMessageMapper = bolMessageMapper;
			this.DalMessageMapper = dalMessageMapper;
			this.BolMessengerMapper = bolMessengerMapper;
			this.DalMessengerMapper = dalMessengerMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiMessageServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.MessageRepository.All(limit, offset);

			return this.BolMessageMapper.MapBOToModel(this.DalMessageMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiMessageServerResponseModel> Get(int messageId)
		{
			var record = await this.MessageRepository.Get(messageId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolMessageMapper.MapBOToModel(this.DalMessageMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiMessageServerResponseModel>> Create(
			ApiMessageServerRequestModel model)
		{
			CreateResponse<ApiMessageServerResponseModel> response = ValidationResponseFactory<ApiMessageServerResponseModel>.CreateResponse(await this.MessageModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolMessageMapper.MapModelToBO(default(int), model);
				var record = await this.MessageRepository.Create(this.DalMessageMapper.MapBOToEF(bo));

				var businessObject = this.DalMessageMapper.MapEFToBO(record);
				response.SetRecord(this.BolMessageMapper.MapBOToModel(businessObject));
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
				var bo = this.BolMessageMapper.MapModelToBO(messageId, model);
				await this.MessageRepository.Update(this.DalMessageMapper.MapBOToEF(bo));

				var record = await this.MessageRepository.Get(messageId);

				var businessObject = this.DalMessageMapper.MapEFToBO(record);
				var apiModel = this.BolMessageMapper.MapBOToModel(businessObject);
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

			return this.BolMessageMapper.MapBOToModel(this.DalMessageMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiMessengerServerResponseModel>> MessengersByMessageId(int messageId, int limit = int.MaxValue, int offset = 0)
		{
			List<Messenger> records = await this.MessageRepository.MessengersByMessageId(messageId, limit, offset);

			return this.BolMessengerMapper.MapBOToModel(this.DalMessengerMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>652632409850fbe88a6cdff204919e90</Hash>
</Codenesium>*/