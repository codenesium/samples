using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IPurchaseOrderDetailModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(PurchaseOrderDetailModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, PurchaseOrderDetailModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e235457d721ec4a42468df56d059f6ea</Hash>
</Codenesium>*/