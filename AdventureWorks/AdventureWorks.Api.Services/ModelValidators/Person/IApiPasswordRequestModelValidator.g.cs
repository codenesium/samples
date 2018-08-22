using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiPasswordRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPasswordRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPasswordRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>03efe2c39d59b6c39118543fa8ff585e</Hash>
</Codenesium>*/