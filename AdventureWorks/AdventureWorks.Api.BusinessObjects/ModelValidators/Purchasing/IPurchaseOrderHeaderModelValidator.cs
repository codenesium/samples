using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiPurchaseOrderHeaderModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPurchaseOrderHeaderModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPurchaseOrderHeaderModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8f3d14cb0e221f3fb0729b130cd29ca7</Hash>
</Codenesium>*/