using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiStudentRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStudentRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudentRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>96009e6d902f0d884295de06e5e66a7b</Hash>
</Codenesium>*/