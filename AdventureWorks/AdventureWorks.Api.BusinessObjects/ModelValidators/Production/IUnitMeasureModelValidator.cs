using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IUnitMeasureModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(UnitMeasureModel model);
		Task<ValidationResult> ValidateUpdateAsync(string id, UnitMeasureModel model);
		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>e800079e49c505437c0fc8febf1e4132</Hash>
</Codenesium>*/