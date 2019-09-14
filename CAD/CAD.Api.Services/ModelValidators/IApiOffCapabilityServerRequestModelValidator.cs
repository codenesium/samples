using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiOffCapabilityServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiOffCapabilityServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiOffCapabilityServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2bb2aaca54a284782108a41877e13339</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/