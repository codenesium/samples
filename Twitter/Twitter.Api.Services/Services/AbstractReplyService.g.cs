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
	public abstract class AbstractReplyService : AbstractService
	{
		protected IReplyRepository ReplyRepository { get; private set; }

		protected IApiReplyRequestModelValidator ReplyModelValidator { get; private set; }

		protected IBOLReplyMapper BolReplyMapper { get; private set; }

		protected IDALReplyMapper DalReplyMapper { get; private set; }

		private ILogger logger;

		public AbstractReplyService(
			ILogger logger,
			IReplyRepository replyRepository,
			IApiReplyRequestModelValidator replyModelValidator,
			IBOLReplyMapper bolReplyMapper,
			IDALReplyMapper dalReplyMapper)
			: base()
		{
			this.ReplyRepository = replyRepository;
			this.ReplyModelValidator = replyModelValidator;
			this.BolReplyMapper = bolReplyMapper;
			this.DalReplyMapper = dalReplyMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiReplyResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ReplyRepository.All(limit, offset);

			return this.BolReplyMapper.MapBOToModel(this.DalReplyMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiReplyResponseModel> Get(int replyId)
		{
			var record = await this.ReplyRepository.Get(replyId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolReplyMapper.MapBOToModel(this.DalReplyMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiReplyResponseModel>> Create(
			ApiReplyRequestModel model)
		{
			CreateResponse<ApiReplyResponseModel> response = new CreateResponse<ApiReplyResponseModel>(await this.ReplyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolReplyMapper.MapModelToBO(default(int), model);
				var record = await this.ReplyRepository.Create(this.DalReplyMapper.MapBOToEF(bo));

				response.SetRecord(this.BolReplyMapper.MapBOToModel(this.DalReplyMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiReplyResponseModel>> Update(
			int replyId,
			ApiReplyRequestModel model)
		{
			var validationResult = await this.ReplyModelValidator.ValidateUpdateAsync(replyId, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolReplyMapper.MapModelToBO(replyId, model);
				await this.ReplyRepository.Update(this.DalReplyMapper.MapBOToEF(bo));

				var record = await this.ReplyRepository.Get(replyId);

				return new UpdateResponse<ApiReplyResponseModel>(this.BolReplyMapper.MapBOToModel(this.DalReplyMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiReplyResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int replyId)
		{
			ActionResponse response = new ActionResponse(await this.ReplyModelValidator.ValidateDeleteAsync(replyId));
			if (response.Success)
			{
				await this.ReplyRepository.Delete(replyId);
			}

			return response;
		}

		public async Task<List<ApiReplyResponseModel>> ByReplierUserId(int replierUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Reply> records = await this.ReplyRepository.ByReplierUserId(replierUserId, limit, offset);

			return this.BolReplyMapper.MapBOToModel(this.DalReplyMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>dc33190daf03f924091b6158151bc9a4</Hash>
</Codenesium>*/