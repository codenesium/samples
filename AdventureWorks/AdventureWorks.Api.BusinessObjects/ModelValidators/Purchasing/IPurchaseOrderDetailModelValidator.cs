using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiPurchaseOrderDetailRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPurchaseOrderDetailRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPurchaseOrderDetailRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d264130f1eb457401507fecb06974bec</Hash>
</Codenesium>*/