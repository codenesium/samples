using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiAddressModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAddressModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d2831e7bf652fa38a61ae9b355e5e2d1</Hash>
</Codenesium>*/