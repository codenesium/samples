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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractCultureRepository(ILogger logger,
		                                 ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual string Create(string name,
		                             DateTime modifiedDate)
		{
			var record = new EFCulture ();

			MapPOCOToEF(String.Empty, name,
			            modifiedDate, record);

			this.context.Set<EFCulture>().Add(record);
			this.context.SaveChanges();
			return record.CultureID;
		}

		public virtual void Update(string cultureID, string name,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.CultureID == cultureID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",cultureID);
			}
			else
			{
				MapPOCOToEF(cultureID,  name,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(string cultureID)
		{
			var record = this.SearchLinqEF(x => x.CultureID == cultureID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFCulture>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(string cultureID, Response response)
		{
			this.SearchLinqPOCO(x => x.CultureID == cultureID,response);
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

		public virtual List<POCOCulture> GetWhereDirect(Expression<Func<EFCulture, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Cultures;
		}
		public virtual POCOCulture GetByIdDirect(string cultureID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.CultureID == cultureID,response);
			return response.Cultures.FirstOrDefault();
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
			efCulture.CultureID = cultureID;
			efCulture.Name = name;
			efCulture.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFCulture efCulture,Response response)
		{
			if(efCulture == null)
			{
				return;
			}
			response.AddCulture(new POCOCulture()
			{
				CultureID = efCulture.CultureID,
				Name = efCulture.Name,
				ModifiedDate = efCulture.ModifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>6d68860700258b621182d3d3fe4de0b9</Hash>
</Codenesium>*/