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
	public abstract class AbstractProductRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			ProductModel model)
		{
			EFProduct record = new EFProduct();

			this.Mapper.ProductMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFProduct>().Add(record);
			this.Context.SaveChanges();
			return record.ProductID;
		}

		public virtual void Update(
			int productID,
			ProductModel model)
		{
			EFProduct record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productID}");
			}
			else
			{
				this.Mapper.ProductMapModelToEF(
					productID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productID)
		{
			EFProduct record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFProduct>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID);
		}

		public virtual POCOProduct GetByIdDirect(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID).Products.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOProduct> GetWhereDirect(Expression<Func<EFProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).Products;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFProduct> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ProductMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFProduct> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ProductMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFProduct> SearchLinqEF(Expression<Func<EFProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProduct> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>9f56680ac923b95368672d2ed57e3460</Hash>
</Codenesium>*/