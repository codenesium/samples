using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiDepartmentServerRequestModelValidator : AbstractApiDepartmentServerRequestModelValidator, IApiDepartmentServerRequestModelValidator
	{
		public ApiDepartmentServerRequestModelValidator(IDepartmentRepository departmentRepository)
			: base(departmentRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiDepartmentServerRequestModel model)
		{
			this.GroupNameRules();
			this.ModifiedDateRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(short id, ApiDepartmentServerRequestModel model)
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
    <Hash>089cd27b7c2384e1dcbe5056cd4c93e4</Hash>
</Codenesium>*/