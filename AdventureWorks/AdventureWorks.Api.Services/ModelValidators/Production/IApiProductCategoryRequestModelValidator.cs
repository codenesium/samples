using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductCategoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductCategoryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductCategoryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1c6d0c055fb90856218bb6ae0578c2d8</Hash>
</Codenesium>*/