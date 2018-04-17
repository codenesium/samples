using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IPersonPhoneModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(PersonPhoneModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, PersonPhoneModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4654053b819ce1aba499fa27aa33f0cb</Hash>
</Codenesium>*/