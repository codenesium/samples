using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiEventStatuServerRequestModelValidator : AbstractApiEventStatuServerRequestModelValidator, IApiEventStatuServerRequestModelValidator
	{
		public ApiEventStatuServerRequestModelValidator(IEventStatuRepository eventStatuRepository)
			: base(eventStatuRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEventStatuServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventStatuServerRequestModel model)
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
    <Hash>b9547d38e422099a0f4f5d7176f2c6cf</Hash>
</Codenesium>*/