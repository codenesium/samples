using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class ApiStateModelValidator: AbstractApiStateModelValidator, IApiStateModelValidator
	{
		public ApiStateModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiStateModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStateModel model)
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
    <Hash>1b80ebb81a77b864e2a0dab1585e029b</Hash>
</Codenesium>*/