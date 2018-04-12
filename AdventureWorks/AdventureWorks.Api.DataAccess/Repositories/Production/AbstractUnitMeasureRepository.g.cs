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

		public AbstractUnitMeasureRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual string Create(
			string name,
			DateTime modifiedDate)
		{
			var record = new EFUnitMeasure();

			MapPOCOToEF(
				string.Empty,
				name,
				modifiedDate,
				record);

			this.context.Set<EFUnitMeasure>().Add(record);
			this.context.SaveChanges();
			return record.UnitMeasureCode;
		}

		public virtual void Update(
			string unitMeasureCode,
			string name,
			DateTime modifiedDate)
		{
			var record = this.SearchLinqEF(x => x.UnitMeasureCode == unitMeasureCode).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{unitMeasureCode}");
			}
			else
			{
				MapPOCOToEF(
					unitMeasureCode,
					name,
					modifiedDate,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			string unitMeasureCode)
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

		public virtual Response GetById(string unitMeasureCode)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.UnitMeasureCode == unitMeasureCode, response);
			return response;
		}

		public virtual POCOUnitMeasure GetByIdDirect(string unitMeasureCode)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.UnitMeasureCode == unitMeasureCode, response);
			return response.UnitMeasures.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFUnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOUnitMeasure> GetWhereDirect(Expression<Func<EFUnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.UnitMeasures;
		}

		private void SearchLinqPOCO(Expression<Func<EFUnitMeasure, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFUnitMeasure> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFUnitMeasure> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFUnitMeasure> SearchLinqEF(Expression<Func<EFUnitMeasure, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFUnitMeasure> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			string unitMeasureCode,
			string name,
			DateTime modifiedDate,
			EFUnitMeasure efUnitMeasure)
		{
			efUnitMeasure.SetProperties(unitMeasureCode, name, modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(
			EFUnitMeasure efUnitMeasure,
			Response response)
		{
			if (efUnitMeasure == null)
			{
				return;
			}

			response.AddUnitMeasure(new POCOUnitMeasure(efUnitMeasure.UnitMeasureCode, efUnitMeasure.Name, efUnitMeasure.ModifiedDate.ToDateTime()));
		}
	}
}

/*<Codenesium>
    <Hash>c70bcbcb596bbd0da3801601baa46c19</Hash>
</Codenesium>*/