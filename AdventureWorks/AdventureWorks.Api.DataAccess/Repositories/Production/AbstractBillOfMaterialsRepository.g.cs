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
		protected IObjectMapper mapper;

		public AbstractBillOfMaterialsRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			BillOfMaterialsModel model)
		{
			var record = new EFBillOfMaterials();

			this.mapper.BillOfMaterialsMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFBillOfMaterials>().Add(record);
			this.context.SaveChanges();
			return record.BillOfMaterialsID;
		}

		public virtual void Update(
			int billOfMaterialsID,
			BillOfMaterialsModel model)
		{
			var record = this.SearchLinqEF(x => x.BillOfMaterialsID == billOfMaterialsID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{billOfMaterialsID}");
			}
			else
			{
				this.mapper.BillOfMaterialsMapModelToEF(
					billOfMaterialsID,
					model,
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

		public virtual ApiResponse GetById(int billOfMaterialsID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.BillOfMaterialsID == billOfMaterialsID, response);
			return response;
		}

		public virtual POCOBillOfMaterials GetByIdDirect(int billOfMaterialsID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.BillOfMaterialsID == billOfMaterialsID, response);
			return response.BillOfMaterials.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFBillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOBillOfMaterials> GetWhereDirect(Expression<Func<EFBillOfMaterials, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.BillOfMaterials;
		}

		private void SearchLinqPOCO(Expression<Func<EFBillOfMaterials, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFBillOfMaterials> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.BillOfMaterialsMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFBillOfMaterials> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.BillOfMaterialsMapEFToPOCO(x, response));
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
    <Hash>bb04f7f9794cfdd7cac058a586f38660</Hash>
</Codenesium>*/