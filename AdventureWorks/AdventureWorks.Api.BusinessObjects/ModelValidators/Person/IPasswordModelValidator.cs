using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IPasswordModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(PasswordModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, PasswordModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b2a9161d18e466113e997b343d524586</Hash>
</Codenesium>*/