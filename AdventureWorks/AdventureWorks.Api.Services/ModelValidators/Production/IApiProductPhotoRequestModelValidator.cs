using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductPhotoRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductPhotoRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductPhotoRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>30b5caf19e667002d068a09b3e51864e</Hash>
</Codenesium>*/