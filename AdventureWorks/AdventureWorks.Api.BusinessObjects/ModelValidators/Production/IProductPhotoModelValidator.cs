using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductPhotoModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductPhotoModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductPhotoModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2bf2220d01ec9c29c7339e12b14af4e6</Hash>
</Codenesium>*/