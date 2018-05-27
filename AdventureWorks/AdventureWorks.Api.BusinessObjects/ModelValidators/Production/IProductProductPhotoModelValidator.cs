using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductProductPhotoRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductProductPhotoRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductProductPhotoRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>532988326f0ea63adc2a263a364be08f</Hash>
</Codenesium>*/