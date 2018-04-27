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
	public abstract class AbstractBOAirline
	{
		private IAirlineRepository airlineRepository;
		private IAirlineModelValidator airlineModelValidator;
		private ILogger logger;

		public AbstractBOAirline(
			ILogger logger,
			IAirlineRepository airlineRepository,
			IAirlineModelValidator airlineModelValidator)

		{
			this.airlineRepository = airlineRepository;
			this.airlineModelValidator = airlineModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			AirlineModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.airlineModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.airlineRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			AirlineModel model)
		{
			ActionResponse response = new ActionResponse(await this.airlineModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.airlineRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.airlineModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.airlineRepository.Delete(id);
			}
			return response;
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.airlineRepository.GetById(id);
		}

		public virtual POCOAirline GetByIdDirect(int id)
		{
			return this.airlineRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFAirline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.airlineRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.airlineRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOAirline> GetWhereDirect(Expression<Func<EFAirline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.airlineRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>fd94047a83f0a7c644ce2ad1f2f8a8ec</Hash>
</Codenesium>*/