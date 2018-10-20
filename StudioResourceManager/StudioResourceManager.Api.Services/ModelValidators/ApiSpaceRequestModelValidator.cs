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
			this.IsDeletedRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceRequestModel model)
		{
			this.DescriptionRules();
			this.NameRules();
			this.IsDeletedRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>acfa7c0d49813ae9a0edc9874512d34b</Hash>
</Codenesium>*/