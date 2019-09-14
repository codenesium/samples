using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiTeacherSkillServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeacherSkillServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherSkillServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f7af485f48a6ff2948a2334df38908fe</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/