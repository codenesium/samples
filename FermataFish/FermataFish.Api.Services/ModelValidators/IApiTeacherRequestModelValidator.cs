using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IApiTeacherRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeacherRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>90d31bed7f9540e91361db730484cb83</Hash>
</Codenesium>*/