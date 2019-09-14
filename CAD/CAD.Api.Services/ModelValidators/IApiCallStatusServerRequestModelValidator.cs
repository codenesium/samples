using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiCallStatusServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCallStatusServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCallStatusServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2442cd4360bf4c1927eae7f58a6f50b8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/