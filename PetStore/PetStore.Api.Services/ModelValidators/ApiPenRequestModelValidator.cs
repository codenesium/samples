using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public class ApiPenRequestModelValidator: AbstractApiPenRequestModelValidator, IApiPenRequestModelValidator
	{
		public ApiPenRequestModelValidator()
		{   }

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
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>b2f42927c2a32a4396f63395d8fb4406</Hash>
</Codenesium>*/