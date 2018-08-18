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
	public abstract class AbstractVotesService : AbstractService
	{
		protected IVotesRepository VotesRepository { get; private set; }

		protected IApiVotesRequestModelValidator VotesModelValidator { get; private set; }

		protected IBOLVotesMapper BolVotesMapper { get; private set; }

		protected IDALVotesMapper DalVotesMapper { get; private set; }

		private ILogger logger;

		public AbstractVotesService(
			ILogger logger,
			IVotesRepository votesRepository,
			IApiVotesRequestModelValidator votesModelValidator,
			IBOLVotesMapper bolVotesMapper,
			IDALVotesMapper dalVotesMapper)
			: base()
		{
			this.VotesRepository = votesRepository;
			this.VotesModelValidator = votesModelValidator;
			this.BolVotesMapper = bolVotesMapper;
			this.DalVotesMapper = dalVotesMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiVotesResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.VotesRepository.All(limit, offset);

			return this.BolVotesMapper.MapBOToModel(this.DalVotesMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVotesResponseModel> Get(int id)
		{
			var record = await this.VotesRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVotesMapper.MapBOToModel(this.DalVotesMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiVotesResponseModel>> Create(
			ApiVotesRequestModel model)
		{
			CreateResponse<ApiVotesResponseModel> response = new CreateResponse<ApiVotesResponseModel>(await this.VotesModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolVotesMapper.MapModelToBO(default(int), model);
				var record = await this.VotesRepository.Create(this.DalVotesMapper.MapBOToEF(bo));

				response.SetRecord(this.BolVotesMapper.MapBOToModel(this.DalVotesMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVotesResponseModel>> Update(
			int id,
			ApiVotesRequestModel model)
		{
			var validationResult = await this.VotesModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolVotesMapper.MapModelToBO(id, model);
				await this.VotesRepository.Update(this.DalVotesMapper.MapBOToEF(bo));

				var record = await this.VotesRepository.Get(id);

				return new UpdateResponse<ApiVotesResponseModel>(this.BolVotesMapper.MapBOToModel(this.DalVotesMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiVotesResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.VotesModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.VotesRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c82bb001e56ebc657a1792c5e939a472</Hash>
</Codenesium>*/