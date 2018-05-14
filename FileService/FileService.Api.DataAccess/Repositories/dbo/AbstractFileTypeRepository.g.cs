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

		public virtual List<POCOFileType> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOFileType Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOFileType Create(
			FileTypeModel model)
		{
			FileType record = new FileType();

			this.Mapper.FileTypeMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<FileType>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.FileTypeMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			FileTypeModel model)
		{
			FileType record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
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
			FileType record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<FileType>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOFileType> Where(Expression<Func<FileType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOFileType> SearchLinqPOCO(Expression<Func<FileType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOFileType> response = new List<POCOFileType>();
			List<FileType> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.FileTypeMapEFToPOCO(x)));
			return response;
		}

		private List<FileType> SearchLinqEF(Expression<Func<FileType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(FileType.Id)} ASC";
			}
			return this.Context.Set<FileType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<FileType>();
		}

		private List<FileType> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(FileType.Id)} ASC";
			}

			return this.Context.Set<FileType>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<FileType>();
		}
	}
}

/*<Codenesium>
    <Hash>3087cc703d38120973cc5d9952bb8ecd</Hash>
</Codenesium>*/