using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductCostHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductCostHistoryRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductCostHistoryRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>145430d397a3b6f1474ca9a2aa3317fc</Hash>
</Codenesium>*/