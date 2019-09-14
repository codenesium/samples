using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiIncludedColumnTestServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiIncludedColumnTestServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiIncludedColumnTestServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>48df19e91f9d4f205b054a2045e3f03f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/