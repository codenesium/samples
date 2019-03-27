using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class ApiEventStudentServerRequestModelValidator : AbstractApiEventStudentServerRequestModelValidator, IApiEventStudentServerRequestModelValidator
	{
		public ApiEventStudentServerRequestModelValidator(IEventStudentRepository eventStudentRepository)
			: base(eventStudentRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEventStudentServerRequestModel model)
		{
			this.StudentIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventStudentServerRequestModel model)
		{
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
    <Hash>d2a607a4e0e099354341fc7d152a402e</Hash>
</Codenesium>*/