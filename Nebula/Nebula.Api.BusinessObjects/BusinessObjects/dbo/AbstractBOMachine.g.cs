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
	public abstract class AbstractBOMachine
	{
		private IMachineRepository machineRepository;
		private IMachineModelValidator machineModelValidator;
		private ILogger logger;

		public AbstractBOMachine(
			ILogger logger,
			IMachineRepository machineRepository,
			IMachineModelValidator machineModelValidator)

		{
			this.machineRepository = machineRepository;
			this.machineModelValidator = machineModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			MachineModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.machineModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.machineRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			MachineModel model)
		{
			ActionResponse response = new ActionResponse(await this.machineModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.machineRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.machineModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.machineRepository.Delete(id);
			}
			return response;
		}

		public virtual POCOMachine Get(int id)
		{
			return this.machineRepository.Get(id);
		}

		public virtual List<POCOMachine> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.machineRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>1776d35d5831c8fc2ecda1a6409a31aa</Hash>
</Codenesium>*/