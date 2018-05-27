using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiAddressRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAddressRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e226996a74e5436df01aec34a9741da0</Hash>
</Codenesium>*/