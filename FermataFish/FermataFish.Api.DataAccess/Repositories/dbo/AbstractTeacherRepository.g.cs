using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractTeacherRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractTeacherRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOTeacher> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOTeacher Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOTeacher Create(
			ApiTeacherModel model)
		{
			Teacher record = new Teacher();

			this.Mapper.TeacherMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Teacher>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.TeacherMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiTeacherModel model)
		{
			Teacher record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.TeacherMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Teacher record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Teacher>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOTeacher> Where(Expression<Func<Teacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOTeacher> SearchLinqPOCO(Expression<Func<Teacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOTeacher> response = new List<POCOTeacher>();
			List<Teacher> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.TeacherMapEFToPOCO(x)));
			return response;
		}

		private List<Teacher> SearchLinqEF(Expression<Func<Teacher, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Teacher.Id)} ASC";
			}
			return this.Context.Set<Teacher>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Teacher>();
		}

		private List<Teacher> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Teacher.Id)} ASC";
			}

			return this.Context.Set<Teacher>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Teacher>();
		}
	}
}

/*<Codenesium>
    <Hash>89fb502e662cc9457d23d7dc290f2fb8</Hash>
</Codenesium>*/