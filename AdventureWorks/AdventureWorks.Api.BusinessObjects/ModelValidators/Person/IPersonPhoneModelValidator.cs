using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IPersonPhoneModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(PersonPhoneModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, PersonPhoneModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a093477db155d1c06a0166491a7cf7d8</Hash>
</Codenesium>*/