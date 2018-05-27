using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiBusinessEntityAddressRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityAddressRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityAddressRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>bec985685ce9b4cb1907e160fd959d30</Hash>
</Codenesium>*/