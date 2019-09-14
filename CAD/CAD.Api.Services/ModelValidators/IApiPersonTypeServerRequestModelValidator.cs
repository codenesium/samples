using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiPersonTypeServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPersonTypeServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonTypeServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>455328f78ca62306e82bcdce841f7f97</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/