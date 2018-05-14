using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiEmployeeDepartmentHistoryModelValidator: AbstractApiEmployeeDepartmentHistoryModelValidator, IApiEmployeeDepartmentHistoryModelValidator
	{
		public ApiEmployeeDepartmentHistoryModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiEmployeeDepartmentHistoryModel model)
		{
			this.DepartmentIDRules();
			this.EndDateRules();
			this.ModifiedDateRules();
			this.ShiftIDRules();
			this.StartDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeDepartmentHistoryModel model)
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
    <Hash>7a234d3dd9d94ef24960909b2699dea8</Hash>
</Codenesium>*/