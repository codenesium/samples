using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiEmployeeDepartmentHistoryRequestModelValidator : AbstractApiEmployeeDepartmentHistoryRequestModelValidator, IApiEmployeeDepartmentHistoryRequestModelValidator
	{
		public ApiEmployeeDepartmentHistoryRequestModelValidator(IEmployeeDepartmentHistoryRepository employeeDepartmentHistoryRepository)
			: base(employeeDepartmentHistoryRepository)
		{
		}

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
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>3d8788a145996da94627eff34843ec0c</Hash>
</Codenesium>*/