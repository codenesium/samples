using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiPersonPhoneRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPersonPhoneRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonPhoneRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1617bd0ac4c07e993c54cebc806168f0</Hash>
</Codenesium>*/