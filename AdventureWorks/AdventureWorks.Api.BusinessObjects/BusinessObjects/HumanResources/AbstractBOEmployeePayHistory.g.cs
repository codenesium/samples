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
	public abstract class AbstractBOEmployeePayHistory
	{
		private IEmployeePayHistoryRepository employeePayHistoryRepository;
		private IEmployeePayHistoryModelValidator employeePayHistoryModelValidator;
		private ILogger logger;

		public AbstractBOEmployeePayHistory(
			ILogger logger,
			IEmployeePayHistoryRepository employeePayHistoryRepository,
			IEmployeePayHistoryModelValidator employeePayHistoryModelValidator)

		{
			this.employeePayHistoryRepository = employeePayHistoryRepository;
			this.employeePayHistoryModelValidator = employeePayHistoryModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			EmployeePayHistoryModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.employeePayHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.employeePayHistoryRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			EmployeePayHistoryModel model)
		{
			ActionResponse response = new ActionResponse(await this.employeePayHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				this.employeePayHistoryRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.employeePayHistoryModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				this.employeePayHistoryRepository.Delete(businessEntityID);
			}
			return response;
		}

		public virtual POCOEmployeePayHistory Get(int businessEntityID)
		{
			return this.employeePayHistoryRepository.Get(businessEntityID);
		}

		public virtual List<POCOEmployeePayHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.employeePayHistoryRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>f895d2a6b7f5fa2d1d916053ae1a449a</Hash>
</Codenesium>*/