using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiAddressServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAddressServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5af61e36099e1cd018c355284ed5022f</Hash>
</Codenesium>*/