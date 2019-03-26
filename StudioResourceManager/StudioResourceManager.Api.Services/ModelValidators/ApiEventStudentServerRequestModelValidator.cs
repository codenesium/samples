using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiEventStudentServerRequestModelValidator : AbstractApiEventStudentServerRequestModelValidator, IApiEventStudentServerRequestModelValidator
	{
		public ApiEventStudentServerRequestModelValidator(IEventStudentRepository eventStudentRepository)
			: base(eventStudentRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEventStudentServerRequestModel model)
		{
			this.EventIdRules();
			this.StudentIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventStudentServerRequestModel model)
		{
			this.EventIdRules();
			this.StudentIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>5cce5c03b29c33c119e2a406bcb0c009</Hash>
</Codenesium>*/