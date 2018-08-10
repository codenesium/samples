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
    <Hash>ae412d494619c9e5b112e9b4cd8cf47c</Hash>
</Codenesium>*/