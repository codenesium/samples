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
	public abstract class AbstractBOMachineRefTeam
	{
		private IMachineRefTeamRepository machineRefTeamRepository;
		private IMachineRefTeamModelValidator machineRefTeamModelValidator;
		private ILogger logger;

		public AbstractBOMachineRefTeam(
			ILogger logger,
			IMachineRefTeamRepository machineRefTeamRepository,
			IMachineRefTeamModelValidator machineRefTeamModelValidator)

		{
			this.machineRefTeamRepository = machineRefTeamRepository;
			this.machineRefTeamModelValidator = machineRefTeamModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			MachineRefTeamModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.machineRefTeamModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.machineRefTeamRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			MachineRefTeamModel model)
		{
			ActionResponse response = new ActionResponse(await this.machineRefTeamModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.machineRefTeamRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.machineRefTeamModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.machineRefTeamRepository.Delete(id);
			}
			return response;
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.machineRefTeamRepository.GetById(id);
		}

		public virtual POCOMachineRefTeam GetByIdDirect(int id)
		{
			return this.machineRefTeamRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFMachineRefTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.machineRefTeamRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.machineRefTeamRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOMachineRefTeam> GetWhereDirect(Expression<Func<EFMachineRefTeam, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.machineRefTeamRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>d3b33e657d3e518e89c1618c1d7fb4a0</Hash>
</Codenesium>*/