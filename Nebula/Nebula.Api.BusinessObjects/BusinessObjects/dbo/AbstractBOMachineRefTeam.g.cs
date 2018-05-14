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

		public virtual List<POCOMachineRefTeam> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.machineRefTeamRepository.All(skip, take, orderClause);
		}

		public virtual POCOMachineRefTeam Get(int id)
		{
			return this.machineRefTeamRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOMachineRefTeam>> Create(
			MachineRefTeamModel model)
		{
			CreateResponse<POCOMachineRefTeam> response = new CreateResponse<POCOMachineRefTeam>(await this.machineRefTeamModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOMachineRefTeam record = this.machineRefTeamRepository.Create(model);
				response.SetRecord(record);
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
	}
}

/*<Codenesium>
    <Hash>ce237c4582d73e11727215771e980289</Hash>
</Codenesium>*/