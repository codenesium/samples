using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiBusinessEntityAddressModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityAddressModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityAddressModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8980e3f1ad05ec26dbf8a690d772c16f</Hash>
</Codenesium>*/