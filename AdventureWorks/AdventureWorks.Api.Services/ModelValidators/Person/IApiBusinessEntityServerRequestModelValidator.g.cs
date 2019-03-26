using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiBusinessEntityServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c5638b24902c1836f923610ec143d9d5</Hash>
</Codenesium>*/