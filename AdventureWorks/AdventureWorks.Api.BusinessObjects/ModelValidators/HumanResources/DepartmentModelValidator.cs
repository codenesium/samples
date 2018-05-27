using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiDepartmentRequestModelValidator: AbstractApiDepartmentRequestModelValidator, IApiDepartmentRequestModelValidator
	{
		public ApiDepartmentRequestModelValidator()
		{   }

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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(short id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>d0bfb674495a2ac225cc9788ac53e5b1</Hash>
</Codenesium>*/