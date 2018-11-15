using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>17b1e268eaa468429fec48b99ca49c6a</Hash>
</Codenesium>*/