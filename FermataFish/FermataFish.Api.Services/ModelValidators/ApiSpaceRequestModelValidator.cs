using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public class ApiSpaceRequestModelValidator: AbstractApiSpaceRequestModelValidator, IApiSpaceRequestModelValidator
	{
		public ApiSpaceRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiSpaceRequestModel model)
		{
			this.DescriptionRules();
			this.NameRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceRequestModel model)
		{
			this.DescriptionRules();
			this.NameRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>647b6cd0592ffe961326df2a0880d286</Hash>
</Codenesium>*/