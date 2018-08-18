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
		protected IShipMethodRepository ShipMethodRepository { get; private set; }

		protected IApiShipMethodRequestModelValidator ShipMethodModelValidator { get; private set; }

		protected IBOLShipMethodMapper BolShipMethodMapper { get; private set; }

		protected IDALShipMethodMapper DalShipMethodMapper { get; private set; }

		protected IBOLPurchaseOrderHeaderMapper BolPurchaseOrderHeaderMapper { get; private set; }

		protected IDALPurchaseOrderHeaderMapper DalPurchaseOrderHeaderMapper { get; private set; }

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
			this.ShipMethodRepository = shipMethodRepository;
			this.ShipMethodModelValidator = shipMethodModelValidator;
			this.BolShipMethodMapper = bolShipMethodMapper;
			this.DalShipMethodMapper = dalShipMethodMapper;
			this.BolPurchaseOrderHeaderMapper = bolPurchaseOrderHeaderMapper;
			this.DalPurchaseOrderHeaderMapper = dalPurchaseOrderHeaderMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiShipMethodResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ShipMethodRepository.All(limit, offset);

			return this.BolShipMethodMapper.MapBOToModel(this.DalShipMethodMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiShipMethodResponseModel> Get(int shipMethodID)
		{
			var record = await this.ShipMethodRepository.Get(shipMethodID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolShipMethodMapper.MapBOToModel(this.DalShipMethodMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiShipMethodResponseModel>> Create(
			ApiShipMethodRequestModel model)
		{
			CreateResponse<ApiShipMethodResponseModel> response = new CreateResponse<ApiShipMethodResponseModel>(await this.ShipMethodModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolShipMethodMapper.MapModelToBO(default(int), model);
				var record = await this.ShipMethodRepository.Create(this.DalShipMethodMapper.MapBOToEF(bo));

				response.SetRecord(this.BolShipMethodMapper.MapBOToModel(this.DalShipMethodMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiShipMethodResponseModel>> Update(
			int shipMethodID,
			ApiShipMethodRequestModel model)
		{
			var validationResult = await this.ShipMethodModelValidator.ValidateUpdateAsync(shipMethodID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolShipMethodMapper.MapModelToBO(shipMethodID, model);
				await this.ShipMethodRepository.Update(this.DalShipMethodMapper.MapBOToEF(bo));

				var record = await this.ShipMethodRepository.Get(shipMethodID);

				return new UpdateResponse<ApiShipMethodResponseModel>(this.BolShipMethodMapper.MapBOToModel(this.DalShipMethodMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiShipMethodResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int shipMethodID)
		{
			ActionResponse response = new ActionResponse(await this.ShipMethodModelValidator.ValidateDeleteAsync(shipMethodID));
			if (response.Success)
			{
				await this.ShipMethodRepository.Delete(shipMethodID);
			}

			return response;
		}

		public async Task<ApiShipMethodResponseModel> ByName(string name)
		{
			ShipMethod record = await this.ShipMethodRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolShipMethodMapper.MapBOToModel(this.DalShipMethodMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiPurchaseOrderHeaderResponseModel>> PurchaseOrderHeaders(int shipMethodID, int limit = int.MaxValue, int offset = 0)
		{
			List<PurchaseOrderHeader> records = await this.ShipMethodRepository.PurchaseOrderHeaders(shipMethodID, limit, offset);

			return this.BolPurchaseOrderHeaderMapper.MapBOToModel(this.DalPurchaseOrderHeaderMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>b66b4bf36a9bb88ec2fc4ccaa6f6755e</Hash>
</Codenesium>*/