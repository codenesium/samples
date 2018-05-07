using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface ILinkModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(LinkModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, LinkModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f3aa667850c4152f9eb1c947b70d660c</Hash>
</Codenesium>*/