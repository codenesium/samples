using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IPurchaseOrderHeaderModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(PurchaseOrderHeaderModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, PurchaseOrderHeaderModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ab0809f38baeb1db46adf09853af11f4</Hash>
</Codenesium>*/