using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class ApiOrganizationRequestModelValidator: AbstractApiOrganizationRequestModelValidator, IApiOrganizationRequestModelValidator
	{
		public ApiOrganizationRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiOrganizationRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiOrganizationRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>e8ed675c6f68c17cec2805ba42f17a8d</Hash>
</Codenesium>*/