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
	public abstract class AbstractUnitMeasureRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractUnitMeasureRepository(ILogger logger,
		                                     ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual string Create(string name,
		                             DateTime modifiedDate)
		{
			var record = new EFUnitMeasure ();

			MapPOCOToEF(String.Empty, name,
			            modifiedDate, record);

			this.context.Set<EFUnitMeasure>().Add(record);
			this.context.SaveChanges();
			return record.UnitMeasureCode;
		}

		public virtual void Update(string unitMeasureCode, string name,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.UnitMeasureCode == unitMeasureCode).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",unitMeasureCode);
			}
			else
			{
				MapPOCOToEF(unitMeasureCode,  name,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(string unitMeasureCode)
		{
			var record = this.SearchLinqEF(x => x.UnitMeasureCode == unitMeasureCode).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFUnitMeasure>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(string unitMeasureCode, Response response)
		{
			this.SearchLinqPOCO(x => x.UnitMeasureCode == unitMeasureCode,response);
		}

		protected virtual List<EFUnitMeasure> SearchLinqEF(Expression<Func<EFUnitMeasure, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFUnitMeasure> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFUnitMeasure, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		public virtual List<POCOUnitMeasure> GetWhereDirect(Expression<Func<EFUnitMeasure, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.UnitMeasures;
		}
		public virtual POCOUnitMeasure GetByIdDirect(string unitMeasureCode)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.UnitMeasureCode == unitMeasureCode,response);
			return response.UnitMeasures.FirstOrDefault();
		}

		private void SearchLinqPOCO(Expression<Func<EFUnitMeasure, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFUnitMeasure> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFUnitMeasure> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(string unitMeasureCode, string name,
		                               DateTime modifiedDate, EFUnitMeasure   efUnitMeasure)
		{
			efUnitMeasure.UnitMeasureCode = unitMeasureCode;
			efUnitMeasure.Name = name;
			efUnitMeasure.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFUnitMeasure efUnitMeasure,Response response)
		{
			if(efUnitMeasure == null)
			{
				return;
			}
			response.AddUnitMeasure(new POCOUnitMeasure()
			{
				UnitMeasureCode = efUnitMeasure.UnitMeasureCode,
				Name = efUnitMeasure.Name,
				ModifiedDate = efUnitMeasure.ModifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>00bb4fa9adbbd2f07cd19750aeae0962</Hash>
</Codenesium>*/