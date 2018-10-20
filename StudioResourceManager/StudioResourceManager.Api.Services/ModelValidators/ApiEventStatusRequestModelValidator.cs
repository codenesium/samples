using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiEventStatusRequestModelValidator : AbstractApiEventStatusRequestModelValidator, IApiEventStatusRequestModelValidator
	{
		public ApiEventStatusRequestModelValidator(IEventStatusRepository eventStatusRepository)
			: base(eventStatusRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEventStatusRequestModel model)
		{
			this.NameRules();
			this.IsDeletedRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventStatusRequestModel model)
		{
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
    <Hash>a58ed3d15b201b845d1748be7dac5b9a</Hash>
</Codenesium>*/