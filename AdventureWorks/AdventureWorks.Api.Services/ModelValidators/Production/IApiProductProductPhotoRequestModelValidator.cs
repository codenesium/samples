using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductProductPhotoRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductProductPhotoRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductProductPhotoRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c7cce312eb43120f7c852e15091cd0ca</Hash>
</Codenesium>*/