using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostHistoryServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPostHistoryServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostHistoryServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>08a4add46bb9abb320880f42a133c1c5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/