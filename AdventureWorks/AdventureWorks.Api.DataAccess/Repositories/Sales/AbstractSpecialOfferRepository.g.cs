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

		public virtual List<POCOSpecialOffer> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOSpecialOffer Get(int specialOfferID)
		{
			return this.SearchLinqPOCO(x => x.SpecialOfferID == specialOfferID).FirstOrDefault();
		}

		public virtual POCOSpecialOffer Create(
			ApiSpecialOfferModel model)
		{
			SpecialOffer record = new SpecialOffer();

			this.Mapper.SpecialOfferMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SpecialOffer>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.SpecialOfferMapEFToPOCO(record);
		}

		public virtual void Update(
			int specialOfferID,
			ApiSpecialOfferModel model)
		{
			SpecialOffer record = this.SearchLinqEF(x => x.SpecialOfferID == specialOfferID).FirstOrDefault();
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
			SpecialOffer record = this.SearchLinqEF(x => x.SpecialOfferID == specialOfferID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SpecialOffer>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOSpecialOffer> Where(Expression<Func<SpecialOffer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOSpecialOffer> SearchLinqPOCO(Expression<Func<SpecialOffer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSpecialOffer> response = new List<POCOSpecialOffer>();
			List<SpecialOffer> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.SpecialOfferMapEFToPOCO(x)));
			return response;
		}

		private List<SpecialOffer> SearchLinqEF(Expression<Func<SpecialOffer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SpecialOffer.SpecialOfferID)} ASC";
			}
			return this.Context.Set<SpecialOffer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SpecialOffer>();
		}

		private List<SpecialOffer> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SpecialOffer.SpecialOfferID)} ASC";
			}

			return this.Context.Set<SpecialOffer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SpecialOffer>();
		}
	}
}

/*<Codenesium>
    <Hash>565e06b17c881bb280ea3b3201078a43</Hash>
</Codenesium>*/