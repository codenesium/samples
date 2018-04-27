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

		public virtual ApiResponse GetById(int airlineId)
		{
			return this.airTransportRepository.GetById(airlineId);
		}

		public virtual POCOAirTransport GetByIdDirect(int airlineId)
		{
			return this.airTransportRepository.GetByIdDirect(airlineId);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFAirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.airTransportRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.airTransportRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOAirTransport> GetWhereDirect(Expression<Func<EFAirTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.airTransportRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>63727e25a883561b917a92e55d2e9471</Hash>
</Codenesium>*/