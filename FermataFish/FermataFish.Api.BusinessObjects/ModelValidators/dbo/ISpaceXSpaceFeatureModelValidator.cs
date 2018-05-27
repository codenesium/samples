using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.BusinessObjects
{
	public interface IApiSpaceXSpaceFeatureRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpaceXSpaceFeatureRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceXSpaceFeatureRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>bbcab4efaf9453532cb5defabba79231</Hash>
</Codenesium>*/