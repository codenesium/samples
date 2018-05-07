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
		private IProductDocumentModelValidator productDocumentModelValidator;
		private ILogger logger;

		public AbstractBOProductDocument(
			ILogger logger,
			IProductDocumentRepository productDocumentRepository,
			IProductDocumentModelValidator productDocumentModelValidator)

		{
			this.productDocumentRepository = productDocumentRepository;
			this.productDocumentModelValidator = productDocumentModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ProductDocumentModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.productDocumentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.productDocumentRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productID,
			ProductDocumentModel model)
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

		public virtual POCOProductDocument Get(int productID)
		{
			return this.productDocumentRepository.Get(productID);
		}

		public virtual List<POCOProductDocument> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productDocumentRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>2dc50f18fe6d702f8d677df41c0a26cc</Hash>
</Codenesium>*/