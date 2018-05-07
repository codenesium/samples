using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface ILinkStatusModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(LinkStatusModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, LinkStatusModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e6abdd8575098256749876ae8d3e9d83</Hash>
</Codenesium>*/