using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public class ReplyService : AbstractService, IReplyService
	{
		private MediatR.IMediator mediator;

		protected IReplyRepository ReplyRepository { get; private set; }

		protected IApiReplyServerRequestModelValidator ReplyModelValidator { get; private set; }

		protected IDALReplyMapper DalReplyMapper { get; private set; }

		private ILogger logger;

		public ReplyService(
			ILogger<IReplyService> logger,
			MediatR.IMediator mediator,
			IReplyRepository replyRepository,
			IApiReplyServerRequestModelValidator replyModelValidator,
			IDALReplyMapper dalReplyMapper)
			: base()
		{
			this.ReplyRepository = replyRepository;
			this.ReplyModelValidator = replyModelValidator;
			this.DalReplyMapper = dalReplyMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiReplyServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Reply> records = await this.ReplyRepository.All(limit, offset, query);

			return this.DalReplyMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiReplyServerResponseModel> Get(int replyId)
		{
			Reply record = await this.ReplyRepository.Get(replyId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalReplyMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiReplyServerResponseModel>> Create(
			ApiReplyServerRequestModel model)
		{
			CreateResponse<ApiReplyServerResponseModel> response = ValidationResponseFactory<ApiReplyServerResponseModel>.CreateResponse(await this.ReplyModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Reply record = this.DalReplyMapper.MapModelToEntity(default(int), model);
				record = await this.ReplyRepository.Create(record);

				response.SetRecord(this.DalReplyMapper.MapEntityToModel(record));
				await this.mediator.Publish(new ReplyCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiReplyServerResponseModel>> Update(
			int replyId,
			ApiReplyServerRequestModel model)
		{
			var validationResult = await this.ReplyModelValidator.ValidateUpdateAsync(replyId, model);

			if (validationResult.IsValid)
			{
				Reply record = this.DalReplyMapper.MapModelToEntity(replyId, model);
				await this.ReplyRepository.Update(record);

				record = await this.ReplyRepository.Get(replyId);

				ApiReplyServerResponseModel apiModel = this.DalReplyMapper.MapEntityToModel(record);
				await this.mediator.Publish(new ReplyUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiReplyServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiReplyServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int replyId)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ReplyModelValidator.ValidateDeleteAsync(replyId));

			if (response.Success)
			{
				await this.ReplyRepository.Delete(replyId);

				await this.mediator.Publish(new ReplyDeletedNotification(replyId));
			}

			return response;
		}

		public async virtual Task<List<ApiReplyServerResponseModel>> ByReplierUserId(int replierUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Reply> records = await this.ReplyRepository.ByReplierUserId(replierUserId, limit, offset);

			return this.DalReplyMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>1a5ded2ce623024db95f393462809414</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/