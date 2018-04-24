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

		public virtual ApiResponse GetById(int billOfMaterialsID)
		{
			return this.SearchLinqPOCO(x => x.BillOfMaterialsID == billOfMaterialsID);
		}

		public virtual POCOBillOfMaterials GetByIdDirect(int billOfMaterialsID)
		{
			return this.SearchLinqPOCO(x => x.BillOfMaterialsID == billOfMaterialsID).BillOfMaterials.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFBillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOBillOfMaterials> GetWhereDirect(Expression<Func<EFBillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).BillOfMaterials;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFBillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFBillOfMaterials> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.BillOfMaterialsMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFBillOfMaterials> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.BillOfMaterialsMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFBillOfMaterials> SearchLinqEF(Expression<Func<EFBillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFBillOfMaterials> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>f229cb2fb2cb0cb29a29dec1dd96f486</Hash>
</Codenesium>*/