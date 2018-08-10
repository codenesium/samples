using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiEmailAddressRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEmailAddressRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmailAddressRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>916e24bcf2cc27f2ee8b4e6da3ee0c47</Hash>
</Codenesium>*/