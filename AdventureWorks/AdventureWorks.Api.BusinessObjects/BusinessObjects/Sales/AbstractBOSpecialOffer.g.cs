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
	public abstract class AbstractBOSpecialOffer
	{
		private ISpecialOfferRepository specialOfferRepository;
		private ISpecialOfferModelValidator specialOfferModelValidator;
		private ILogger logger;

		public AbstractBOSpecialOffer(
			ILogger logger,
			ISpecialOfferRepository specialOfferRepository,
			ISpecialOfferModelValidator specialOfferModelValidator)

		{
			this.specialOfferRepository = specialOfferRepository;
			this.specialOfferModelValidator = specialOfferModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			SpecialOfferModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.specialOfferModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.specialOfferRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int specialOfferID,
			SpecialOfferModel model)
		{
			ActionResponse response = new ActionResponse(await this.specialOfferModelValidator.ValidateUpdateAsync(specialOfferID, model));

			if (response.Success)
			{
				this.specialOfferRepository.Update(specialOfferID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int specialOfferID)
		{
			ActionResponse response = new ActionResponse(await this.specialOfferModelValidator.ValidateDeleteAsync(specialOfferID));

			if (response.Success)
			{
				this.specialOfferRepository.Delete(specialOfferID);
			}
			return response;
		}

		public virtual POCOSpecialOffer Get(int specialOfferID)
		{
			return this.specialOfferRepository.Get(specialOfferID);
		}

		public virtual List<POCOSpecialOffer> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.specialOfferRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>ddad46347f3246326e3e867323b966f5</Hash>
</Codenesium>*/