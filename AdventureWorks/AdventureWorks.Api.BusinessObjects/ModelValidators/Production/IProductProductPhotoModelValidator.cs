using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductProductPhotoModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductProductPhotoModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductProductPhotoModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5afb26aca9d7de121f85549c8569b0a7</Hash>
</Codenesium>*/