using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiPhoneNumberTypeServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPhoneNumberTypeServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPhoneNumberTypeServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2ba943ffc3d5293ca24b65a29b5e8def</Hash>
</Codenesium>*/