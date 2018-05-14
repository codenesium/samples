using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiShipMethodModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiShipMethodModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiShipMethodModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>16bf106cc044fe8b7fc076c91ecc046c</Hash>
</Codenesium>*/