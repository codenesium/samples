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

		public virtual int Create(
			BillOfMaterialsModel model)
		{
			EFBillOfMaterials record = new EFBillOfMaterials();

			this.Mapper.BillOfMaterialsMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFBillOfMaterials>().Add(record);
			this.Context.SaveChanges();
			return record.BillOfMaterialsID;
		}

		public virtual void Update(
			int billOfMaterialsID,
			BillOfMaterialsModel model)
		{
			EFBillOfMaterials record = this.SearchLinqEF(x => x.BillOfMaterialsID == billOfMaterialsID).FirstOrDefault();
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
			EFBillOfMaterials record = this.SearchLinqEF(x => x.BillOfMaterialsID == billOfMaterialsID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFBillOfMaterials>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual POCOBillOfMaterials Get(int billOfMaterialsID)
		{
			return this.SearchLinqPOCO(x => x.BillOfMaterialsID == billOfMaterialsID).FirstOrDefault();
		}

		public virtual List<POCOBillOfMaterials> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCOBillOfMaterials> Where(Expression<Func<EFBillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOBillOfMaterials> SearchLinqPOCO(Expression<Func<EFBillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOBillOfMaterials> response = new List<POCOBillOfMaterials>();
			List<EFBillOfMaterials> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.BillOfMaterialsMapEFToPOCO(x)));
			return response;
		}

		private List<EFBillOfMaterials> SearchLinqEF(Expression<Func<EFBillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFBillOfMaterials>().Where(predicate).AsQueryable().OrderBy("BillOfMaterialsID ASC").Skip(skip).Take(take).ToList<EFBillOfMaterials>();
			}
			else
			{
				return this.Context.Set<EFBillOfMaterials>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFBillOfMaterials>();
			}
		}

		private List<EFBillOfMaterials> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFBillOfMaterials>().Where(predicate).AsQueryable().OrderBy("BillOfMaterialsID ASC").Skip(skip).Take(take).ToList<EFBillOfMaterials>();
			}
			else
			{
				return this.Context.Set<EFBillOfMaterials>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFBillOfMaterials>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>c3a800131090f724f30a31f45046364c</Hash>
</Codenesium>*/