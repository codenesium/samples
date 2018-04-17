using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IPasswordModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(PasswordModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, PasswordModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>deace13aabc6b27fd4b2a52e0c4259ac</Hash>
</Codenesium>*/