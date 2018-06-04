using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiUnitMeasureRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUnitMeasureRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(string id, ApiUnitMeasureRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>44ff01fcf5db5ee34286e4066f34610c</Hash>
</Codenesium>*/