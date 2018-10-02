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
	public abstract class AbstractVoteTypeService : AbstractService
	{
		protected IVoteTypeRepository VoteTypeRepository { get; private set; }

		protected IApiVoteTypeRequestModelValidator VoteTypeModelValidator { get; private set; }

		protected IBOLVoteTypeMapper BolVoteTypeMapper { get; private set; }

		protected IDALVoteTypeMapper DalVoteTypeMapper { get; private set; }

		private ILogger logger;

		public AbstractVoteTypeService(
			ILogger logger,
			IVoteTypeRepository voteTypeRepository,
			IApiVoteTypeRequestModelValidator voteTypeModelValidator,
			IBOLVoteTypeMapper bolVoteTypeMapper,
			IDALVoteTypeMapper dalVoteTypeMapper)
			: base()
		{
			this.VoteTypeRepository = voteTypeRepository;
			this.VoteTypeModelValidator = voteTypeModelValidator;
			this.BolVoteTypeMapper = bolVoteTypeMapper;
			this.DalVoteTypeMapper = dalVoteTypeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiVoteTypeResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.VoteTypeRepository.All(limit, offset);

			return this.BolVoteTypeMapper.MapBOToModel(this.DalVoteTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVoteTypeResponseModel> Get(int id)
		{
			var record = await this.VoteTypeRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVoteTypeMapper.MapBOToModel(this.DalVoteTypeMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiVoteTypeResponseModel>> Create(
			ApiVoteTypeRequestModel model)
		{
			CreateResponse<ApiVoteTypeResponseModel> response = new CreateResponse<ApiVoteTypeResponseModel>(await this.VoteTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolVoteTypeMapper.MapModelToBO(default(int), model);
				var record = await this.VoteTypeRepository.Create(this.DalVoteTypeMapper.MapBOToEF(bo));

				response.SetRecord(this.BolVoteTypeMapper.MapBOToModel(this.DalVoteTypeMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVoteTypeResponseModel>> Update(
			int id,
			ApiVoteTypeRequestModel model)
		{
			var validationResult = await this.VoteTypeModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolVoteTypeMapper.MapModelToBO(id, model);
				await this.VoteTypeRepository.Update(this.DalVoteTypeMapper.MapBOToEF(bo));

				var record = await this.VoteTypeRepository.Get(id);

				return new UpdateResponse<ApiVoteTypeResponseModel>(this.BolVoteTypeMapper.MapBOToModel(this.DalVoteTypeMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiVoteTypeResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.VoteTypeModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.VoteTypeRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d716c0f1dd7fe0c2427e13a697e7ad45</Hash>
</Codenesium>*/