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

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLocation: AbstractBOManager
	{
		private ILocationRepository locationRepository;
		private IApiLocationRequestModelValidator locationModelValidator;
		private IBOLLocationMapper locationMapper;
		private ILogger logger;

		public AbstractBOLocation(
			ILogger logger,
			ILocationRepository locationRepository,
			IApiLocationRequestModelValidator locationModelValidator,
			IBOLLocationMapper locationMapper)
			: base()

		{
			this.locationRepository = locationRepository;
			this.locationModelValidator = locationModelValidator;
			this.locationMapper = locationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLocationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.locationRepository.All(skip, take, orderClause);

			return this.locationMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiLocationResponseModel> Get(short locationID)
		{
			var record = await locationRepository.Get(locationID);

			return this.locationMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiLocationResponseModel>> Create(
			ApiLocationRequestModel model)
		{
			CreateResponse<ApiLocationResponseModel> response = new CreateResponse<ApiLocationResponseModel>(await this.locationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.locationMapper.MapModelToDTO(default (short), model);
				var record = await this.locationRepository.Create(dto);

				response.SetRecord(this.locationMapper.MapDTOToModel(record));
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
				var dto = this.locationMapper.MapModelToDTO(locationID, model);
				await this.locationRepository.Update(locationID, dto);
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
			DTOLocation record = await this.locationRepository.GetName(name);

			return this.locationMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>c48697d2cf7bf26ece60318d12d4920a</Hash>
</Codenesium>*/