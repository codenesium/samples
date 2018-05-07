using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ISalesPersonModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(SalesPersonModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, SalesPersonModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8b0a39fa507ab5ae269e6dcfabe157a2</Hash>
</Codenesium>*/