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
	public abstract class AbstractLessonXStudentRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractLessonXStudentRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOLessonXStudent> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOLessonXStudent Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOLessonXStudent Create(
			ApiLessonXStudentModel model)
		{
			LessonXStudent record = new LessonXStudent();

			this.Mapper.LessonXStudentMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<LessonXStudent>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.LessonXStudentMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiLessonXStudentModel model)
		{
			LessonXStudent record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.LessonXStudentMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			LessonXStudent record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<LessonXStudent>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOLessonXStudent> Where(Expression<Func<LessonXStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOLessonXStudent> SearchLinqPOCO(Expression<Func<LessonXStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLessonXStudent> response = new List<POCOLessonXStudent>();
			List<LessonXStudent> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.LessonXStudentMapEFToPOCO(x)));
			return response;
		}

		private List<LessonXStudent> SearchLinqEF(Expression<Func<LessonXStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(LessonXStudent.Id)} ASC";
			}
			return this.Context.Set<LessonXStudent>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<LessonXStudent>();
		}

		private List<LessonXStudent> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(LessonXStudent.Id)} ASC";
			}

			return this.Context.Set<LessonXStudent>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<LessonXStudent>();
		}
	}
}

/*<Codenesium>
    <Hash>eedeee8ab668bf75a4aab0c1cf883c8f</Hash>
</Codenesium>*/