using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiUnitMeasureServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUnitMeasureServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiUnitMeasureServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>bb189acb56c61d8bf065de4db29698e8</Hash>
</Codenesium>*/