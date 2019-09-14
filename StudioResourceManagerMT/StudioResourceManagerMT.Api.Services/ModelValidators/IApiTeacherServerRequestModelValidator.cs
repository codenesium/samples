using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiTeacherServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeacherServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f8898d56327046b8142562649f2c4981</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/