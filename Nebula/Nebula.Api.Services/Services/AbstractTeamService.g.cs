using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractTeamService: AbstractService
	{
		private ITeamRepository teamRepository;
		private IApiTeamRequestModelValidator teamModelValidator;
		private IBOLTeamMapper BOLTeamMapper;
		private IDALTeamMapper DALTeamMapper;
		private ILogger logger;

		public AbstractTeamService(
			ILogger logger,
			ITeamRepository teamRepository,
			IApiTeamRequestModelValidator teamModelValidator,
			IBOLTeamMapper bolteamMapper,
			IDALTeamMapper dalteamMapper)
			: base()

		{
			this.teamRepository = teamRepository;
			this.teamModelValidator = teamModelValidator;
			this.BOLTeamMapper = bolteamMapper;
			this.DALTeamMapper = dalteamMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTeamResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.teamRepository.All(skip, take, orderClause);

			return this.BOLTeamMapper.MapBOToModel(this.DALTeamMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTeamResponseModel> Get(int id)
		{
			var record = await teamRepository.Get(id);

			return this.BOLTeamMapper.MapBOToModel(this.DALTeamMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiTeamResponseModel>> Create(
			ApiTeamRequestModel model)
		{
			CreateResponse<ApiTeamResponseModel> response = new CreateResponse<ApiTeamResponseModel>(await this.teamModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLTeamMapper.MapModelToBO(default (int), model);
				var record = await this.teamRepository.Create(this.DALTeamMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLTeamMapper.MapBOToModel(this.DALTeamMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiTeamRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.teamModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLTeamMapper.MapModelToBO(id, model);
				await this.teamRepository.Update(this.DALTeamMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.teamModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.teamRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e2b8845113916c9364ee3b047315b32c</Hash>
</Codenesium>*/