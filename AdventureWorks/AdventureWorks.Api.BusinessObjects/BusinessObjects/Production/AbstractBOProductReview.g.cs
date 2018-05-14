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
		private IApiProductReviewModelValidator productReviewModelValidator;
		private ILogger logger;

		public AbstractBOProductReview(
			ILogger logger,
			IProductReviewRepository productReviewRepository,
			IApiProductReviewModelValidator productReviewModelValidator)

		{
			this.productReviewRepository = productReviewRepository;
			this.productReviewModelValidator = productReviewModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOProductReview> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productReviewRepository.All(skip, take, orderClause);
		}

		public virtual POCOProductReview Get(int productReviewID)
		{
			return this.productReviewRepository.Get(productReviewID);
		}

		public virtual async Task<CreateResponse<POCOProductReview>> Create(
			ApiProductReviewModel model)
		{
			CreateResponse<POCOProductReview> response = new CreateResponse<POCOProductReview>(await this.productReviewModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOProductReview record = this.productReviewRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productReviewID,
			ApiProductReviewModel model)
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

		public List<POCOProductReview> GetCommentsProductIDReviewerName(string comments,int productID,string reviewerName)
		{
			return this.productReviewRepository.GetCommentsProductIDReviewerName(comments,productID,reviewerName);
		}
	}
}

/*<Codenesium>
    <Hash>273cde89249894aeb08eab332c9a232a</Hash>
</Codenesium>*/