using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class OrganizationModelValidator: AbstractOrganizationModelValidator, IOrganizationModelValidator
	{
		public OrganizationModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(OrganizationModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, OrganizationModel model)
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
    <Hash>a9ee6293ae4929882c48893350e76dab</Hash>
</Codenesium>*/