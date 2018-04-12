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
	public abstract class AbstractBillOfMaterialsRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractBillOfMaterialsRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			Nullable<int> productAssemblyID,
			int componentID,
			DateTime startDate,
			Nullable<DateTime> endDate,
			string unitMeasureCode,
			short bOMLevel,
			decimal perAssemblyQty,
			DateTime modifiedDate)
		{
			var record = new EFBillOfMaterials();

			MapPOCOToEF(
				0,
				productAssemblyID,
				componentID,
				startDate,
				endDate,
				unitMeasureCode,
				bOMLevel,
				perAssemblyQty,
				modifiedDate,
				record);

			this.context.Set<EFBillOfMaterials>().Add(record);
			this.context.SaveChanges();
			return record.BillOfMaterialsID;
		}

		public virtual void Update(
			int billOfMaterialsID,
			Nullable<int> productAssemblyID,
			int componentID,
			DateTime startDate,
			Nullable<DateTime> endDate,
			string unitMeasureCode,
			short bOMLevel,
			decimal perAssemblyQty,
			DateTime modifiedDate)
		{
			var record = this.SearchLinqEF(x => x.BillOfMaterialsID == billOfMaterialsID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{billOfMaterialsID}");
			}
			else
			{
				MapPOCOToEF(
					billOfMaterialsID,
					productAssemblyID,
					componentID,
					startDate,
					endDate,
					unitMeasureCode,
					bOMLevel,
					perAssemblyQty,
					modifiedDate,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int billOfMaterialsID)
		{
			var record = this.SearchLinqEF(x => x.BillOfMaterialsID == billOfMaterialsID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFBillOfMaterials>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int billOfMaterialsID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BillOfMaterialsID == billOfMaterialsID, response);
			return response;
		}

		public virtual POCOBillOfMaterials GetByIdDirect(int billOfMaterialsID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BillOfMaterialsID == billOfMaterialsID, response);
			return response.BillOfMaterials.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFBillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOBillOfMaterials> GetWhereDirect(Expression<Func<EFBillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.BillOfMaterials;
		}

		private void SearchLinqPOCO(Expression<Func<EFBillOfMaterials, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFBillOfMaterials> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFBillOfMaterials> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFBillOfMaterials> SearchLinqEF(Expression<Func<EFBillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFBillOfMaterials> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int billOfMaterialsID,
			Nullable<int> productAssemblyID,
			int componentID,
			DateTime startDate,
			Nullable<DateTime> endDate,
			string unitMeasureCode,
			short bOMLevel,
			decimal perAssemblyQty,
			DateTime modifiedDate,
			EFBillOfMaterials efBillOfMaterials)
		{
			efBillOfMaterials.SetProperties(billOfMaterialsID.ToInt(), productAssemblyID.ToNullableInt(), componentID.ToInt(), startDate.ToDateTime(), endDate.ToNullableDateTime(), unitMeasureCode, bOMLevel, perAssemblyQty.ToDecimal(), modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(
			EFBillOfMaterials efBillOfMaterials,
			Response response)
		{
			if (efBillOfMaterials == null)
			{
				return;
			}

			response.AddBillOfMaterials(new POCOBillOfMaterials(efBillOfMaterials.BillOfMaterialsID.ToInt(), efBillOfMaterials.ProductAssemblyID.ToNullableInt(), efBillOfMaterials.ComponentID.ToInt(), efBillOfMaterials.StartDate.ToDateTime(), efBillOfMaterials.EndDate.ToNullableDateTime(), efBillOfMaterials.UnitMeasureCode, efBillOfMaterials.BOMLevel, efBillOfMaterials.PerAssemblyQty.ToDecimal(), efBillOfMaterials.ModifiedDate.ToDateTime()));

			ProductRepository.MapEFToPOCO(efBillOfMaterials.Product, response);

			ProductRepository.MapEFToPOCO(efBillOfMaterials.Product1, response);

			UnitMeasureRepository.MapEFToPOCO(efBillOfMaterials.UnitMeasure, response);
		}
	}
}

/*<Codenesium>
    <Hash>bb6188170832287233a14f53d8736a9c</Hash>
</Codenesium>*/