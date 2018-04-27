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

		public virtual async Task<CreateResponse<int>> Create(
			EmployeeModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.employeeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.employeeRepository.Create(model);
				response.SetId(id);
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

		public virtual ApiResponse GetById(int id)
		{
			return this.employeeRepository.GetById(id);
		}

		public virtual POCOEmployee GetByIdDirect(int id)
		{
			return this.employeeRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFEmployee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.employeeRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.employeeRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOEmployee> GetWhereDirect(Expression<Func<EFEmployee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.employeeRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>ed935d73e5fe51b8d4247d94d3a1269f</Hash>
</Codenesium>*/