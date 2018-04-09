using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IDocumentModelValidator
	{
		ValidationResult Validate(DocumentModel entity);

		Task<ValidationResult> ValidateAsync(DocumentModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>508a31cef64a5232b52cd47bcd4f514a</Hash>
</Codenesium>*/