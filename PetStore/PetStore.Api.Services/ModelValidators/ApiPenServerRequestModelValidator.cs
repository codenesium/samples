using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public class ApiPenServerRequestModelValidator : AbstractApiPenServerRequestModelValidator, IApiPenServerRequestModelValidator
	{
		public ApiPenServerRequestModelValidator(IPenRepository penRepository)
			: base(penRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPenServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPenServerRequestModel model)
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
    <Hash>515540d8678278ee75a6189ea88864f5</Hash>
</Codenesium>*/