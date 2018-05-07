using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBODocument
	{
		private IDocumentRepository documentRepository;
		private IDocumentModelValidator documentModelValidator;
		private ILogger logger;

		public AbstractBODocument(
			ILogger logger,
			IDocumentRepository documentRepository,
			IDocumentModelValidator documentModelValidator)

		{
			this.documentRepository = documentRepository;
			this.documentModelValidator = documentModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<Guid>> Create(
			DocumentModel model)
		{
			CreateResponse<Guid> response = new CreateResponse<Guid>(await this.documentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				Guid id = this.documentRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			Guid documentNode,
			DocumentModel model)
		{
			ActionResponse response = new ActionResponse(await this.documentModelValidator.ValidateUpdateAsync(documentNode, model));

			if (response.Success)
			{
				this.documentRepository.Update(documentNode, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			Guid documentNode)
		{
			ActionResponse response = new ActionResponse(await this.documentModelValidator.ValidateDeleteAsync(documentNode));

			if (response.Success)
			{
				this.documentRepository.Delete(documentNode);
			}
			return response;
		}

		public virtual POCODocument Get(Guid documentNode)
		{
			return this.documentRepository.Get(documentNode);
		}

		public virtual List<POCODocument> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.documentRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>057494abee201b22c6bbad03a14395f8</Hash>
</Codenesium>*/