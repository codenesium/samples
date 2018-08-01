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
		private ILocationRepository locationRepository;

		private IApiLocationRequestModelValidator locationModelValidator;

		private IBOLLocationMapper bolLocationMapper;

		private IDALLocationMapper dalLocationMapper;

		private IBOLProductInventoryMapper bolProductInventoryMapper;

		private IDALProductInventoryMapper dalProductInventoryMapper;
		private IBOLWorkOrderRoutingMapper bolWorkOrderRoutingMapper;

		private IDALWorkOrderRoutingMapper dalWorkOrderRoutingMapper;

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
			this.locationRepository = locationRepository;
			this.locationModelValidator = locationModelValidator;
			this.bolLocationMapper = bolLocationMapper;
			this.dalLocationMapper = dalLocationMapper;
			this.bolProductInventoryMapper = bolProductInventoryMapper;
			this.dalProductInventoryMapper = dalProductInventoryMapper;
			this.bolWorkOrderRoutingMapper = bolWorkOrderRoutingMapper;
			this.dalWorkOrderRoutingMapper = dalWorkOrderRoutingMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLocationResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.locationRepository.All(limit, offset);

			return this.bolLocationMapper.MapBOToModel(this.dalLocationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLocationResponseModel> Get(short locationID)
		{
			var record = await this.locationRepository.Get(locationID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolLocationMapper.MapBOToModel(this.dalLocationMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiLocationResponseModel>> Create(
			ApiLocationRequestModel model)
		{
			CreateResponse<ApiLocationResponseModel> response = new CreateResponse<ApiLocationResponseModel>(await this.locationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolLocationMapper.MapModelToBO(default(short), model);
				var record = await this.locationRepository.Create(this.dalLocationMapper.MapBOToEF(bo));

				response.SetRecord(this.bolLocationMapper.MapBOToModel(this.dalLocationMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLocationResponseModel>> Update(
			short locationID,
			ApiLocationRequestModel model)
		{
			var validationResult = await this.locationModelValidator.ValidateUpdateAsync(locationID, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolLocationMapper.MapModelToBO(locationID, model);
				await this.locationRepository.Update(this.dalLocationMapper.MapBOToEF(bo));

				var record = await this.locationRepository.Get(locationID);

				return new UpdateResponse<ApiLocationResponseModel>(this.bolLocationMapper.MapBOToModel(this.dalLocationMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiLocationResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			short locationID)
		{
			ActionResponse response = new ActionResponse(await this.locationModelValidator.ValidateDeleteAsync(locationID));
			if (response.Success)
			{
				await this.locationRepository.Delete(locationID);
			}

			return response;
		}

		public async Task<ApiLocationResponseModel> ByName(string name)
		{
			Location record = await this.locationRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolLocationMapper.MapBOToModel(this.dalLocationMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiProductInventoryResponseModel>> ProductInventories(short locationID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductInventory> records = await this.locationRepository.ProductInventories(locationID, limit, offset);

			return this.bolProductInventoryMapper.MapBOToModel(this.dalProductInventoryMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiWorkOrderRoutingResponseModel>> WorkOrderRoutings(short locationID, int limit = int.MaxValue, int offset = 0)
		{
			List<WorkOrderRouting> records = await this.locationRepository.WorkOrderRoutings(locationID, limit, offset);

			return this.bolWorkOrderRoutingMapper.MapBOToModel(this.dalWorkOrderRoutingMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>14aa76a096bda69a3f36550022ee270c</Hash>
</Codenesium>*/