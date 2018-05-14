using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public class ApiOrganizationModelValidator: AbstractApiOrganizationModelValidator, IApiOrganizationModelValidator
	{
		public ApiOrganizationModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiOrganizationModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiOrganizationModel model)
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
    <Hash>1bc813c4be750b6737dbc81f7a17c36f</Hash>
</Codenesium>*/