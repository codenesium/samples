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

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractProductReviewService: AbstractService
	{
		private IProductReviewRepository productReviewRepository;
		private IApiProductReviewRequestModelValidator productReviewModelValidator;
		private IBOLProductReviewMapper BOLProductReviewMapper;
		private IDALProductReviewMapper DALProductReviewMapper;
		private ILogger logger;

		public AbstractProductReviewService(
			ILogger logger,
			IProductReviewRepository productReviewRepository,
			IApiProductReviewRequestModelValidator productReviewModelValidator,
			IBOLProductReviewMapper bolproductReviewMapper,
			IDALProductReviewMapper dalproductReviewMapper)
			: base()

		{
			this.productReviewRepository = productReviewRepository;
			this.productReviewModelValidator = productReviewModelValidator;
			this.BOLProductReviewMapper = bolproductReviewMapper;
			this.DALProductReviewMapper = dalproductReviewMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductReviewResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productReviewRepository.All(skip, take, orderClause);

			return this.BOLProductReviewMapper.MapBOToModel(this.DALProductReviewMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductReviewResponseModel> Get(int productReviewID)
		{
			var record = await productReviewRepository.Get(productReviewID);

			return this.BOLProductReviewMapper.MapBOToModel(this.DALProductReviewMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiProductReviewResponseModel>> Create(
			ApiProductReviewRequestModel model)
		{
			CreateResponse<ApiProductReviewResponseModel> response = new CreateResponse<ApiProductReviewResponseModel>(await this.productReviewModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLProductReviewMapper.MapModelToBO(default (int), model);
				var record = await this.productReviewRepository.Create(this.DALProductReviewMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLProductReviewMapper.MapBOToModel(this.DALProductReviewMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productReviewID,
			ApiProductReviewRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.productReviewModelValidator.ValidateUpdateAsync(productReviewID, model));

			if (response.Success)
			{
				var bo = this.BOLProductReviewMapper.MapModelToBO(productReviewID, model);
				await this.productReviewRepository.Update(this.DALProductReviewMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productReviewID)
		{
			ActionResponse response = new ActionResponse(await this.productReviewModelValidator.ValidateDeleteAsync(productReviewID));

			if (response.Success)
			{
				await this.productReviewRepository.Delete(productReviewID);
			}
			return response;
		}

		public async Task<List<ApiProductReviewResponseModel>> GetCommentsProductIDReviewerName(string comments,int productID,string reviewerName)
		{
			List<ProductReview> records = await this.productReviewRepository.GetCommentsProductIDReviewerName(comments,productID,reviewerName);

			return this.BOLProductReviewMapper.MapBOToModel(this.DALProductReviewMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>b17ef1817c10f8bbb69150f96930c62e</Hash>
</Codenesium>*/