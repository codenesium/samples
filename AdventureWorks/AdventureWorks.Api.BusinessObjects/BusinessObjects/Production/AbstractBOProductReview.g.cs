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
	public abstract class AbstractBOProductReview: AbstractBOManager
	{
		private IProductReviewRepository productReviewRepository;
		private IApiProductReviewRequestModelValidator productReviewModelValidator;
		private IBOLProductReviewMapper productReviewMapper;
		private ILogger logger;

		public AbstractBOProductReview(
			ILogger logger,
			IProductReviewRepository productReviewRepository,
			IApiProductReviewRequestModelValidator productReviewModelValidator,
			IBOLProductReviewMapper productReviewMapper)
			: base()

		{
			this.productReviewRepository = productReviewRepository;
			this.productReviewModelValidator = productReviewModelValidator;
			this.productReviewMapper = productReviewMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductReviewResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.productReviewRepository.All(skip, take, orderClause);

			return this.productReviewMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiProductReviewResponseModel> Get(int productReviewID)
		{
			var record = await productReviewRepository.Get(productReviewID);

			return this.productReviewMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiProductReviewResponseModel>> Create(
			ApiProductReviewRequestModel model)
		{
			CreateResponse<ApiProductReviewResponseModel> response = new CreateResponse<ApiProductReviewResponseModel>(await this.productReviewModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.productReviewMapper.MapModelToDTO(default (int), model);
				var record = await this.productReviewRepository.Create(dto);

				response.SetRecord(this.productReviewMapper.MapDTOToModel(record));
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
				var dto = this.productReviewMapper.MapModelToDTO(productReviewID, model);
				await this.productReviewRepository.Update(productReviewID, dto);
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
			List<DTOProductReview> records = await this.productReviewRepository.GetCommentsProductIDReviewerName(comments,productID,reviewerName);

			return this.productReviewMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>48330e290045df1b534c00a0604ae84d</Hash>
</Codenesium>*/