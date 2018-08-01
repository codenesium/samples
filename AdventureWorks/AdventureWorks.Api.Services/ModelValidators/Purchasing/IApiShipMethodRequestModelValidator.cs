using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiShipMethodRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiShipMethodRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiShipMethodRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8464c4ef5d8f27770e231bd6bc5931ea</Hash>
</Codenesium>*/