using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiUnitMeasureRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUnitMeasureRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(string id, ApiUnitMeasureRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>32c3ee6f468178fec8a5d4e3a9d1e91f</Hash>
</Codenesium>*/