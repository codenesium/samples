using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Services
{
	public interface IApiSpaceXSpaceFeatureRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpaceXSpaceFeatureRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceXSpaceFeatureRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1555e43e8f7914d2270f788811146ffc</Hash>
</Codenesium>*/