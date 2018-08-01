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
	public abstract class AbstractShipMethodService : AbstractService
	{
		private IShipMethodRepository shipMethodRepository;

		private IApiShipMethodRequestModelValidator shipMethodModelValidator;

		private IBOLShipMethodMapper bolShipMethodMapper;

		private IDALShipMethodMapper dalShipMethodMapper;

		private IBOLPurchaseOrderHeaderMapper bolPurchaseOrderHeaderMapper;

		private IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper;

		private ILogger logger;

		public AbstractShipMethodService(
			ILogger logger,
			IShipMethodRepository shipMethodRepository,
			IApiShipMethodRequestModelValidator shipMethodModelValidator,
			IBOLShipMethodMapper bolShipMethodMapper,
			IDALShipMethodMapper dalShipMethodMapper,
			IBOLPurchaseOrderHeaderMapper bolPurchaseOrderHeaderMapper,
			IDALPurchaseOrderHeaderMapper dalPurchaseOrderHeaderMapper)
			: base()
		{
			this.shipMethodRepository = shipMethodRepository;
			this.shipMethodModelValidator = shipMethodModelValidator;
			this.bolShipMethodMapper = bolShipMethodMapper;
			this.dalShipMethodMapper = dalShipMethodMapper;
			this.bolPurchaseOrderHeaderMapper = bolPurchaseOrderHeaderMapper;
			this.dalPurchaseOrderHeaderMapper = dalPurchaseOrderHeaderMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiShipMethodResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.shipMethodRepository.All(limit, offset);

			return this.bolShipMethodMapper.MapBOToModel(this.dalShipMethodMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiShipMethodResponseModel> Get(int shipMethodID)
		{
			var record = await this.shipMethodRepository.Get(shipMethodID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolShipMethodMapper.MapBOToModel(this.dalShipMethodMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiShipMethodResponseModel>> Create(
			ApiShipMethodRequestModel model)
		{
			CreateResponse<ApiShipMethodResponseModel> response = new CreateResponse<ApiShipMethodResponseModel>(await this.shipMethodModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolShipMethodMapper.MapModelToBO(default(int), model);
				var record = await this.shipMethodRepository.Create(this.dalShipMethodMapper.MapBOToEF(bo));

				response.SetRecord(this.bolShipMethodMapper.MapBOToModel(this.dalShipMethodMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiShipMethodResponseModel>> Update(
			int shipMethodID,
			ApiShipMethodRequestModel model)
		{
			var validationResult = await this.shipMethodModelValidator.ValidateUpdateAsync(shipMethodID, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolShipMethodMapper.MapModelToBO(shipMethodID, model);
				await this.shipMethodRepository.Update(this.dalShipMethodMapper.MapBOToEF(bo));

				var record = await this.shipMethodRepository.Get(shipMethodID);

				return new UpdateResponse<ApiShipMethodResponseModel>(this.bolShipMethodMapper.MapBOToModel(this.dalShipMethodMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiShipMethodResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int shipMethodID)
		{
			ActionResponse response = new ActionResponse(await this.shipMethodModelValidator.ValidateDeleteAsync(shipMethodID));
			if (response.Success)
			{
				await this.shipMethodRepository.Delete(shipMethodID);
			}

			return response;
		}

		public async Task<ApiShipMethodResponseModel> ByName(string name)
		{
			ShipMethod record = await this.shipMethodRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolShipMethodMapper.MapBOToModel(this.dalShipMethodMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiPurchaseOrderHeaderResponseModel>> PurchaseOrderHeaders(int shipMethodID, int limit = int.MaxValue, int offset = 0)
		{
			List<PurchaseOrderHeader> records = await this.shipMethodRepository.PurchaseOrderHeaders(shipMethodID, limit, offset);

			return this.bolPurchaseOrderHeaderMapper.MapBOToModel(this.dalPurchaseOrderHeaderMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>078cce11c71262b6abf65c922c6afa89</Hash>
</Codenesium>*/