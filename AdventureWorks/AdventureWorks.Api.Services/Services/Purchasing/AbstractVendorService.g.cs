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
	public abstract class AbstractVendorService : AbstractService
	{
		protected IVendorRepository VendorRepository { get; private set; }

		protected IApiVendorRequestModelValidator VendorModelValidator { get; private set; }

		protected IBOLVendorMapper BolVendorMapper { get; private set; }

		protected IDALVendorMapper DalVendorMapper { get; private set; }

		protected IBOLProductVendorMapper BolProductVendorMapper { get; private set; }

		protected IDALProductVendorMapper DalProductVendorMapper { get; private set; }

		protected IBOLPurchaseOrderHeaderMapper BolPurchaseOrderHeaderMapper { get; private set; }

		protected IDALPurchaseOrderHeaderMapper DalPurchaseOrderHeaderMapper { get; private set; }

		private ILogger logger;

		public AbstractVendorService(
			ILogger logger,
			IVendorRepository vendorRepository,
			IApiVendorRequestModelValidator vendorModelValidator,
			IBOLVendorMapper bolVendorMapper,
			IDALVendorMapper dalVendorMapper,
			IBOLProductVendorMapper bolProductVendorMapper,
			IDALProductVendorMapper dalProductVendorMapper,
			IBOLPurchaseOrderHeaderMapper bolPurchaseOrderHeaderMapper,
			IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper)
			: base()
		{
			this.VendorRepository = vendorRepository;
			this.VendorModelValidator = vendorModelValidator;
			this.BolVendorMapper = bolVendorMapper;
			this.DalVendorMapper = dalVendorMapper;
			this.BolProductVendorMapper = bolProductVendorMapper;
			this.DalProductVendorMapper = dalProductVendorMapper;
			this.BolPurchaseOrderHeaderMapper = bolPurchaseOrderHeaderMapper;
			this.DalPurchaseOrderHeaderMapper = dalPurchaseOrderHeaderMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiVendorResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.VendorRepository.All(limit, offset);

			return this.BolVendorMapper.MapBOToModel(this.DalVendorMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVendorResponseModel> Get(int businessEntityID)
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

		public virtual async Task<CreateResponse<ApiVendorResponseModel>> Create(
			ApiVendorRequestModel model)
		{
			CreateResponse<ApiVendorResponseModel> response = new CreateResponse<ApiVendorResponseModel>(await this.VendorModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolVendorMapper.MapModelToBO(default(int), model);
				var record = await this.VendorRepository.Create(this.DalVendorMapper.MapBOToEF(bo));

				response.SetRecord(this.BolVendorMapper.MapBOToModel(this.DalVendorMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVendorResponseModel>> Update(
			int businessEntityID,
			ApiVendorRequestModel model)
		{
			var validationResult = await this.VendorModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolVendorMapper.MapModelToBO(businessEntityID, model);
				await this.VendorRepository.Update(this.DalVendorMapper.MapBOToEF(bo));

				var record = await this.VendorRepository.Get(businessEntityID);

				return new UpdateResponse<ApiVendorResponseModel>(this.BolVendorMapper.MapBOToModel(this.DalVendorMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiVendorResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.VendorModelValidator.ValidateDeleteAsync(businessEntityID));
			if (response.Success)
			{
				await this.VendorRepository.Delete(businessEntityID);
			}

			return response;
		}

		public async Task<ApiVendorResponseModel> ByAccountNumber(string accountNumber)
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

		public async virtual Task<List<ApiProductVendorResponseModel>> ProductVendorsByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductVendor> records = await this.VendorRepository.ProductVendorsByBusinessEntityID(businessEntityID, limit, offset);

			return this.BolProductVendorMapper.MapBOToModel(this.DalProductVendorMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiPurchaseOrderHeaderResponseModel>> PurchaseOrderHeadersByVendorID(int vendorID, int limit = int.MaxValue, int offset = 0)
		{
			List<PurchaseOrderHeader> records = await this.VendorRepository.PurchaseOrderHeadersByVendorID(vendorID, limit, offset);

			return this.BolPurchaseOrderHeaderMapper.MapBOToModel(this.DalPurchaseOrderHeaderMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>fc7c11aa8be4764723023c7a02a26015</Hash>
</Codenesium>*/