using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiDocumentModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDocumentModel model);
		Task<ValidationResult> ValidateUpdateAsync(Guid id, ApiDocumentModel model);
		Task<ValidationResult> ValidateDeleteAsync(Guid id);
	}
}

/*<Codenesium>
    <Hash>0e79d36e43d19576dd1d31c6ecf71ac0</Hash>
</Codenesium>*/