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
	public abstract class AbstractBOTeam
	{
		private ITeamRepository teamRepository;
		private IApiTeamModelValidator teamModelValidator;
		private ILogger logger;

		public AbstractBOTeam(
			ILogger logger,
			ITeamRepository teamRepository,
			IApiTeamModelValidator teamModelValidator)

		{
			this.teamRepository = teamRepository;
			this.teamModelValidator = teamModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOTeam> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.teamRepository.All(skip, take, orderClause);
		}

		public virtual POCOTeam Get(int id)
		{
			return this.teamRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOTeam>> Create(
			ApiTeamModel model)
		{
			CreateResponse<POCOTeam> response = new CreateResponse<POCOTeam>(await this.teamModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOTeam record = this.teamRepository.Create(model);
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
				this.teamRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.teamModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.teamRepository.Delete(id);
			}
			return response;
		}

		public POCOTeam Name(string name)
		{
			return this.teamRepository.Name(name);
		}
	}
}

/*<Codenesium>
    <Hash>375a9f7e85f5f520219eeb4a4625a0cc</Hash>
</Codenesium>*/