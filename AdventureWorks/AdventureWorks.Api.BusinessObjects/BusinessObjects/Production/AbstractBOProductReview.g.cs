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
	public abstract class AbstractBOProductReview
	{
		private IProductReviewRepository productReviewRepository;
		private IProductReviewModelValidator productReviewModelValidator;
		private ILogger logger;

		public AbstractBOProductReview(
			ILogger logger,
			IProductReviewRepository productReviewRepository,
			IProductReviewModelValidator productReviewModelValidator)

		{
			this.productReviewRepository = productReviewRepository;
			this.productReviewModelValidator = productReviewModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ProductReviewModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.productReviewModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.productReviewRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productReviewID,
			ProductReviewModel model)
		{
			ActionResponse response = new ActionResponse(await this.productReviewModelValidator.ValidateUpdateAsync(productReviewID, model));

			if (response.Success)
			{
				this.productReviewRepository.Update(productReviewID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productReviewID)
		{
			ActionResponse response = new ActionResponse(await this.productReviewModelValidator.ValidateDeleteAsync(productReviewID));

			if (response.Success)
			{
				this.productReviewRepository.Delete(productReviewID);
			}
			return response;
		}

		public virtual ApiResponse GetById(int productReviewID)
		{
			return this.productReviewRepository.GetById(productReviewID);
		}

		public virtual POCOProductReview GetByIdDirect(int productReviewID)
		{
			return this.productReviewRepository.GetByIdDirect(productReviewID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductReview, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productReviewRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productReviewRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOProductReview> GetWhereDirect(Expression<Func<EFProductReview, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productReviewRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>62a99d46dc45dd4e372a902a7ef238eb</Hash>
</Codenesium>*/