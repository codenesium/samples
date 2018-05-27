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
		protected IDALBillOfMaterialsMapper Mapper { get; }

		public AbstractBillOfMaterialsRepository(
			IDALBillOfMaterialsMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOBillOfMaterials>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOBillOfMaterials> Get(int billOfMaterialsID)
		{
			BillOfMaterials record = await this.GetById(billOfMaterialsID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOBillOfMaterials> Create(
			DTOBillOfMaterials dto)
		{
			BillOfMaterials record = new BillOfMaterials();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<BillOfMaterials>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int billOfMaterialsID,
			DTOBillOfMaterials dto)
		{
			BillOfMaterials record = await this.GetById(billOfMaterialsID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{billOfMaterialsID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					billOfMaterialsID,
					dto,
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

		public async Task<DTOBillOfMaterials> GetProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID,int componentID,DateTime startDate)
		{
			var records = await this.SearchLinqDTO(x => x.ProductAssemblyID == productAssemblyID && x.ComponentID == componentID && x.StartDate == startDate);

			return records.FirstOrDefault();
		}
		public async Task<List<DTOBillOfMaterials>> GetUnitMeasureCode(string unitMeasureCode)
		{
			var records = await this.SearchLinqDTO(x => x.UnitMeasureCode == unitMeasureCode);

			return records;
		}

		protected async Task<List<DTOBillOfMaterials>> Where(Expression<Func<BillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOBillOfMaterials> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOBillOfMaterials>> SearchLinqDTO(Expression<Func<BillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOBillOfMaterials> response = new List<DTOBillOfMaterials>();
			List<BillOfMaterials> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>310feac2a19bea937a656236e59badb3</Hash>
</Codenesium>*/