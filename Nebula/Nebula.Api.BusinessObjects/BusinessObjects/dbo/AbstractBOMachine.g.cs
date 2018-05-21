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
	public abstract class AbstractBOMachine: AbstractBOManager
	{
		private IMachineRepository machineRepository;
		private IApiMachineModelValidator machineModelValidator;
		private ILogger logger;

		public AbstractBOMachine(
			ILogger logger,
			IMachineRepository machineRepository,
			IApiMachineModelValidator machineModelValidator)
			: base()

		{
			this.machineRepository = machineRepository;
			this.machineModelValidator = machineModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOMachine>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.machineRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOMachine> Get(int id)
		{
			return this.machineRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOMachine>> Create(
			ApiMachineModel model)
		{
			CreateResponse<POCOMachine> response = new CreateResponse<POCOMachine>(await this.machineModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOMachine record = await this.machineRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiMachineModel model)
		{
			ActionResponse response = new ActionResponse(await this.machineModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.machineRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.machineModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.machineRepository.Delete(id);
			}
			return response;
		}

		public async Task<POCOMachine> MachineGuid(Guid machineGuid)
		{
			return await this.machineRepository.MachineGuid(machineGuid);
		}
	}
}

/*<Codenesium>
    <Hash>c79b28f6ae8b68ea6ebb227c0a44bc94</Hash>
</Codenesium>*/