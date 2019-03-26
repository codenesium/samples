using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiPurchaseOrderHeaderServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPurchaseOrderHeaderServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPurchaseOrderHeaderServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>14cbf1df26f6d019884d8d736912dabf</Hash>
</Codenesium>*/