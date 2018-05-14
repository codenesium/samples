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

		public virtual List<POCOMachine> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.machineRepository.All(skip, take, orderClause);
		}

		public virtual POCOMachine Get(int id)
		{
			return this.machineRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOMachine>> Create(
			MachineModel model)
		{
			CreateResponse<POCOMachine> response = new CreateResponse<POCOMachine>(await this.machineModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOMachine record = this.machineRepository.Create(model);
				response.SetRecord(record);
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

		public POCOMachine MachineGuid(Guid machineGuid)
		{
			return this.machineRepository.MachineGuid(machineGuid);
		}
	}
}

/*<Codenesium>
    <Hash>4d50614e8e0222e6df8281c4e5c8402c</Hash>
</Codenesium>*/