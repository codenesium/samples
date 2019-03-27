using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class ApiEventTeacherServerRequestModelValidator : AbstractApiEventTeacherServerRequestModelValidator, IApiEventTeacherServerRequestModelValidator
	{
		public ApiEventTeacherServerRequestModelValidator(IEventTeacherRepository eventTeacherRepository)
			: base(eventTeacherRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEventTeacherServerRequestModel model)
		{
			this.TeacherIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventTeacherServerRequestModel model)
		{
			this.TeacherIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>a48abbb5af1b799d5bfa46675b5d745f</Hash>
</Codenesium>*/