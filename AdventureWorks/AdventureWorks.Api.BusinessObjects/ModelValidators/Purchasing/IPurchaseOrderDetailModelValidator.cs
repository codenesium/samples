using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiPurchaseOrderDetailModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPurchaseOrderDetailModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPurchaseOrderDetailModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b80130508d7a19d2191415d12666bca8</Hash>
</Codenesium>*/