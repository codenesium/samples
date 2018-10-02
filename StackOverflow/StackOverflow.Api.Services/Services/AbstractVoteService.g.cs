using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractVoteService : AbstractService
	{
		protected IVoteRepository VoteRepository { get; private set; }

		protected IApiVoteRequestModelValidator VoteModelValidator { get; private set; }

		protected IBOLVoteMapper BolVoteMapper { get; private set; }

		protected IDALVoteMapper DalVoteMapper { get; private set; }

		private ILogger logger;

		public AbstractVoteService(
			ILogger logger,
			IVoteRepository voteRepository,
			IApiVoteRequestModelValidator voteModelValidator,
			IBOLVoteMapper bolVoteMapper,
			IDALVoteMapper dalVoteMapper)
			: base()
		{
			this.VoteRepository = voteRepository;
			this.VoteModelValidator = voteModelValidator;
			this.BolVoteMapper = bolVoteMapper;
			this.DalVoteMapper = dalVoteMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiVoteResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.VoteRepository.All(limit, offset);

			return this.BolVoteMapper.MapBOToModel(this.DalVoteMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVoteResponseModel> Get(int id)
		{
			var record = await this.VoteRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVoteMapper.MapBOToModel(this.DalVoteMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiVoteResponseModel>> Create(
			ApiVoteRequestModel model)
		{
			CreateResponse<ApiVoteResponseModel> response = new CreateResponse<ApiVoteResponseModel>(await this.VoteModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolVoteMapper.MapModelToBO(default(int), model);
				var record = await this.VoteRepository.Create(this.DalVoteMapper.MapBOToEF(bo));

				response.SetRecord(this.BolVoteMapper.MapBOToModel(this.DalVoteMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVoteResponseModel>> Update(
			int id,
			ApiVoteRequestModel model)
		{
			var validationResult = await this.VoteModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolVoteMapper.MapModelToBO(id, model);
				await this.VoteRepository.Update(this.DalVoteMapper.MapBOToEF(bo));

				var record = await this.VoteRepository.Get(id);

				return new UpdateResponse<ApiVoteResponseModel>(this.BolVoteMapper.MapBOToModel(this.DalVoteMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiVoteResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.VoteModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.VoteRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiVoteResponseModel>> ByUserId(int? userId, int limit = 0, int offset = int.MaxValue)
		{
			List<Vote> records = await this.VoteRepository.ByUserId(userId, limit, offset);

			return this.BolVoteMapper.MapBOToModel(this.DalVoteMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>8a60dac732d73284ed2a2ebc660b9b27</Hash>
</Codenesium>*/