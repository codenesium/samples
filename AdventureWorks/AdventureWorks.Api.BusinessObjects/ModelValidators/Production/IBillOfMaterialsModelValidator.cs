using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiBillOfMaterialsModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBillOfMaterialsModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBillOfMaterialsModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>24d59fc7f13857f9008aeeadd5b2e247</Hash>
</Codenesium>*/