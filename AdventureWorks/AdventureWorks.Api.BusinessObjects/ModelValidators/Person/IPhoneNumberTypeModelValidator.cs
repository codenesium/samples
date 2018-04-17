using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IPhoneNumberTypeModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(PhoneNumberTypeModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, PhoneNumberTypeModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>70800a72dfaf6c384a84d3c9f01a6277</Hash>
</Codenesium>*/