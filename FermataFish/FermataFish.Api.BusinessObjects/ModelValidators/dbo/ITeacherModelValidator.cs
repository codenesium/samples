using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiTeacherRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeacherRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1765c233d06accb416eb404d2b39e988</Hash>
</Codenesium>*/