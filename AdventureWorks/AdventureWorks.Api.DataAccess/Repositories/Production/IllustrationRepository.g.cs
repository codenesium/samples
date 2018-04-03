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
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractIllustrationRepository(ILogger logger,
		                                      ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string diagram,
		                          DateTime modifiedDate)
		{
			var record = new EFIllustration ();

			MapPOCOToEF(0, diagram,
			            modifiedDate, record);

			this._context.Set<EFIllustration>().Add(record);
			this._context.SaveChanges();
			return record.illustrationID;
		}

		public virtual void Update(int illustrationID, string diagram,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.illustrationID == illustrationID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",illustrationID);
			}
			else
			{
				MapPOCOToEF(illustrationID,  diagram,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int illustrationID)
		{
			var record = this.SearchLinqEF(x => x.illustrationID == illustrationID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFIllustration>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int illustrationID, Response response)
		{
			this.SearchLinqPOCO(x => x.illustrationID == illustrationID,response);
		}

		protected virtual List<EFIllustration> SearchLinqEF(Expression<Func<EFIllustration, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFIllustration> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFIllustration, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
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

		public static void MapPOCOToEF(int illustrationID, string diagram,
		                               DateTime modifiedDate, EFIllustration   efIllustration)
		{
			efIllustration.illustrationID = illustrationID;
			efIllustration.diagram = diagram;
			efIllustration.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFIllustration efIllustration,Response response)
		{
			if(efIllustration == null)
			{
				return;
			}
			response.AddIllustration(new POCOIllustration()
			{
				IllustrationID = efIllustration.illustrationID.ToInt(),
				Diagram = efIllustration.diagram,
				ModifiedDate = efIllustration.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>62639b3662483e234a01533ebbb0bdcb</Hash>
</Codenesium>*/