using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOAirTransport
	{
		private IAirTransportRepository airTransportRepository;
		private IAirTransportModelValidator airTransportModelValidator;
		private ILogger logger;

		public AbstractBOAirTransport(
			ILogger logger,
			IAirTransportRepository airTransportRepository,
			IAirTransportModelValidator airTransportModelValidator)

		{
			this.airTransportRepository = airTransportRepository;
			this.airTransportModelValidator = airTransportModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			AirTransportModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.airTransportModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.airTransportRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int airlineId,
			AirTransportModel model)
		{
			ActionResponse response = new ActionResponse(await this.airTransportModelValidator.ValidateUpdateAsync(airlineId, model));

			if (response.Success)
			{
				this.airTransportRepository.Update(airlineId, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int airlineId)
		{
			ActionResponse response = new ActionResponse(await this.airTransportModelValidator.ValidateDeleteAsync(airlineId));

			if (response.Success)
			{
				this.airTransportRepository.Delete(airlineId);
			}
			return response;
		}

		public virtual POCOAirTransport Get(int airlineId)
		{
			return this.airTransportRepository.Get(airlineId);
		}

		public virtual List<POCOAirTransport> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.airTransportRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>05ebe04c8b0ca4edfa38190871bccba1</Hash>
</Codenesium>*/