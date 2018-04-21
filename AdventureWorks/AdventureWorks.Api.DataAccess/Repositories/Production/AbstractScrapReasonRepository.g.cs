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
	public abstract class AbstractScrapReasonRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractScrapReasonRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual short Create(
			ScrapReasonModel model)
		{
			var record = new EFScrapReason();

			this.Mapper.ScrapReasonMapModelToEF(
				default (short),
				model,
				record);

			this.Context.Set<EFScrapReason>().Add(record);
			this.Context.SaveChanges();
			return record.ScrapReasonID;
		}

		public virtual void Update(
			short scrapReasonID,
			ScrapReasonModel model)
		{
			var record = this.SearchLinqEF(x => x.ScrapReasonID == scrapReasonID).FirstOrDefault();
			if (record == null)
			{
				throw new Exception($"Unable to find id:{scrapReasonID}");
			}
			else
			{
				this.Mapper.ScrapReasonMapModelToEF(
					scrapReasonID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			short scrapReasonID)
		{
			var record = this.SearchLinqEF(x => x.ScrapReasonID == scrapReasonID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFScrapReason>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(short scrapReasonID)
		{
			return this.SearchLinqPOCO(x => x.ScrapReasonID == scrapReasonID);
		}

		public virtual POCOScrapReason GetByIdDirect(short scrapReasonID)
		{
			return this.SearchLinqPOCO(x => x.ScrapReasonID == scrapReasonID).ScrapReasons.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOScrapReason> GetWhereDirect(Expression<Func<EFScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).ScrapReasons;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			List<EFScrapReason> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ScrapReasonMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			List<EFScrapReason> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ScrapReasonMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFScrapReason> SearchLinqEF(Expression<Func<EFScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFScrapReason> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>fd91c49f231fe398e08cbc9d72cf3898</Hash>
</Codenesium>*/