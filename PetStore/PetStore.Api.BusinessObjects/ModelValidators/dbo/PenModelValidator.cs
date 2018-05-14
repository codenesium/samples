using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public class ApiPenModelValidator: AbstractApiPenModelValidator, IApiPenModelValidator
	{
		public ApiPenModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPenModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPenModel model)
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
    <Hash>59ec2d3e99e5a41e18635d3d32cbb3d7</Hash>
</Codenesium>*/