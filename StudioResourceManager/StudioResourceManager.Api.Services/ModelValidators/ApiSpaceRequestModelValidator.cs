using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceRequestModel model)
		{
			this.DescriptionRules();
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
    <Hash>b46ec81a72f0ab2c01593ca97e9aa870</Hash>
</Codenesium>*/