using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>90de856ca88195d8940c6f94301a3329</Hash>
</Codenesium>*/