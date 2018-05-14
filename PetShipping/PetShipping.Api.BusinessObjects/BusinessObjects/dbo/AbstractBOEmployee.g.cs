using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOEmployee
	{
		private IEmployeeRepository employeeRepository;
		private IEmployeeModelValidator employeeModelValidator;
		private ILogger logger;

		public AbstractBOEmployee(
			ILogger logger,
			IEmployeeRepository employeeRepository,
			IEmployeeModelValidator employeeModelValidator)

		{
			this.employeeRepository = employeeRepository;
			this.employeeModelValidator = employeeModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOEmployee> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.employeeRepository.All(skip, take, orderClause);
		}

		public virtual POCOEmployee Get(int id)
		{
			return this.employeeRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOEmployee>> Create(
			EmployeeModel model)
		{
			CreateResponse<POCOEmployee> response = new CreateResponse<POCOEmployee>(await this.employeeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOEmployee record = this.employeeRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			EmployeeModel model)
		{
			ActionResponse response = new ActionResponse(await this.employeeModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.employeeRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.employeeModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.employeeRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9f4bd2bfb4bcf5be93feb2e092eb2692</Hash>
</Codenesium>*/