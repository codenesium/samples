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
		private IApiEmployeePayHistoryModelValidator employeePayHistoryModelValidator;
		private ILogger logger;

		public AbstractBOEmployeePayHistory(
			ILogger logger,
			IEmployeePayHistoryRepository employeePayHistoryRepository,
			IApiEmployeePayHistoryModelValidator employeePayHistoryModelValidator)

		{
			this.employeePayHistoryRepository = employeePayHistoryRepository;
			this.employeePayHistoryModelValidator = employeePayHistoryModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOEmployeePayHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.employeePayHistoryRepository.All(skip, take, orderClause);
		}

		public virtual POCOEmployeePayHistory Get(int businessEntityID)
		{
			return this.employeePayHistoryRepository.Get(businessEntityID);
		}

		public virtual async Task<CreateResponse<POCOEmployeePayHistory>> Create(
			ApiEmployeePayHistoryModel model)
		{
			CreateResponse<POCOEmployeePayHistory> response = new CreateResponse<POCOEmployeePayHistory>(await this.employeePayHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOEmployeePayHistory record = this.employeePayHistoryRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiEmployeePayHistoryModel model)
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
	}
}

/*<Codenesium>
    <Hash>79514ab6a7e2e4aeb9cc9147bba16ac1</Hash>
</Codenesium>*/