using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiUnitMeasureRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUnitMeasureRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiUnitMeasureRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>a142a607fe4688e9d8302bbadfbccf19</Hash>
</Codenesium>*/