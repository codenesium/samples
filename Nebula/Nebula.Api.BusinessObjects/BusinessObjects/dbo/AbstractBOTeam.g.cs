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
		private IApiTeamModelValidator teamModelValidator;
		private ILogger logger;

		public AbstractBOTeam(
			ILogger logger,
			ITeamRepository teamRepository,
			IApiTeamModelValidator teamModelValidator)
			: base()

		{
			this.teamRepository = teamRepository;
			this.teamModelValidator = teamModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOTeam>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.teamRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOTeam> Get(int id)
		{
			return this.teamRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOTeam>> Create(
			ApiTeamModel model)
		{
			CreateResponse<POCOTeam> response = new CreateResponse<POCOTeam>(await this.teamModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOTeam record = await this.teamRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiTeamModel model)
		{
			ActionResponse response = new ActionResponse(await this.teamModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.teamRepository.Update(id, model);
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

		public async Task<POCOTeam> Name(string name)
		{
			return await this.teamRepository.Name(name);
		}
	}
}

/*<Codenesium>
    <Hash>87f52bc9496e1fb632f3f9491b31ea09</Hash>
</Codenesium>*/