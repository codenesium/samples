using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ICultureModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(CultureModel model);
		Task<ValidationResult> ValidateUpdateAsync(string id, CultureModel model);
		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>fa5bf6ecd59e8ee6ece71ebd3863c198</Hash>
</Codenesium>*/