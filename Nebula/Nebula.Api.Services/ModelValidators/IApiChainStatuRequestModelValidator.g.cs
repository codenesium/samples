using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiChainStatuRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiChainStatuRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainStatuRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>85d088450e0257e61cda9f70f4b6a73d</Hash>
</Codenesium>*/