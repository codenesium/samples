using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IEmailAddressModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(EmailAddressModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, EmailAddressModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>61886fa1432b3c943dafd75b49175170</Hash>
</Codenesium>*/