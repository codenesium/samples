using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>4a7aee7f63f2641d1d9b1b87698d4062</Hash>
</Codenesium>*/