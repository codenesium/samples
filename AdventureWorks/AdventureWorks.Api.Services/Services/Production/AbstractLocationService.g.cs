using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractLocationService: AbstractService
	{
		private ILocationRepository locationRepository;
		private IApiLocationRequestModelValidator locationModelValidator;
		private IBOLLocationMapper bolLocationMapper;
		private IDALLocationMapper dalLocationMapper;
		private ILogger logger;

		public AbstractLocationService(
			ILogger logger,
			ILocationRepository locationRepository,
			IApiLocationRequestModelValidator locationModelValidator,
			IBOLLocationMapper bollocationMapper,
			IDALLocationMapper dallocationMapper)
			: base()

		{
			this.locationRepository = locationRepository;
			this.locationModelValidator = locationModelValidator;
			this.bolLocationMapper = bollocationMapper;
			this.dalLocationMapper = dallocationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLocationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.locationRepository.All(skip, take, orderClause);

			return this.bolLocationMapper.MapBOToModel(this.dalLocationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLocationResponseModel> Get(short locationID)
		{
			var record = await locationRepository.Get(locationID);

			return this.bolLocationMapper.MapBOToModel(this.dalLocationMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiLocationResponseModel>> Create(
			ApiLocationRequestModel model)
		{
			CreateResponse<ApiLocationResponseModel> response = new CreateResponse<ApiLocationResponseModel>(await this.locationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolLocationMapper.MapModelToBO(default (short), model);
				var record = await this.locationRepository.Create(this.dalLocationMapper.MapBOToEF(bo));

				response.SetRecord(this.bolLocationMapper.MapBOToModel(this.dalLocationMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			short locationID,
			ApiLocationRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.locationModelValidator.ValidateUpdateAsync(locationID, model));

			if (response.Success)
			{
				var bo = this.bolLocationMapper.MapModelToBO(locationID, model);
				await this.locationRepository.Update(this.dalLocationMapper.MapBOToEF(bo));
			}

			return response;
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

		public async Task<ApiLocationResponseModel> GetName(string name)
		{
			Location record = await this.locationRepository.GetName(name);

			return this.bolLocationMapper.MapBOToModel(this.dalLocationMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>1ac434edb490154d1b7b63daabe1ae96</Hash>
</Codenesium>*/