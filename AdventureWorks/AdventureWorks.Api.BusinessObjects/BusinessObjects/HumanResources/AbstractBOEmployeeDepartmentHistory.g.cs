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

		public virtual ApiResponse GetById(int businessEntityID)
		{
			return this.employeeDepartmentHistoryRepository.GetById(businessEntityID);
		}

		public virtual POCOEmployeeDepartmentHistory GetByIdDirect(int businessEntityID)
		{
			return this.employeeDepartmentHistoryRepository.GetByIdDirect(businessEntityID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.employeeDepartmentHistoryRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.employeeDepartmentHistoryRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOEmployeeDepartmentHistory> GetWhereDirect(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.employeeDepartmentHistoryRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>24142808935a6b291dc00177a3eec4b6</Hash>
</Codenesium>*/