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
	public abstract class AbstractBOEmployeeDepartmentHistory: AbstractBOManager
	{
		private IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository;
		private IApiEmployeeDepartmentHistoryModelValidator employeeDepartmentHistoryModelValidator;
		private ILogger logger;

		public AbstractBOEmployeeDepartmentHistory(
			ILogger logger,
			IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository,
			IApiEmployeeDepartmentHistoryModelValidator employeeDepartmentHistoryModelValidator)
			: base()

		{
			this.employeeDepartmentHistoryRepository = employeeDepartmentHistoryRepository;
			this.employeeDepartmentHistoryModelValidator = employeeDepartmentHistoryModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOEmployeeDepartmentHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.employeeDepartmentHistoryRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOEmployeeDepartmentHistory> Get(int businessEntityID)
		{
			return this.employeeDepartmentHistoryRepository.Get(businessEntityID);
		}

		public virtual async Task<CreateResponse<POCOEmployeeDepartmentHistory>> Create(
			ApiEmployeeDepartmentHistoryModel model)
		{
			CreateResponse<POCOEmployeeDepartmentHistory> response = new CreateResponse<POCOEmployeeDepartmentHistory>(await this.employeeDepartmentHistoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOEmployeeDepartmentHistory record = await this.employeeDepartmentHistoryRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiEmployeeDepartmentHistoryModel model)
		{
			ActionResponse response = new ActionResponse(await this.employeeDepartmentHistoryModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				await this.employeeDepartmentHistoryRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.employeeDepartmentHistoryModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.employeeDepartmentHistoryRepository.Delete(businessEntityID);
			}
			return response;
		}

		public async Task<List<POCOEmployeeDepartmentHistory>> GetDepartmentID(short departmentID)
		{
			return await this.employeeDepartmentHistoryRepository.GetDepartmentID(departmentID);
		}
		public async Task<List<POCOEmployeeDepartmentHistory>> GetShiftID(int shiftID)
		{
			return await this.employeeDepartmentHistoryRepository.GetShiftID(shiftID);
		}
	}
}

/*<Codenesium>
    <Hash>a24ffd782396159e336f7e0448569bea</Hash>
</Codenesium>*/