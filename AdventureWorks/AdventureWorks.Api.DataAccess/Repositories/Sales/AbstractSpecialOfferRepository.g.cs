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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSpecialOfferRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			SpecialOfferModel model)
		{
			EFSpecialOffer record = new EFSpecialOffer();

			this.Mapper.SpecialOfferMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFSpecialOffer>().Add(record);
			this.Context.SaveChanges();
			return record.SpecialOfferID;
		}

		public virtual void Update(
			int specialOfferID,
			SpecialOfferModel model)
		{
			EFSpecialOffer record = this.SearchLinqEF(x => x.SpecialOfferID == specialOfferID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{specialOfferID}");
			}
			else
			{
				this.Mapper.SpecialOfferMapModelToEF(
					specialOfferID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int specialOfferID)
		{
			EFSpecialOffer record = this.SearchLinqEF(x => x.SpecialOfferID == specialOfferID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFSpecialOffer>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int specialOfferID)
		{
			return this.SearchLinqPOCO(x => x.SpecialOfferID == specialOfferID);
		}

		public virtual POCOSpecialOffer GetByIdDirect(int specialOfferID)
		{
			return this.SearchLinqPOCO(x => x.SpecialOfferID == specialOfferID).SpecialOffers.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSpecialOffer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOSpecialOffer> GetWhereDirect(Expression<Func<EFSpecialOffer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).SpecialOffers;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFSpecialOffer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFSpecialOffer> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.SpecialOfferMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFSpecialOffer> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.SpecialOfferMapEFToPOCO(x, response));
			return response;
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
    <Hash>9ca931fc595904d96216eedddc10d130</Hash>
</Codenesium>*/