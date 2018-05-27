using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiShipMethodRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiShipMethodRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiShipMethodRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>00fda0c76c5583ad052743e5231b79ca</Hash>
</Codenesium>*/