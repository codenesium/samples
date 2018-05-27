using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductPhotoRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductPhotoRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductPhotoRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e469a51939b01c12c701e6d2471b116b</Hash>
</Codenesium>*/