using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IContactTypeModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ContactTypeModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ContactTypeModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>381701aa46eecb4398edaedac3e0a63d</Hash>
</Codenesium>*/