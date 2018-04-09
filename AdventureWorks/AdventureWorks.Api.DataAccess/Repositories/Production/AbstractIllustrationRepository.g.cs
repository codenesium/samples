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
	public abstract class AbstractIllustrationRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractIllustrationRepository(ILogger logger,
		                                      ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(string diagram,
		                          DateTime modifiedDate)
		{
			var record = new EFIllustration ();

			MapPOCOToEF(0, diagram,
			            modifiedDate, record);

			this.context.Set<EFIllustration>().Add(record);
			this.context.SaveChanges();
			return record.IllustrationID;
		}

		public virtual void Update(int illustrationID, string diagram,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.IllustrationID == illustrationID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{illustrationID}");
			}
			else
			{
				MapPOCOToEF(illustrationID,  diagram,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int illustrationID)
		{
			var record = this.SearchLinqEF(x => x.IllustrationID == illustrationID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFIllustration>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int illustrationID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.IllustrationID == illustrationID,response);
			return response;
		}

		public virtual POCOIllustration GetByIdDirect(int illustrationID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.IllustrationID == illustrationID,response);
			return response.Illustrations.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFIllustration, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOIllustration> GetWhereDirect(Expression<Func<EFIllustration, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Illustrations;
		}

		private void SearchLinqPOCO(Expression<Func<EFIllustration, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFIllustration> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFIllustration> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		protected virtual List<EFIllustration> SearchLinqEF(Expression<Func<EFIllustration, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFIllustration> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(int illustrationID, string diagram,
		                               DateTime modifiedDate, EFIllustration   efIllustration)
		{
			efIllustration.SetProperties(illustrationID.ToInt(),diagram,modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(EFIllustration efIllustration,Response response)
		{
			if(efIllustration == null)
			{
				return;
			}
			response.AddIllustration(new POCOIllustration(efIllustration.IllustrationID.ToInt(),efIllustration.Diagram,efIllustration.ModifiedDate.ToDateTime()));
		}
	}
}

/*<Codenesium>
    <Hash>9edf7b71ceb6157e1107d87f2d712f08</Hash>
</Codenesium>*/