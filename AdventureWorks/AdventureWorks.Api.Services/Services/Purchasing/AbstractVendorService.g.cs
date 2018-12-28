using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractVendorService : AbstractService
	{
		private IMediator mediator;

		protected IVendorRepository VendorRepository { get; private set; }

		protected IApiVendorServerRequestModelValidator VendorModelValidator { get; private set; }

		protected IBOLVendorMapper BolVendorMapper { get; private set; }

		protected IDALVendorMapper DalVendorMapper { get; private set; }

		protected IBOLPurchaseOrderHeaderMapper BolPurchaseOrderHeaderMapper { get; private set; }

		protected IDALPurchaseOrderHeaderMapper DalPurchaseOrderHeaderMapper { get; private set; }

		private ILogger logger;

		public AbstractVendorService(
			ILogger logger,
			IMediator mediator,
			IVendorRepository vendorRepository,
			IApiVendorServerRequestModelValidator vendorModelValidator,
			IBOLVendorMapper bolVendorMapper,
			IDALVendorMapper dalVendorMapper,
			IBOLPurchaseOrderHeaderMapper bolPurchaseOrderHeaderMapper,
			IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper)
			: base()
		{
			this.VendorRepository = vendorRepository;
			this.VendorModelValidator = vendorModelValidator;
			this.BolVendorMapper = bolVendorMapper;
			this.DalVendorMapper = dalVendorMapper;
			this.BolPurchaseOrderHeaderMapper = bolPurchaseOrderHeaderMapper;
			this.DalPurchaseOrderHeaderMapper = dalPurchaseOrderHeaderMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiVendorServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.VendorRepository.All(limit, offset);

			return this.BolVendorMapper.MapBOToModel(this.DalVendorMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVendorServerResponseModel> Get(int businessEntityID)
		{
			var record = await this.VendorRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVendorMapper.MapBOToModel(this.DalVendorMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiVendorServerResponseModel>> Create(
			ApiVendorServerRequestModel model)
		{
			CreateResponse<ApiVendorServerResponseModel> response = ValidationResponseFactory<ApiVendorServerResponseModel>.CreateResponse(await this.VendorModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolVendorMapper.MapModelToBO(default(int), model);
				var record = await this.VendorRepository.Create(this.DalVendorMapper.MapBOToEF(bo));

				var businessObject = this.DalVendorMapper.MapEFToBO(record);
				response.SetRecord(this.BolVendorMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new VendorCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVendorServerResponseModel>> Update(
			int businessEntityID,
			ApiVendorServerRequestModel model)
		{
			var validationResult = await this.VendorModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolVendorMapper.MapModelToBO(businessEntityID, model);
				await this.VendorRepository.Update(this.DalVendorMapper.MapBOToEF(bo));

				var record = await this.VendorRepository.Get(businessEntityID);

				var businessObject = this.DalVendorMapper.MapEFToBO(record);
				var apiModel = this.BolVendorMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new VendorUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiVendorServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiVendorServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.VendorModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.VendorRepository.Delete(businessEntityID);

				await this.mediator.Publish(new VendorDeletedNotification(businessEntityID));
			}

			return response;
		}

		public async virtual Task<ApiVendorServerResponseModel> ByAccountNumber(string accountNumber)
		{
			Vendor record = await this.VendorRepository.ByAccountNumber(accountNumber);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVendorMapper.MapBOToModel(this.DalVendorMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiPurchaseOrderHeaderServerResponseModel>> PurchaseOrderHeadersByVendorID(int vendorID, int limit = int.MaxValue, int offset = 0)
		{
			List<PurchaseOrderHeader> records = await this.VendorRepository.PurchaseOrderHeadersByVendorID(vendorID, limit, offset);

			return this.BolPurchaseOrderHeaderMapper.MapBOToModel(this.DalPurchaseOrderHeaderMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>9c6adbe1b1cad39172c49c0e8f26ded9</Hash>
</Codenesium>*/