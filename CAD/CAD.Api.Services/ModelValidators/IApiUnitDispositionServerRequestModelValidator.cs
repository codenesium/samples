using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiUnitDispositionServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUnitDispositionServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiUnitDispositionServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>108d8af775de48278003b00f32861178</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/