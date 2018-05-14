using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class ApiVersionInfoModelValidator: AbstractApiVersionInfoModelValidator, IApiVersionInfoModelValidator
	{
		public ApiVersionInfoModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiVersionInfoModel model)
		{
			this.AppliedOnRules();
			this.DescriptionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(long id, ApiVersionInfoModel model)
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
    <Hash>91c47d18f58b773cec6cf3d20dbaf1bb</Hash>
</Codenesium>*/