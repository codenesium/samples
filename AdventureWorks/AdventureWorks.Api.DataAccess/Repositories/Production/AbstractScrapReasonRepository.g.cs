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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractScrapReasonRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual short Create(
			string name,
			DateTime modifiedDate)
		{
			var record = new EFScrapReason();

			MapPOCOToEF(
				0,
				name,
				modifiedDate,
				record);

			this.context.Set<EFScrapReason>().Add(record);
			this.context.SaveChanges();
			return record.ScrapReasonID;
		}

		public virtual void Update(
			short scrapReasonID,
			string name,
			DateTime modifiedDate)
		{
			var record = this.SearchLinqEF(x => x.ScrapReasonID == scrapReasonID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{scrapReasonID}");
			}
			else
			{
				MapPOCOToEF(
					scrapReasonID,
					name,
					modifiedDate,
					record);
				this.context.SaveChanges();
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
				this.context.Set<EFScrapReason>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(short scrapReasonID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ScrapReasonID == scrapReasonID, response);
			return response;
		}

		public virtual POCOScrapReason GetByIdDirect(short scrapReasonID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ScrapReasonID == scrapReasonID, response);
			return response.ScrapReasons.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOScrapReason> GetWhereDirect(Expression<Func<EFScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ScrapReasons;
		}

		private void SearchLinqPOCO(Expression<Func<EFScrapReason, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFScrapReason> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFScrapReason> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFScrapReason> SearchLinqEF(Expression<Func<EFScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFScrapReason> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			short scrapReasonID,
			string name,
			DateTime modifiedDate,
			EFScrapReason efScrapReason)
		{
			efScrapReason.SetProperties(scrapReasonID, name, modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(
			EFScrapReason efScrapReason,
			Response response)
		{
			if (efScrapReason == null)
			{
				return;
			}

			response.AddScrapReason(new POCOScrapReason(efScrapReason.ScrapReasonID, efScrapReason.Name, efScrapReason.ModifiedDate.ToDateTime()));
		}
	}
}

/*<Codenesium>
    <Hash>f72f4ee1f9c0a213f7669c33a6c9475a</Hash>
</Codenesium>*/