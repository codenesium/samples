using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>703ec7fa445091a5f562a565fc6309e3</Hash>
</Codenesium>*/