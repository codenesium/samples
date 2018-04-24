using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public abstract class AbstractFileTypeRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractFileTypeRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			FileTypeModel model)
		{
			EFFileType record = new EFFileType();

			this.Mapper.FileTypeMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFFileType>().Add(record);
			this.Context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(
			int id,
			FileTypeModel model)
		{
			EFFileType record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.FileTypeMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			EFFileType record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFFileType>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id);
		}

		public virtual POCOFileType GetByIdDirect(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FileTypes.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFFileType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOFileType> GetWhereDirect(Expression<Func<EFFileType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).FileTypes;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFFileType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFFileType> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.FileTypeMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFFileType> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.FileTypeMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFFileType> SearchLinqEF(Expression<Func<EFFileType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFFileType> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>f861ee908a0d70faf749148e8d1d21d5</Hash>
</Codenesium>*/