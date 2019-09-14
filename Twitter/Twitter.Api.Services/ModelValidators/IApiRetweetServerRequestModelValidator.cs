using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Services
{
	public partial interface IApiRetweetServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiRetweetServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiRetweetServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e50a82296506aaa354185d4a45d9c0ed</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/