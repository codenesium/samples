using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class ApiSpaceServerRequestModelValidator : AbstractApiSpaceServerRequestModelValidator, IApiSpaceServerRequestModelValidator
	{
		public ApiSpaceServerRequestModelValidator(ISpaceRepository spaceRepository)
			: base(spaceRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSpaceServerRequestModel model)
		{
			this.DescriptionRules();
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceServerRequestModel model)
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
    <Hash>bb6b828946edb236e171eca33fc58cf5</Hash>
</Codenesium>*/