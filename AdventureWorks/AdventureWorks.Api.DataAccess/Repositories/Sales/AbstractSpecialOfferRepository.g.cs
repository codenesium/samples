using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractSpecialOfferRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractSpecialOfferRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			SpecialOfferModel model)
		{
			var record = new EFSpecialOffer();

			this.mapper.SpecialOfferMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFSpecialOffer>().Add(record);
			this.context.SaveChanges();
			return record.SpecialOfferID;
		}

		public virtual void Update(
			int specialOfferID,
			SpecialOfferModel model)
		{
			var record = this.SearchLinqEF(x => x.SpecialOfferID == specialOfferID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{specialOfferID}");
			}
			else
			{
				this.mapper.SpecialOfferMapModelToEF(
					specialOfferID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int specialOfferID)
		{
			var record = this.SearchLinqEF(x => x.SpecialOfferID == specialOfferID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFSpecialOffer>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int specialOfferID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.SpecialOfferID == specialOfferID, response);
			return response;
		}

		public virtual POCOSpecialOffer GetByIdDirect(int specialOfferID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.SpecialOfferID == specialOfferID, response);
			return response.SpecialOffers.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSpecialOffer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOSpecialOffer> GetWhereDirect(Expression<Func<EFSpecialOffer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.SpecialOffers;
		}

		private void SearchLinqPOCO(Expression<Func<EFSpecialOffer, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSpecialOffer> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.SpecialOfferMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSpecialOffer> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.SpecialOfferMapEFToPOCO(x, response));
		}

		protected virtual List<EFSpecialOffer> SearchLinqEF(Expression<Func<EFSpecialOffer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSpecialOffer> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>79ff66528cc933e36a11ef96d96eef2f</Hash>
</Codenesium>*/