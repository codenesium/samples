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
	public abstract class AbstractBOMachineRefTeam: AbstractBOManager
	{
		private IMachineRefTeamRepository machineRefTeamRepository;
		private IApiMachineRefTeamModelValidator machineRefTeamModelValidator;
		private ILogger logger;

		public AbstractBOMachineRefTeam(
			ILogger logger,
			IMachineRefTeamRepository machineRefTeamRepository,
			IApiMachineRefTeamModelValidator machineRefTeamModelValidator)
			: base()

		{
			this.machineRefTeamRepository = machineRefTeamRepository;
			this.machineRefTeamModelValidator = machineRefTeamModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOMachineRefTeam>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.machineRefTeamRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOMachineRefTeam> Get(int id)
		{
			return this.machineRefTeamRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOMachineRefTeam>> Create(
			ApiMachineRefTeamModel model)
		{
			CreateResponse<POCOMachineRefTeam> response = new CreateResponse<POCOMachineRefTeam>(await this.machineRefTeamModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOMachineRefTeam record = await this.machineRefTeamRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiMachineRefTeamModel model)
		{
			ActionResponse response = new ActionResponse(await this.machineRefTeamModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.machineRefTeamRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.machineRefTeamModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.machineRefTeamRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>53b8d2e4505d8abfbd13fd1f3e69533e</Hash>
</Codenesium>*/