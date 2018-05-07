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
	public abstract class AbstractBOLocation
	{
		private ILocationRepository locationRepository;
		private ILocationModelValidator locationModelValidator;
		private ILogger logger;

		public AbstractBOLocation(
			ILogger logger,
			ILocationRepository locationRepository,
			ILocationModelValidator locationModelValidator)

		{
			this.locationRepository = locationRepository;
			this.locationModelValidator = locationModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<short>> Create(
			LocationModel model)
		{
			CreateResponse<short> response = new CreateResponse<short>(await this.locationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				short id = this.locationRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			short locationID,
			LocationModel model)
		{
			ActionResponse response = new ActionResponse(await this.locationModelValidator.ValidateUpdateAsync(locationID, model));

			if (response.Success)
			{
				this.locationRepository.Update(locationID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			short locationID)
		{
			ActionResponse response = new ActionResponse(await this.locationModelValidator.ValidateDeleteAsync(locationID));

			if (response.Success)
			{
				this.locationRepository.Delete(locationID);
			}
			return response;
		}

		public virtual POCOLocation Get(short locationID)
		{
			return this.locationRepository.Get(locationID);
		}

		public virtual List<POCOLocation> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.locationRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>23de3a624673eea4dad226b1e2b922ae</Hash>
</Codenesium>*/