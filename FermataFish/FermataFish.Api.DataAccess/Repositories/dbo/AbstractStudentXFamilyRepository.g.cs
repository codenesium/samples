using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractStudentXFamilyRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractStudentXFamilyRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOStudentXFamily>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOStudentXFamily> Get(int id)
		{
			StudentXFamily record = await this.GetById(id);

			return this.Mapper.StudentXFamilyMapEFToPOCO(record);
		}

		public async virtual Task<POCOStudentXFamily> Create(
			ApiStudentXFamilyModel model)
		{
			StudentXFamily record = new StudentXFamily();

			this.Mapper.StudentXFamilyMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<StudentXFamily>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.StudentXFamilyMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiStudentXFamilyModel model)
		{
			StudentXFamily record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.StudentXFamilyMapModelToEF(
					id,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			StudentXFamily record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<StudentXFamily>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOStudentXFamily>> Where(Expression<Func<StudentXFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOStudentXFamily> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOStudentXFamily>> SearchLinqPOCO(Expression<Func<StudentXFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOStudentXFamily> response = new List<POCOStudentXFamily>();
			List<StudentXFamily> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.StudentXFamilyMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<StudentXFamily>> SearchLinqEF(Expression<Func<StudentXFamily, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(StudentXFamily.Id)} ASC";
			}
			return await this.Context.Set<StudentXFamily>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<StudentXFamily>();
		}

		private async Task<List<StudentXFamily>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(StudentXFamily.Id)} ASC";
			}

			return await this.Context.Set<StudentXFamily>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<StudentXFamily>();
		}

		private async Task<StudentXFamily> GetById(int id)
		{
			List<StudentXFamily> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>c27245e60a6e7354b913b35454fdb087</Hash>
</Codenesium>*/