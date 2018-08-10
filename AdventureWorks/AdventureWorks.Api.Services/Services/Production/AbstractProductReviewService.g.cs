using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractProductReviewService : AbstractService
	{
		protected IProductReviewRepository ProductReviewRepository { get; private set; }

		protected IApiProductReviewRequestModelValidator ProductReviewModelValidator { get; private set; }

		protected IBOLProductReviewMapper BolProductReviewMapper { get; private set; }

		protected IDALProductReviewMapper DalProductReviewMapper { get; private set; }

		private ILogger logger;

		public AbstractProductReviewService(
			ILogger logger,
			IProductReviewRepository productReviewRepository,
			IApiProductReviewRequestModelValidator productReviewModelValidator,
			IBOLProductReviewMapper bolProductReviewMapper,
			IDALProductReviewMapper dalProductReviewMapper)
			: base()
		{
			this.ProductReviewRepository = productReviewRepository;
			this.ProductReviewModelValidator = productReviewModelValidator;
			this.BolProductReviewMapper = bolProductReviewMapper;
			this.DalProductReviewMapper = dalProductReviewMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProductReviewResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProductReviewRepository.All(limit, offset);

			return this.BolProductReviewMapper.MapBOToModel(this.DalProductReviewMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductReviewResponseModel> Get(int productReviewID)
		{
			var record = await this.ProductReviewRepository.Get(productReviewID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolProductReviewMapper.MapBOToModel(this.DalProductReviewMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProductReviewResponseModel>> Create(
			ApiProductReviewRequestModel model)
		{
			CreateResponse<ApiProductReviewResponseModel> response = new CreateResponse<ApiProductReviewResponseModel>(await this.ProductReviewModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolProductReviewMapper.MapModelToBO(default(int), model);
				var record = await this.ProductReviewRepository.Create(this.DalProductReviewMapper.MapBOToEF(bo));

				response.SetRecord(this.BolProductReviewMapper.MapBOToModel(this.DalProductReviewMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductReviewResponseModel>> Update(
			int productReviewID,
			ApiProductReviewRequestModel model)
		{
			var validationResult = await this.ProductReviewModelValidator.ValidateUpdateAsync(productReviewID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProductReviewMapper.MapModelToBO(productReviewID, model);
				await this.ProductReviewRepository.Update(this.DalProductReviewMapper.MapBOToEF(bo));

				var record = await this.ProductReviewRepository.Get(productReviewID);

				return new UpdateResponse<ApiProductReviewResponseModel>(this.BolProductReviewMapper.MapBOToModel(this.DalProductReviewMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiProductReviewResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productReviewID)
		{
			ActionResponse response = new ActionResponse(await this.ProductReviewModelValidator.ValidateDeleteAsync(productReviewID));
			if (response.Success)
			{
				await this.ProductReviewRepository.Delete(productReviewID);
			}

			return response;
		}

		public async Task<List<ApiProductReviewResponseModel>> ByProductIDReviewerName(int productID, string reviewerName)
		{
			List<ProductReview> records = await this.ProductReviewRepository.ByProductIDReviewerName(productID, reviewerName);

			return this.BolProductReviewMapper.MapBOToModel(this.DalProductReviewMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>5bdb55a182b8a05d30013e33608f7645</Hash>
</Codenesium>*/