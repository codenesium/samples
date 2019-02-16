using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractProductSubcategoryService : AbstractService
	{
		private IMediator mediator;

		protected IProductSubcategoryRepository ProductSubcategoryRepository { get; private set; }

		protected IApiProductSubcategoryServerRequestModelValidator ProductSubcategoryModelValidator { get; private set; }

		protected IDALProductSubcategoryMapper DalProductSubcategoryMapper { get; private set; }

		protected IDALProductMapper DalProductMapper { get; private set; }

		private ILogger logger;

		public AbstractProductSubcategoryService(
			ILogger logger,
			IMediator mediator,
			IProductSubcategoryRepository productSubcategoryRepository,
			IApiProductSubcategoryServerRequestModelValidator productSubcategoryModelValidator,
			IDALProductSubcategoryMapper dalProductSubcategoryMapper,
			IDALProductMapper dalProductMapper)
			: base()
		{
			this.ProductSubcategoryRepository = productSubcategoryRepository;
			this.ProductSubcategoryModelValidator = productSubcategoryModelValidator;
			this.DalProductSubcategoryMapper = dalProductSubcategoryMapper;
			this.DalProductMapper = dalProductMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiProductSubcategoryServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			var records = await this.ProductSubcategoryRepository.All(limit, offset, query);

			return this.DalProductSubcategoryMapper.MapBOToModel(records);
		}

		public virtual async Task<ApiProductSubcategoryServerResponseModel> Get(int productSubcategoryID)
		{
			var record = await this.ProductSubcategoryRepository.Get(productSubcategoryID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalProductSubcategoryMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiProductSubcategoryServerResponseModel>> Create(
			ApiProductSubcategoryServerRequestModel model)
		{
			CreateResponse<ApiProductSubcategoryServerResponseModel> response = ValidationResponseFactory<ApiProductSubcategoryServerResponseModel>.CreateResponse(await this.ProductSubcategoryModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalProductSubcategoryMapper.MapModelToBO(default(int), model);
				var record = await this.ProductSubcategoryRepository.Create(bo);

				response.SetRecord(this.DalProductSubcategoryMapper.MapBOToModel(record));
				await this.mediator.Publish(new ProductSubcategoryCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProductSubcategoryServerResponseModel>> Update(
			int productSubcategoryID,
			ApiProductSubcategoryServerRequestModel model)
		{
			var validationResult = await this.ProductSubcategoryModelValidator.ValidateUpdateAsync(productSubcategoryID, model);

			if (validationResult.IsValid)
			{
				var bo = this.DalProductSubcategoryMapper.MapModelToBO(productSubcategoryID, model);
				await this.ProductSubcategoryRepository.Update(bo);

				var record = await this.ProductSubcategoryRepository.Get(productSubcategoryID);

				var apiModel = this.DalProductSubcategoryMapper.MapBOToModel(record);
				await this.mediator.Publish(new ProductSubcategoryUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiProductSubcategoryServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiProductSubcategoryServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int productSubcategoryID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ProductSubcategoryModelValidator.ValidateDeleteAsync(productSubcategoryID));

			if (response.Success)
			{
				await this.ProductSubcategoryRepository.Delete(productSubcategoryID);

				await this.mediator.Publish(new ProductSubcategoryDeletedNotification(productSubcategoryID));
			}

			return response;
		}

		public async virtual Task<ApiProductSubcategoryServerResponseModel> ByName(string name)
		{
			ProductSubcategory record = await this.ProductSubcategoryRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalProductSubcategoryMapper.MapBOToModel(record);
			}
		}

		public async virtual Task<ApiProductSubcategoryServerResponseModel> ByRowguid(Guid rowguid)
		{
			ProductSubcategory record = await this.ProductSubcategoryRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalProductSubcategoryMapper.MapBOToModel(record);
			}
		}

		public async virtual Task<List<ApiProductServerResponseModel>> ProductsByProductSubcategoryID(int productSubcategoryID, int limit = int.MaxValue, int offset = 0)
		{
			List<Product> records = await this.ProductSubcategoryRepository.ProductsByProductSubcategoryID(productSubcategoryID, limit, offset);

			return this.DalProductMapper.MapBOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>c9a57afed59a42baa92e1c965a881df1</Hash>
</Codenesium>*/