using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ILocationModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(LocationModel model);
		Task<ValidationResult> ValidateUpdateAsync(short id, LocationModel model);
		Task<ValidationResult> ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>b3378a2e83bb5b49b436cda773df48dd</Hash>
</Codenesium>*/