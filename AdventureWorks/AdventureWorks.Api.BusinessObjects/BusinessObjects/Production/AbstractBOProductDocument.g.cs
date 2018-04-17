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

		public virtual ApiResponse GetById(int productID)
		{
			return this.productDocumentRepository.GetById(productID);
		}

		public virtual POCOProductDocument GetByIdDirect(int productID)
		{
			return this.productDocumentRepository.GetByIdDirect(productID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productDocumentRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productDocumentRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOProductDocument> GetWhereDirect(Expression<Func<EFProductDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productDocumentRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>7fde95474b7faaedc7327fae1360c62a</Hash>
</Codenesium>*/