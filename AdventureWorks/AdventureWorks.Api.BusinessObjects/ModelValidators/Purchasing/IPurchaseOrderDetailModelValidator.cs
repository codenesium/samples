using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IPurchaseOrderDetailModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(PurchaseOrderDetailModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, PurchaseOrderDetailModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>49377f6f9b079601f6fa8eb64c9058d3</Hash>
</Codenesium>*/