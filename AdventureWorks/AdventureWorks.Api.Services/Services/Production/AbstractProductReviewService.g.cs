using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractProductReviewService : AbstractService
	{
		protected IProductReviewRepository ProductReviewRepository { get; private set; }

		protected IApiProductReviewServerRequestModelValidator ProductReviewModelValidator { get; private set; }

		protected IBOLProductReviewMapper BolProductReviewMapper { get; private set; }

		protected IDALProductReviewMapper DalProductReviewMapper { get; private set; }

		private ILogger logger;

		public AbstractProductReviewService(
			ILogger logger,
			IProductReviewRepository productReviewRepository,
			IApiProductReviewServerRequestModelValidator productReviewModelValidator,
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

		public virtual async Task<List<ApiProductReviewServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ProductReviewRepository.All(limit, offset);

			return this.BolProductReviewMapper.MapBOToModel(this.DalProductReviewMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProductReviewServerResponseModel> Get(int productReviewID)
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

		public virtual async Task<CreateResponse<ApiProductReviewServerResponseModel>> Create(
			ApiProductReviewServerRequestModel model)
		{
			CreateResponse<ApiProductReviewServerResponseModel> response = ValidationResponseFactory<ApiProductReviewServerResponseModel>.CreateResponse(await this.ProductReviewModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolProductReviewMapper.MapModelToBO(default(int), model);
				var record = await this.ProductReviewRepository.Create(this.DalProductReviewMapper.MapBOToEF(bo));

				response.SetRecord(this.BolProductReviewMapper.MapBOToModel(this.DalProductReviewMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductReviewServerResponseModel>> Update(
			int productReviewID,
			ApiProductReviewServerRequestModel model)
		{
			var validationResult = await this.ProductReviewModelValidator.ValidateUpdateAsync(productReviewID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolProductReviewMapper.MapModelToBO(productReviewID, model);
				await this.ProductReviewRepository.Update(this.DalProductReviewMapper.MapBOToEF(bo));

				var record = await this.ProductReviewRepository.Get(productReviewID);

				return ValidationResponseFactory<ApiProductReviewServerResponseModel>.UpdateResponse(this.BolProductReviewMapper.MapBOToModel(this.DalProductReviewMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiProductReviewServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productReviewID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ProductReviewModelValidator.ValidateDeleteAsync(productReviewID));

			if (response.Success)
			{
				await this.ProductReviewRepository.Delete(productReviewID);
			}

			return response;
		}

		public async virtual Task<List<ApiProductReviewServerResponseModel>> ByProductIDReviewerName(int productID, string reviewerName, int limit = 0, int offset = int.MaxValue)
		{
			List<ProductReview> records = await this.ProductReviewRepository.ByProductIDReviewerName(productID, reviewerName, limit, offset);

			return this.BolProductReviewMapper.MapBOToModel(this.DalProductReviewMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>ba87beb4363d36ba29d789db816ca9c5</Hash>
</Codenesium>*/