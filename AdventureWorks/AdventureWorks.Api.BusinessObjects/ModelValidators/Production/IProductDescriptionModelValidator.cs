using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductDescriptionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductDescriptionRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductDescriptionRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>62bc99ffa66ed42571ee5a20568dc958</Hash>
</Codenesium>*/