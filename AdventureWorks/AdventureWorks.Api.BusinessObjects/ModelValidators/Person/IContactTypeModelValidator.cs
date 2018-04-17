using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IContactTypeModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ContactTypeModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ContactTypeModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>dd8d3a2284e9448e133277646028103b</Hash>
</Codenesium>*/