using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiSpeciesServerRequestModelValidator : AbstractApiSpeciesServerRequestModelValidator, IApiSpeciesServerRequestModelValidator
	{
		public ApiSpeciesServerRequestModelValidator(ISpeciesRepository speciesRepository)
			: base(speciesRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSpeciesServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpeciesServerRequestModel model)
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
    <Hash>cab671127110b560c2dab29315e5f302</Hash>
</Codenesium>*/