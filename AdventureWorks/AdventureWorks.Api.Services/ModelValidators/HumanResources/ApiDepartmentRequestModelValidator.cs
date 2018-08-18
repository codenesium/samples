using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiDepartmentRequestModelValidator : AbstractApiDepartmentRequestModelValidator, IApiDepartmentRequestModelValidator
	{
		public ApiDepartmentRequestModelValidator(IDepartmentRepository departmentRepository)
			: base(departmentRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiDepartmentRequestModel model)
		{
			this.GroupNameRules();
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(short id, ApiDepartmentRequestModel model)
		{
			this.GroupNameRules();
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(short id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>ad654b9a2d3958cfef4e913d1dbea9e0</Hash>
</Codenesium>*/