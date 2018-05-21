using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractBillOfMaterialsRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractBillOfMaterialsRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOBillOfMaterials>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOBillOfMaterials> Get(int billOfMaterialsID)
		{
			BillOfMaterials record = await this.GetById(billOfMaterialsID);

			return this.Mapper.BillOfMaterialsMapEFToPOCO(record);
		}

		public async virtual Task<POCOBillOfMaterials> Create(
			ApiBillOfMaterialsModel model)
		{
			BillOfMaterials record = new BillOfMaterials();

			this.Mapper.BillOfMaterialsMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<BillOfMaterials>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.BillOfMaterialsMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int billOfMaterialsID,
			ApiBillOfMaterialsModel model)
		{
			BillOfMaterials record = await this.GetById(billOfMaterialsID);

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

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int billOfMaterialsID)
		{
			BillOfMaterials record = await this.GetById(billOfMaterialsID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<BillOfMaterials>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOBillOfMaterials> GetProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID,int componentID,DateTime startDate)
		{
			var records = await this.SearchLinqPOCO(x => x.ProductAssemblyID == productAssemblyID && x.ComponentID == componentID && x.StartDate == startDate);

			return records.FirstOrDefault();
		}
		public async Task<List<POCOBillOfMaterials>> GetUnitMeasureCode(string unitMeasureCode)
		{
			var records = await this.SearchLinqPOCO(x => x.UnitMeasureCode == unitMeasureCode);

			return records;
		}

		protected async Task<List<POCOBillOfMaterials>> Where(Expression<Func<BillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOBillOfMaterials> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOBillOfMaterials>> SearchLinqPOCO(Expression<Func<BillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOBillOfMaterials> response = new List<POCOBillOfMaterials>();
			List<BillOfMaterials> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.BillOfMaterialsMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<BillOfMaterials>> SearchLinqEF(Expression<Func<BillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(BillOfMaterials.BillOfMaterialsID)} ASC";
			}
			return await this.Context.Set<BillOfMaterials>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<BillOfMaterials>();
		}

		private async Task<List<BillOfMaterials>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(BillOfMaterials.BillOfMaterialsID)} ASC";
			}

			return await this.Context.Set<BillOfMaterials>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<BillOfMaterials>();
		}

		private async Task<BillOfMaterials> GetById(int billOfMaterialsID)
		{
			List<BillOfMaterials> records = await this.SearchLinqEF(x => x.BillOfMaterialsID == billOfMaterialsID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>bed845694fca7767c8cc45caa42fd023</Hash>
</Codenesium>*/