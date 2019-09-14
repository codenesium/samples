using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiTeacherSkillServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeacherSkillServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherSkillServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9a4791ad6484018d0caed41bf587945f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/