using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Services
{
	public interface IApiTeacherRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTeacherRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTeacherRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7f6c99c43f263ec34b8b657b1858baeb</Hash>
</Codenesium>*/