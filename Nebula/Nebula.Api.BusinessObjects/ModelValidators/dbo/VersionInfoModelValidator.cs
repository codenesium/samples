using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class ApiVersionInfoRequestModelValidator: AbstractApiVersionInfoRequestModelValidator, IApiVersionInfoRequestModelValidator
	{
		public ApiVersionInfoRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiVersionInfoRequestModel model)
		{
			this.AppliedOnRules();
			this.DescriptionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(long id, ApiVersionInfoRequestModel model)
		{
			this.AppliedOnRules();
			this.DescriptionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(long id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>ecf0e705cbb1cf5ebb092533eb012d1c</Hash>
</Codenesium>*/