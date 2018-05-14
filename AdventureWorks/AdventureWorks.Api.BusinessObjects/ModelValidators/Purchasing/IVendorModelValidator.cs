using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiVendorModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiVendorModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiVendorModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>432933974fd007d0bf73e807551edb34</Hash>
</Codenesium>*/