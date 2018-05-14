using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiUnitMeasureModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUnitMeasureModel model);
		Task<ValidationResult> ValidateUpdateAsync(string id, ApiUnitMeasureModel model);
		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>a5b7e2761fb420416fd939d1bc98fa87</Hash>
</Codenesium>*/