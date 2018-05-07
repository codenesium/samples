using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IPhoneNumberTypeModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(PhoneNumberTypeModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, PhoneNumberTypeModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ef23ef254df46733980c7419bfac48e6</Hash>
</Codenesium>*/