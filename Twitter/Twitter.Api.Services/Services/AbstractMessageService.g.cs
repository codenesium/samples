using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractMessageService : AbstractService
	{
		protected IMessageRepository MessageRepository { get; private set; }

		protected IApiMessageRequestModelValidator MessageModelValidator { get; private set; }

		protected IBOLMessageMapper BolMessageMapper { get; private set; }

		protected IDALMessageMapper DalMessageMapper { get; private set; }

		protected IBOLMessengerMapper BolMessengerMapper { get; private set; }

		protected IDALMessengerMapper DalMessengerMapper { get; private set; }

		private ILogger logger;

		public AbstractMessageService(
			ILogger logger,
			IMessageRepository messageRepository,
			IApiMessageRequestModelValidator messageModelValidator,
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
		}

		public virtual async Task<List<ApiMessageResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.MessageRepository.All(limit, offset);

			return this.BolMessageMapper.MapBOToModel(this.DalMessageMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiMessageResponseModel> Get(int messageId)
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

		public virtual async Task<CreateResponse<ApiMessageResponseModel>> Create(
			ApiMessageRequestModel model)
		{
			CreateResponse<ApiMessageResponseModel> response = new CreateResponse<ApiMessageResponseModel>(await this.MessageModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolMessageMapper.MapModelToBO(default(int), model);
				var record = await this.MessageRepository.Create(this.DalMessageMapper.MapBOToEF(bo));

				response.SetRecord(this.BolMessageMapper.MapBOToModel(this.DalMessageMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiMessageResponseModel>> Update(
			int messageId,
			ApiMessageRequestModel model)
		{
			var validationResult = await this.MessageModelValidator.ValidateUpdateAsync(messageId, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolMessageMapper.MapModelToBO(messageId, model);
				await this.MessageRepository.Update(this.DalMessageMapper.MapBOToEF(bo));

				var record = await this.MessageRepository.Get(messageId);

				return new UpdateResponse<ApiMessageResponseModel>(this.BolMessageMapper.MapBOToModel(this.DalMessageMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiMessageResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int messageId)
		{
			ActionResponse response = new ActionResponse(await this.MessageModelValidator.ValidateDeleteAsync(messageId));
			if (response.Success)
			{
				await this.MessageRepository.Delete(messageId);
			}

			return response;
		}

		public async Task<List<ApiMessageResponseModel>> BySenderUserId(int? senderUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Message> records = await this.MessageRepository.BySenderUserId(senderUserId, limit, offset);

			return this.BolMessageMapper.MapBOToModel(this.DalMessageMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiMessengerResponseModel>> Messengers(int messageId, int limit = int.MaxValue, int offset = 0)
		{
			List<Messenger> records = await this.MessageRepository.Messengers(messageId, limit, offset);

			return this.BolMessengerMapper.MapBOToModel(this.DalMessengerMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>74d12ff24e353dccf8ada82b9a90981c</Hash>
</Codenesium>*/