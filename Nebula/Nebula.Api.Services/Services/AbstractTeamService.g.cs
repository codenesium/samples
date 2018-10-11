using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractTeamService : AbstractService
	{
		protected ITeamRepository TeamRepository { get; private set; }

		protected IApiTeamRequestModelValidator TeamModelValidator { get; private set; }

		protected IBOLTeamMapper BolTeamMapper { get; private set; }

		protected IDALTeamMapper DalTeamMapper { get; private set; }

		protected IBOLChainMapper BolChainMapper { get; private set; }

		protected IDALChainMapper DalChainMapper { get; private set; }

		private ILogger logger;

		public AbstractTeamService(
			ILogger logger,
			ITeamRepository teamRepository,
			IApiTeamRequestModelValidator teamModelValidator,
			IBOLTeamMapper bolTeamMapper,
			IDALTeamMapper dalTeamMapper,
			IBOLChainMapper bolChainMapper,
			IDALChainMapper dalChainMapper)
			: base()
		{
			this.TeamRepository = teamRepository;
			this.TeamModelValidator = teamModelValidator;
			this.BolTeamMapper = bolTeamMapper;
			this.DalTeamMapper = dalTeamMapper;
			this.BolChainMapper = bolChainMapper;
			this.DalChainMapper = dalChainMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTeamResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TeamRepository.All(limit, offset);

			return this.BolTeamMapper.MapBOToModel(this.DalTeamMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTeamResponseModel> Get(int id)
		{
			var record = await this.TeamRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTeamMapper.MapBOToModel(this.DalTeamMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTeamResponseModel>> Create(
			ApiTeamRequestModel model)
		{
			CreateResponse<ApiTeamResponseModel> response = new CreateResponse<ApiTeamResponseModel>(await this.TeamModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolTeamMapper.MapModelToBO(default(int), model);
				var record = await this.TeamRepository.Create(this.DalTeamMapper.MapBOToEF(bo));

				response.SetRecord(this.BolTeamMapper.MapBOToModel(this.DalTeamMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTeamResponseModel>> Update(
			int id,
			ApiTeamRequestModel model)
		{
			var validationResult = await this.TeamModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolTeamMapper.MapModelToBO(id, model);
				await this.TeamRepository.Update(this.DalTeamMapper.MapBOToEF(bo));

				var record = await this.TeamRepository.Get(id);

				return new UpdateResponse<ApiTeamResponseModel>(this.BolTeamMapper.MapBOToModel(this.DalTeamMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiTeamResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.TeamModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.TeamRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiTeamResponseModel> ByName(string name)
		{
			Team record = await this.TeamRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTeamMapper.MapBOToModel(this.DalTeamMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiChainResponseModel>> Chains(int teamId, int limit = int.MaxValue, int offset = 0)
		{
			List<Chain> records = await this.TeamRepository.Chains(teamId, limit, offset);

			return this.BolChainMapper.MapBOToModel(this.DalChainMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiTeamResponseModel>> ByMachineId(int machineId, int limit = int.MaxValue, int offset = 0)
		{
			List<Team> records = await this.TeamRepository.ByMachineId(machineId, limit, offset);

			return this.BolTeamMapper.MapBOToModel(this.DalTeamMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>337c78f8ffd58a1179fc0beb7a082f21</Hash>
</Codenesium>*/