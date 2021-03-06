using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiOfficerServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiOfficerServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiOfficerServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a890f17d180e119783cdda5fddbccc3b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/