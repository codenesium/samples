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
	public abstract class AbstractVoteTypesService : AbstractService
	{
		protected IVoteTypesRepository VoteTypesRepository { get; private set; }

		protected IApiVoteTypesRequestModelValidator VoteTypesModelValidator { get; private set; }

		protected IBOLVoteTypesMapper BolVoteTypesMapper { get; private set; }

		protected IDALVoteTypesMapper DalVoteTypesMapper { get; private set; }

		private ILogger logger;

		public AbstractVoteTypesService(
			ILogger logger,
			IVoteTypesRepository voteTypesRepository,
			IApiVoteTypesRequestModelValidator voteTypesModelValidator,
			IBOLVoteTypesMapper bolVoteTypesMapper,
			IDALVoteTypesMapper dalVoteTypesMapper)
			: base()
		{
			this.VoteTypesRepository = voteTypesRepository;
			this.VoteTypesModelValidator = voteTypesModelValidator;
			this.BolVoteTypesMapper = bolVoteTypesMapper;
			this.DalVoteTypesMapper = dalVoteTypesMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiVoteTypesResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.VoteTypesRepository.All(limit, offset);

			return this.BolVoteTypesMapper.MapBOToModel(this.DalVoteTypesMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVoteTypesResponseModel> Get(int id)
		{
			var record = await this.VoteTypesRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVoteTypesMapper.MapBOToModel(this.DalVoteTypesMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiVoteTypesResponseModel>> Create(
			ApiVoteTypesRequestModel model)
		{
			CreateResponse<ApiVoteTypesResponseModel> response = new CreateResponse<ApiVoteTypesResponseModel>(await this.VoteTypesModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolVoteTypesMapper.MapModelToBO(default(int), model);
				var record = await this.VoteTypesRepository.Create(this.DalVoteTypesMapper.MapBOToEF(bo));

				response.SetRecord(this.BolVoteTypesMapper.MapBOToModel(this.DalVoteTypesMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVoteTypesResponseModel>> Update(
			int id,
			ApiVoteTypesRequestModel model)
		{
			var validationResult = await this.VoteTypesModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolVoteTypesMapper.MapModelToBO(id, model);
				await this.VoteTypesRepository.Update(this.DalVoteTypesMapper.MapBOToEF(bo));

				var record = await this.VoteTypesRepository.Get(id);

				return new UpdateResponse<ApiVoteTypesResponseModel>(this.BolVoteTypesMapper.MapBOToModel(this.DalVoteTypesMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiVoteTypesResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.VoteTypesModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.VoteTypesRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b7bff991d1f4c2da0ec95d7291a1b3ac</Hash>
</Codenesium>*/