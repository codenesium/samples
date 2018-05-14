using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IApiLinkModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>85626f5059acbe1f7d8ab62d1010fa50</Hash>
</Codenesium>*/