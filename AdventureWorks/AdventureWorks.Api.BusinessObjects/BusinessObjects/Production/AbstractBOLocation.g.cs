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
		private IApiLocationModelValidator locationModelValidator;
		private ILogger logger;

		public AbstractBOLocation(
			ILogger logger,
			ILocationRepository locationRepository,
			IApiLocationModelValidator locationModelValidator)
			: base()

		{
			this.locationRepository = locationRepository;
			this.locationModelValidator = locationModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOLocation>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.locationRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOLocation> Get(short locationID)
		{
			return this.locationRepository.Get(locationID);
		}

		public virtual async Task<CreateResponse<POCOLocation>> Create(
			ApiLocationModel model)
		{
			CreateResponse<POCOLocation> response = new CreateResponse<POCOLocation>(await this.locationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOLocation record = await this.locationRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			short locationID,
			ApiLocationModel model)
		{
			ActionResponse response = new ActionResponse(await this.locationModelValidator.ValidateUpdateAsync(locationID, model));

			if (response.Success)
			{
				await this.locationRepository.Update(locationID, model);
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

		public async Task<POCOLocation> GetName(string name)
		{
			return await this.locationRepository.GetName(name);
		}
	}
}

/*<Codenesium>
    <Hash>e499c1741a3cb51afe0b89312a2801d2</Hash>
</Codenesium>*/