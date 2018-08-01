using FermataFishNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public interface IApiSpaceRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpaceRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c3360cf2ed62b5db17b4ad5469f10c47</Hash>
</Codenesium>*/