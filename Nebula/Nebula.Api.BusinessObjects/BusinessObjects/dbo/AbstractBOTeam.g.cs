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

namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOTeam: AbstractBOManager
	{
		private ITeamRepository teamRepository;
		private IApiTeamRequestModelValidator teamModelValidator;
		private IBOLTeamMapper teamMapper;
		private ILogger logger;

		public AbstractBOTeam(
			ILogger logger,
			ITeamRepository teamRepository,
			IApiTeamRequestModelValidator teamModelValidator,
			IBOLTeamMapper teamMapper)
			: base()

		{
			this.teamRepository = teamRepository;
			this.teamModelValidator = teamModelValidator;
			this.teamMapper = teamMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiTeamResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.teamRepository.All(skip, take, orderClause);

			return this.teamMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiTeamResponseModel> Get(int id)
		{
			var record = await teamRepository.Get(id);

			return this.teamMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiTeamResponseModel>> Create(
			ApiTeamRequestModel model)
		{
			CreateResponse<ApiTeamResponseModel> response = new CreateResponse<ApiTeamResponseModel>(await this.teamModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.teamMapper.MapModelToDTO(default (int), model);
				var record = await this.teamRepository.Create(dto);

				response.SetRecord(this.teamMapper.MapDTOToModel(record));
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
				var dto = this.teamMapper.MapModelToDTO(id, model);
				await this.teamRepository.Update(id, dto);
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

		public async Task<ApiTeamResponseModel> GetName(string name)
		{
			DTOTeam record = await this.teamRepository.GetName(name);

			return this.teamMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>1a7efda1b4f1f57a4312f85984fae5e5</Hash>
</Codenesium>*/