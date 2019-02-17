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

		protected IDALVendorMapper DalVendorMapper { get; private set; }

		protected IDALPurchaseOrderHeaderMapper DalPurchaseOrderHeaderMapper { get; private set; }

		private ILogger logger;

		public AbstractVendorService(
			ILogger logger,
			IMediator mediator,
			IVendorRepository vendorRepository,
			IApiVendorServerRequestModelValidator vendorModelValidator,
			IDALVendorMapper dalVendorMapper,
			IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper)
			: base()
		{
			this.VendorRepository = vendorRepository;
			this.VendorModelValidator = vendorModelValidator;
			this.DalVendorMapper = dalVendorMapper;
			this.DalPurchaseOrderHeaderMapper = dalPurchaseOrderHeaderMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiVendorServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Vendor> records = await this.VendorRepository.All(limit, offset, query);

			return this.DalVendorMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiVendorServerResponseModel> Get(int businessEntityID)
		{
			Vendor record = await this.VendorRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalVendorMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiVendorServerResponseModel>> Create(
			ApiVendorServerRequestModel model)
		{
			CreateResponse<ApiVendorServerResponseModel> response = ValidationResponseFactory<ApiVendorServerResponseModel>.CreateResponse(await this.VendorModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Vendor record = this.DalVendorMapper.MapModelToEntity(default(int), model);
				record = await this.VendorRepository.Create(record);

				response.SetRecord(this.DalVendorMapper.MapEntityToModel(record));
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
				Vendor record = this.DalVendorMapper.MapModelToEntity(businessEntityID, model);
				await this.VendorRepository.Update(record);

				record = await this.VendorRepository.Get(businessEntityID);

				ApiVendorServerResponseModel apiModel = this.DalVendorMapper.MapEntityToModel(record);
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
				return this.DalVendorMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<List<ApiPurchaseOrderHeaderServerResponseModel>> PurchaseOrderHeadersByVendorID(int vendorID, int limit = int.MaxValue, int offset = 0)
		{
			List<PurchaseOrderHeader> records = await this.VendorRepository.PurchaseOrderHeadersByVendorID(vendorID, limit, offset);

			return this.DalPurchaseOrderHeaderMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>dc33551beee722a03d7ab141ffc44452</Hash>
</Codenesium>*/