using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
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
    <Hash>f8002cba13b264d231c80a946ab97177</Hash>
</Codenesium>*/