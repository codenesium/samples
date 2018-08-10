using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiAddressRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAddressRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0eb037a37013137d417c48285ac90c3c</Hash>
</Codenesium>*/