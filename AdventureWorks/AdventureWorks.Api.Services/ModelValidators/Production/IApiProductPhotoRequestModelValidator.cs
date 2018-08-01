using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiProductPhotoRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductPhotoRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductPhotoRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a94420a26b0a9cbc110c291d0b0af2aa</Hash>
</Codenesium>*/