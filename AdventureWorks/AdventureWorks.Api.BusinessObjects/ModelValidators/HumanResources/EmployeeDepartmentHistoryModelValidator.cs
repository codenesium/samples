using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiEmployeeDepartmentHistoryRequestModelValidator: AbstractApiEmployeeDepartmentHistoryRequestModelValidator, IApiEmployeeDepartmentHistoryRequestModelValidator
	{
		public ApiEmployeeDepartmentHistoryRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiEmployeeDepartmentHistoryRequestModel model)
		{
			this.DepartmentIDRules();
			this.EndDateRules();
			this.ModifiedDateRules();
			this.ShiftIDRules();
			this.StartDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeDepartmentHistoryRequestModel model)
		{
			this.DepartmentIDRules();
			this.EndDateRules();
			this.ModifiedDateRules();
			this.ShiftIDRules();
			this.StartDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>b22f12e2aacda50efcfb63ba74f6acbd</Hash>
</Codenesium>*/