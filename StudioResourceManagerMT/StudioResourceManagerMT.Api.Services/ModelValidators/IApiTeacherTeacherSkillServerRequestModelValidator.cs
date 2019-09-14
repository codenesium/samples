using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiTeacherTeacherSkillServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeacherTeacherSkillServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherTeacherSkillServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>74666c17d1a4f72e6790a04425257088</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/