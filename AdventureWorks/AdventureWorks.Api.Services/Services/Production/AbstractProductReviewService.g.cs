using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractProductReviewService : AbstractService
	{
		private IMediator mediator;

		protected IProductReviewRepository ProductReviewRepository { get; private set; }

		protected IApiProductReviewServerRequestModelValidator ProductReviewModelValidator { get; private set; }

		protected IBOLProductReviewMapper BolProductReviewMapper { get; private set; }

		protected IDALProductReviewMapper DalProductReviewMapper { get; private set; }

		private ILogger logger;

		public AbstractProductReviewService(
			ILogger logger,
			IMediator mediator,
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

			this.mediator = mediator;
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

				var businessObject = this.DalProductReviewMapper.MapEFToBO(record);
				response.SetRecord(this.BolProductReviewMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new ProductReviewCreatedNotification(response.Record));
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

				var businessObject = this.DalProductReviewMapper.MapEFToBO(record);
				var apiModel = this.BolProductReviewMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new ProductReviewUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiProductReviewServerResponseModel>.UpdateResponse(apiModel);
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

				await this.mediator.Publish(new ProductReviewDeletedNotification(productReviewID));
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
    <Hash>9a9f9c2223af02bd64615c3d42a03597</Hash>
</Codenesium>*/