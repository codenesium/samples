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
	public abstract class AbstractBOProductDocument
	{
		private IProductDocumentRepository productDocumentRepository;
		private IApiProductDocumentModelValidator productDocumentModelValidator;
		private ILogger logger;

		public AbstractBOProductDocument(
			ILogger logger,
			IProductDocumentRepository productDocumentRepository,
			IApiProductDocumentModelValidator productDocumentModelValidator)

		{
			this.productDocumentRepository = productDocumentRepository;
			this.productDocumentModelValidator = productDocumentModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOProductDocument> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productDocumentRepository.All(skip, take, orderClause);
		}

		public virtual POCOProductDocument Get(int productID)
		{
			return this.productDocumentRepository.Get(productID);
		}

		public virtual async Task<CreateResponse<POCOProductDocument>> Create(
			ApiProductDocumentModel model)
		{
			CreateResponse<POCOProductDocument> response = new CreateResponse<POCOProductDocument>(await this.productDocumentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOProductDocument record = this.productDocumentRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productID,
			ApiProductDocumentModel model)
		{
			ActionResponse response = new ActionResponse(await this.productDocumentModelValidator.ValidateUpdateAsync(productID, model));

			if (response.Success)
			{
				this.productDocumentRepository.Update(productID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.productDocumentModelValidator.ValidateDeleteAsync(productID));

			if (response.Success)
			{
				this.productDocumentRepository.Delete(productID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fbebdce5bf7bd226053e7a59ea500b9e</Hash>
</Codenesium>*/