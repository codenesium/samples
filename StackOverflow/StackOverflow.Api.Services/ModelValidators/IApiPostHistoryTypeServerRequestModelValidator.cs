using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostHistoryTypeServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPostHistoryTypeServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostHistoryTypeServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6294733585e7ceda0acd21f1ec439fb9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/