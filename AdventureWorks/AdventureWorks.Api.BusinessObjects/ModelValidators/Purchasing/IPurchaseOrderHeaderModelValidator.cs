using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IPurchaseOrderHeaderModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(PurchaseOrderHeaderModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, PurchaseOrderHeaderModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fb45906064ed2fdc412a4f342cafd7ba</Hash>
</Codenesium>*/