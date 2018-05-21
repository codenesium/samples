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
	public abstract class AbstractBOSpecialOffer: AbstractBOManager
	{
		private ISpecialOfferRepository specialOfferRepository;
		private IApiSpecialOfferModelValidator specialOfferModelValidator;
		private ILogger logger;

		public AbstractBOSpecialOffer(
			ILogger logger,
			ISpecialOfferRepository specialOfferRepository,
			IApiSpecialOfferModelValidator specialOfferModelValidator)
			: base()

		{
			this.specialOfferRepository = specialOfferRepository;
			this.specialOfferModelValidator = specialOfferModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOSpecialOffer>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.specialOfferRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOSpecialOffer> Get(int specialOfferID)
		{
			return this.specialOfferRepository.Get(specialOfferID);
		}

		public virtual async Task<CreateResponse<POCOSpecialOffer>> Create(
			ApiSpecialOfferModel model)
		{
			CreateResponse<POCOSpecialOffer> response = new CreateResponse<POCOSpecialOffer>(await this.specialOfferModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOSpecialOffer record = await this.specialOfferRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int specialOfferID,
			ApiSpecialOfferModel model)
		{
			ActionResponse response = new ActionResponse(await this.specialOfferModelValidator.ValidateUpdateAsync(specialOfferID, model));

			if (response.Success)
			{
				await this.specialOfferRepository.Update(specialOfferID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int specialOfferID)
		{
			ActionResponse response = new ActionResponse(await this.specialOfferModelValidator.ValidateDeleteAsync(specialOfferID));

			if (response.Success)
			{
				await this.specialOfferRepository.Delete(specialOfferID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f3218fbd4222c447387a9dcbb8e0c53e</Hash>
</Codenesium>*/