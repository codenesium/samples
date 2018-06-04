using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
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
    <Hash>2bec8a6c972b56d4d2794162ed49f511</Hash>
</Codenesium>*/