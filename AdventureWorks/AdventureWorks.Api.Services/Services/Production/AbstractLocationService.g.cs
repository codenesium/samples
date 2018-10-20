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
	public abstract class AbstractLocationService : AbstractService
	{
		protected ILocationRepository LocationRepository { get; private set; }

		protected IApiLocationRequestModelValidator LocationModelValidator { get; private set; }

		protected IBOLLocationMapper BolLocationMapper { get; private set; }

		protected IDALLocationMapper DalLocationMapper { get; private set; }

		protected IBOLProductInventoryMapper BolProductInventoryMapper { get; private set; }

		protected IDALProductInventoryMapper DalProductInventoryMapper { get; private set; }

		protected IBOLWorkOrderRoutingMapper BolWorkOrderRoutingMapper { get; private set; }

		protected IDALWorkOrderRoutingMapper DalWorkOrderRoutingMapper { get; private set; }

		private ILogger logger;

		public AbstractLocationService(
			ILogger logger,
			ILocationRepository locationRepository,
			IApiLocationRequestModelValidator locationModelValidator,
			IBOLLocationMapper bolLocationMapper,
			IDALLocationMapper dalLocationMapper,
			IBOLProductInventoryMapper bolProductInventoryMapper,
			IDALProductInventoryMapper dalProductInventoryMapper,
			IBOLWorkOrderRoutingMapper bolWorkOrderRoutingMapper,
			IDALWorkOrderRoutingMapper dalWorkOrderRoutingMapper)
			: base()
		{
			this.LocationRepository = locationRepository;
			this.LocationModelValidator = locationModelValidator;
			this.BolLocationMapper = bolLocationMapper;
			this.DalLocationMapper = dalLocationMapper;
			this.BolProductInventoryMapper = bolProductInventoryMapper;
			this.DalProductInventoryMapper = dalProductInventoryMapper;
			this.BolWorkOrderRoutingMapper = bolWorkOrderRoutingMapper;
			this.DalWorkOrderRoutingMapper = dalWorkOrderRoutingMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLocationResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.LocationRepository.All(limit, offset);

			return this.BolLocationMapper.MapBOToModel(this.DalLocationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLocationResponseModel> Get(short locationID)
		{
			var record = await this.LocationRepository.Get(locationID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLocationMapper.MapBOToModel(this.DalLocationMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiLocationResponseModel>> Create(
			ApiLocationRequestModel model)
		{
			CreateResponse<ApiLocationResponseModel> response = new CreateResponse<ApiLocationResponseModel>(await this.LocationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolLocationMapper.MapModelToBO(default(short), model);
				var record = await this.LocationRepository.Create(this.DalLocationMapper.MapBOToEF(bo));

				response.SetRecord(this.BolLocationMapper.MapBOToModel(this.DalLocationMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLocationResponseModel>> Update(
			short locationID,
			ApiLocationRequestModel model)
		{
			var validationResult = await this.LocationModelValidator.ValidateUpdateAsync(locationID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolLocationMapper.MapModelToBO(locationID, model);
				await this.LocationRepository.Update(this.DalLocationMapper.MapBOToEF(bo));

				var record = await this.LocationRepository.Get(locationID);

				return new UpdateResponse<ApiLocationResponseModel>(this.BolLocationMapper.MapBOToModel(this.DalLocationMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiLocationResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			short locationID)
		{
			ActionResponse response = new ActionResponse(await this.LocationModelValidator.ValidateDeleteAsync(locationID));
			if (response.Success)
			{
				await this.LocationRepository.Delete(locationID);
			}

			return response;
		}

		public async Task<ApiLocationResponseModel> ByName(string name)
		{
			Location record = await this.LocationRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLocationMapper.MapBOToModel(this.DalLocationMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiProductInventoryResponseModel>> ProductInventoriesByLocationID(short locationID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductInventory> records = await this.LocationRepository.ProductInventoriesByLocationID(locationID, limit, offset);

			return this.BolProductInventoryMapper.MapBOToModel(this.DalProductInventoryMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutingsByLocationID(short locationID, int limit = int.MaxValue, int offset = 0)
		{
			List<WorkOrderRouting> records = await this.LocationRepository.WorkOrderRoutingsByLocationID(locationID, limit, offset);

			return this.BolWorkOrderRoutingMapper.MapBOToModel(this.DalWorkOrderRoutingMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>c8f172dd910e3f832caf340249d4efee</Hash>
</Codenesium>*/