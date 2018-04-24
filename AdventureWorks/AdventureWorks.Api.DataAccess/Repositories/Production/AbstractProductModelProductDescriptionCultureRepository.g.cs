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
	public abstract class AbstractProductModelProductDescriptionCultureRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductModelProductDescriptionCultureRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			ProductModelProductDescriptionCultureModel model)
		{
			EFProductModelProductDescriptionCulture record = new EFProductModelProductDescriptionCulture();

			this.Mapper.ProductModelProductDescriptionCultureMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFProductModelProductDescriptionCulture>().Add(record);
			this.Context.SaveChanges();
			return record.ProductModelID;
		}

		public virtual void Update(
			int productModelID,
			ProductModelProductDescriptionCultureModel model)
		{
			EFProductModelProductDescriptionCulture record = this.SearchLinqEF(x => x.ProductModelID == productModelID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productModelID}");
			}
			else
			{
				this.Mapper.ProductModelProductDescriptionCultureMapModelToEF(
					productModelID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productModelID)
		{
			EFProductModelProductDescriptionCulture record = this.SearchLinqEF(x => x.ProductModelID == productModelID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFProductModelProductDescriptionCulture>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int productModelID)
		{
			return this.SearchLinqPOCO(x => x.ProductModelID == productModelID);
		}

		public virtual POCOProductModelProductDescriptionCulture GetByIdDirect(int productModelID)
		{
			return this.SearchLinqPOCO(x => x.ProductModelID == productModelID).ProductModelProductDescriptionCultures.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOProductModelProductDescriptionCulture> GetWhereDirect(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).ProductModelProductDescriptionCultures;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFProductModelProductDescriptionCulture> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ProductModelProductDescriptionCultureMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFProductModelProductDescriptionCulture> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ProductModelProductDescriptionCultureMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFProductModelProductDescriptionCulture> SearchLinqEF(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductModelProductDescriptionCulture> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>c880cb8a123814d5d6ab9bd0e2ac6a44</Hash>
</Codenesium>*/