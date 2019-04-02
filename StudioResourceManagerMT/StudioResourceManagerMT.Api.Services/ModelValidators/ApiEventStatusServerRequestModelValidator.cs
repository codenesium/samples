using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class ApiEventStatusServerRequestModelValidator : AbstractApiEventStatusServerRequestModelValidator, IApiEventStatusServerRequestModelValidator
	{
		public ApiEventStatusServerRequestModelValidator(IEventStatusRepository eventStatusRepository)
			: base(eventStatusRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEventStatusServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventStatusServerRequestModel model)
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
    <Hash>af76b27d6d31ededd533f08772356303</Hash>
</Codenesium>*/