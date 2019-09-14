using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiTeacherTeacherSkillServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeacherTeacherSkillServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherTeacherSkillServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>776b2d97a3b80e5a4537578649ec4aa7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/