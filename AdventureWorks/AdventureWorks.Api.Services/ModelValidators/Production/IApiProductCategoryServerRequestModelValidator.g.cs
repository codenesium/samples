using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductCategoryServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductCategoryServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductCategoryServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>80d4cd35c90051e79b5b5ba54c26cbd4</Hash>
</Codenesium>*/