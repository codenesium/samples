using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Services
{
	public partial interface IApiDirectTweetServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDirectTweetServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDirectTweetServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>01534fd257863441df33da6879153e67</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/