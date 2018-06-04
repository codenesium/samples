using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiAddressRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAddressRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3b85a7496779811ca605ff59306334aa</Hash>
</Codenesium>*/