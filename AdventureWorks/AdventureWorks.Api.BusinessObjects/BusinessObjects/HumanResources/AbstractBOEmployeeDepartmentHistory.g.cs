using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOEmployeeDepartmentHistory
	{
		private IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository;
		private IEmployeeDepartmentHistoryModelValidator employeeDepartmentHistoryModelValidator;
		private ILogger logger;

		public AbstractBOEmployeeDepartmentHistory(
			ILogger logger,
			IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository,
			IEmployeeDepartmentHistoryModelValidator employeeDepartmentHistoryModelValidator)

		{
			this.employeeDepartmentHistoryRepository = employeeDepartmentHistoryRepository;
			this.employeeDepartmentHistoryModelValidator = employeeDepartmentHistoryModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			EmployeeDepartmentHistoryModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.employeeDepartmentHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.employeeDepartmentHistoryRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			EmployeeDepartmentHistoryModel model)
		{
			ActionResponse response = new ActionResponse(await this.employeeDepartmentHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				this.employeeDepartmentHistoryRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.employeeDepartmentHistoryModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				this.employeeDepartmentHistoryRepository.Delete(businessEntityID);
			}
			return response;
		}

		public virtual POCOEmployeeDepartmentHistory Get(int businessEntityID)
		{
			return this.employeeDepartmentHistoryRepository.Get(businessEntityID);
		}

		public virtual List<POCOEmployeeDepartmentHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.employeeDepartmentHistoryRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>397d970f5a8cca54f7e57e7913815494</Hash>
</Codenesium>*/