using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Services
{
	public interface IApiAdminRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAdminRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAdminRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5bc83f2df7554f28ce1ca77f2f1d8172</Hash>
</Codenesium>*/