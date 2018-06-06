using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
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
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(short id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>dc6febe4e4bacad34c0021ca411f5b2c</Hash>
</Codenesium>*/