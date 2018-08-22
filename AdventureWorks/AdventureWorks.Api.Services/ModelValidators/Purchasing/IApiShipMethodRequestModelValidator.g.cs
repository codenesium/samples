using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiShipMethodRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiShipMethodRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiShipMethodRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>504e78a2e67df3fbc4b356c9c80c8428</Hash>
</Codenesium>*/