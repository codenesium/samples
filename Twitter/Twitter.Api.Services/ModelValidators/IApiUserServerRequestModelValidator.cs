using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Services
{
	public partial interface IApiUserServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUserServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiUserServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7c1749ea8c9b935f98538b4b20c1c71c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/