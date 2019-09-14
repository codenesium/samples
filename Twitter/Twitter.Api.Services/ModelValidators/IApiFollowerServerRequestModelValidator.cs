using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Services
{
	public partial interface IApiFollowerServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFollowerServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiFollowerServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d3275364eb41284313b0d650551cf307</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/