using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiSpecialOfferProductRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpecialOfferProductRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpecialOfferProductRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>abd2d0f84b4d082389380f56caa3ce3c</Hash>
</Codenesium>*/