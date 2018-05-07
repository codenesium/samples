using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IEmailAddressModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(EmailAddressModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, EmailAddressModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5bfb8c3443f1479c2abcc97085c456d4</Hash>
</Codenesium>*/