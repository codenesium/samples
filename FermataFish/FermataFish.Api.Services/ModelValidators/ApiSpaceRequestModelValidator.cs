using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public class ApiSpaceRequestModelValidator : AbstractApiSpaceRequestModelValidator, IApiSpaceRequestModelValidator
	{
		public ApiSpaceRequestModelValidator(ISpaceRepository spaceRepository)
			: base(spaceRepository)
		{
		}

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
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>9628a812a474f7335895044d43036971</Hash>
</Codenesium>*/