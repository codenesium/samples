using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiEventStudentRequestModelValidator : AbstractApiEventStudentRequestModelValidator, IApiEventStudentRequestModelValidator
	{
		public ApiEventStudentRequestModelValidator(IEventStudentRepository eventStudentRepository)
			: base(eventStudentRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEventStudentRequestModel model)
		{
			this.StudentIdRules();
			this.IsDeletedRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventStudentRequestModel model)
		{
			this.StudentIdRules();
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
    <Hash>bfef25c193ca8a8e24d9301095e9f5fc</Hash>
</Codenesium>*/