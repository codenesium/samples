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
	public abstract class AbstractCultureRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractCultureRepository(ILogger logger,
		                                 ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual string Create(string name,
		                             DateTime modifiedDate)
		{
			var record = new EFCulture ();

			MapPOCOToEF(String.Empty, name,
			            modifiedDate, record);

			this._context.Set<EFCulture>().Add(record);
			this._context.SaveChanges();
			return record.cultureID;
		}

		public virtual void Update(string cultureID, string name,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.cultureID == cultureID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",cultureID);
			}
			else
			{
				MapPOCOToEF(cultureID,  name,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(string cultureID)
		{
			var record = this.SearchLinqEF(x => x.cultureID == cultureID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFCulture>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(string cultureID, Response response)
		{
			this.SearchLinqPOCO(x => x.cultureID == cultureID,response);
		}

		protected virtual List<EFCulture> SearchLinqEF(Expression<Func<EFCulture, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFCulture> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFCulture, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFCulture, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFCulture> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFCulture> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(string cultureID, string name,
		                               DateTime modifiedDate, EFCulture   efCulture)
		{
			efCulture.cultureID = cultureID;
			efCulture.name = name;
			efCulture.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFCulture efCulture,Response response)
		{
			if(efCulture == null)
			{
				return;
			}
			response.AddCulture(new POCOCulture()
			{
				CultureID = efCulture.cultureID,
				Name = efCulture.name,
				ModifiedDate = efCulture.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>bbef61c064f0514410a979c66d441235</Hash>
</Codenesium>*/