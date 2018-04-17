using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IUnitMeasureModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(UnitMeasureModel model);
		Task<ValidationResult>  ValidateUpdateAsync(string id, UnitMeasureModel model);
		Task<ValidationResult>  ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>42c972ac7816b91116f2358710b338e3</Hash>
</Codenesium>*/