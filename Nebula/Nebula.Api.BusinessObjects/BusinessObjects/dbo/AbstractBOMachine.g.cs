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

		public virtual ApiResponse GetById(int id)
		{
			return this.machineRepository.GetById(id);
		}

		public virtual POCOMachine GetByIdDirect(int id)
		{
			return this.machineRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFMachine, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.machineRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.machineRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOMachine> GetWhereDirect(Expression<Func<EFMachine, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.machineRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>3c88bac2d4a2bd1d27d221fd2c6b42d5</Hash>
</Codenesium>*/