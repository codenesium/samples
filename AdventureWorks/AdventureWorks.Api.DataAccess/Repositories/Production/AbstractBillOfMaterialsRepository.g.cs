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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractBillOfMaterialsRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOBillOfMaterials> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOBillOfMaterials Get(int billOfMaterialsID)
		{
			return this.SearchLinqPOCO(x => x.BillOfMaterialsID == billOfMaterialsID).FirstOrDefault();
		}

		public virtual POCOBillOfMaterials Create(
			ApiBillOfMaterialsModel model)
		{
			BillOfMaterials record = new BillOfMaterials();

			this.Mapper.BillOfMaterialsMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<BillOfMaterials>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.BillOfMaterialsMapEFToPOCO(record);
		}

		public virtual void Update(
			int billOfMaterialsID,
			ApiBillOfMaterialsModel model)
		{
			BillOfMaterials record = this.SearchLinqEF(x => x.BillOfMaterialsID == billOfMaterialsID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{billOfMaterialsID}");
			}
			else
			{
				this.Mapper.BillOfMaterialsMapModelToEF(
					billOfMaterialsID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int billOfMaterialsID)
		{
			BillOfMaterials record = this.SearchLinqEF(x => x.BillOfMaterialsID == billOfMaterialsID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<BillOfMaterials>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOBillOfMaterials GetProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID,int componentID,DateTime startDate)
		{
			return this.SearchLinqPOCO(x => x.ProductAssemblyID == productAssemblyID && x.ComponentID == componentID && x.StartDate == startDate).FirstOrDefault();
		}

		public List<POCOBillOfMaterials> GetUnitMeasureCode(string unitMeasureCode)
		{
			return this.SearchLinqPOCO(x => x.UnitMeasureCode == unitMeasureCode);
		}

		protected List<POCOBillOfMaterials> Where(Expression<Func<BillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOBillOfMaterials> SearchLinqPOCO(Expression<Func<BillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOBillOfMaterials> response = new List<POCOBillOfMaterials>();
			List<BillOfMaterials> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.BillOfMaterialsMapEFToPOCO(x)));
			return response;
		}

		private List<BillOfMaterials> SearchLinqEF(Expression<Func<BillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(BillOfMaterials.BillOfMaterialsID)} ASC";
			}
			return this.Context.Set<BillOfMaterials>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<BillOfMaterials>();
		}

		private List<BillOfMaterials> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(BillOfMaterials.BillOfMaterialsID)} ASC";
			}

			return this.Context.Set<BillOfMaterials>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<BillOfMaterials>();
		}
	}
}

/*<Codenesium>
    <Hash>3bec8a286e599e98a4b9bb26fcad0c30</Hash>
</Codenesium>*/