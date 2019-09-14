using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiPersonServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPersonServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f00753f3291b8ece5d8994dd4d293ad3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/