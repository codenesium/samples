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
		private ITeamModelValidator teamModelValidator;
		private ILogger logger;

		public AbstractBOTeam(
			ILogger logger,
			ITeamRepository teamRepository,
			ITeamModelValidator teamModelValidator)

		{
			this.teamRepository = teamRepository;
			this.teamModelValidator = teamModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			TeamModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.teamModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.teamRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			TeamModel model)
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

		public virtual ApiResponse GetById(int id)
		{
			return this.teamRepository.GetById(id);
		}

		public virtual POCOTeam GetByIdDirect(int id)
		{
			return this.teamRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.teamRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.teamRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOTeam> GetWhereDirect(Expression<Func<EFTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.teamRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>43e5d5ac24ea57cfe93a11f0960858e2</Hash>
</Codenesium>*/