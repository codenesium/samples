using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBillOfMaterialsModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(BillOfMaterialsModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, BillOfMaterialsModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e1396002b8d114be7837b56aecbf19ae</Hash>
</Codenesium>*/