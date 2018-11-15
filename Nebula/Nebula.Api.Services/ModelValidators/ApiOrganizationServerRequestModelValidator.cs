using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiOrganizationServerRequestModelValidator : AbstractApiOrganizationServerRequestModelValidator, IApiOrganizationServerRequestModelValidator
	{
		public ApiOrganizationServerRequestModelValidator(IOrganizationRepository organizationRepository)
			: base(organizationRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiOrganizationServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiOrganizationServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>e6d7db69d99510931006b5020675699b</Hash>
</Codenesium>*/