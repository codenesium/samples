using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public class ApiPenRequestModelValidator : AbstractApiPenRequestModelValidator, IApiPenRequestModelValidator
	{
		public ApiPenRequestModelValidator(IPenRepository penRepository)
			: base(penRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPenRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPenRequestModel model)
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
    <Hash>f3a494dfe046fc28960ecaecd279cf22</Hash>
</Codenesium>*/