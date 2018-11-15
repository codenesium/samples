using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public abstract class AbstractIntegrationTestMigration
	{
		protected ApplicationDbContext Context { get; private set; }

		public AbstractIntegrationTestMigration(ApplicationDbContext context)
		{
			this.Context = context;
		}

		public virtual async void Migrate()
		{
			var columnSameAsFKTableItem1 = new ColumnSameAsFKTable();
			columnSameAsFKTableItem1.SetProperties(1, 1, 1);
			this.Context.ColumnSameAsFKTables.Add(columnSameAsFKTableItem1);

			var compositePrimaryKeyItem1 = new CompositePrimaryKey();
			compositePrimaryKeyItem1.SetProperties(1, 1);
			this.Context.CompositePrimaryKeys.Add(compositePrimaryKeyItem1);

			var includedColumnTestItem1 = new IncludedColumnTest();
			includedColumnTestItem1.SetProperties(1, "A", "A");
			this.Context.IncludedColumnTests.Add(includedColumnTestItem1);

			var personItem1 = new Person();
			personItem1.SetProperties(1, "A");
			this.Context.People.Add(personItem1);

			var rowVersionCheckItem1 = new RowVersionCheck();
			rowVersionCheckItem1.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			this.Context.RowVersionChecks.Add(rowVersionCheckItem1);

			var selfReferenceItem1 = new SelfReference();
			selfReferenceItem1.SetProperties(1, 1, 1);
			this.Context.SelfReferences.Add(selfReferenceItem1);

			var tableItem1 = new Table();
			tableItem1.SetProperties(1, "A");
			this.Context.Tables.Add(tableItem1);

			var testAllFieldTypeItem1 = new TestAllFieldType();
			testAllFieldTypeItem1.SetProperties(1, BitConverter.GetBytes(1), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), 1, 1, BitConverter.GetBytes(1), 1m, "A", "A", 1m, "A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, "A", TimeSpan.Parse("01:00:00"), BitConverter.GetBytes(1), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), BitConverter.GetBytes(1), "A", "A", 1);
			this.Context.TestAllFieldTypes.Add(testAllFieldTypeItem1);

			var testAllFieldTypesNullableItem1 = new TestAllFieldTypesNullable();
			testAllFieldTypesNullableItem1.SetProperties(1, BitConverter.GetBytes(1), true, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), 1, 1, BitConverter.GetBytes(1), 1m, "A", "A", 1m, "A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, "A", TimeSpan.Parse("01:00:00"), BitConverter.GetBytes(1), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), BitConverter.GetBytes(1), "A", "A", 1);
			this.Context.TestAllFieldTypesNullables.Add(testAllFieldTypesNullableItem1);

			var timestampCheckItem1 = new TimestampCheck();
			timestampCheckItem1.SetProperties(1, "A", BitConverter.GetBytes(1));
			this.Context.TimestampChecks.Add(timestampCheckItem1);

			var vPersonItem1 = new VPerson();
			vPersonItem1.SetProperties(1, "A");
			this.Context.VPersons.Add(vPersonItem1);

			await this.Context.SaveChangesAsync();

			var schemaAPersonItem1 = new SchemaAPerson();
			schemaAPersonItem1.SetProperties(1, "A");
			this.Context.SchemaAPersons.Add(schemaAPersonItem1);

			await this.Context.SaveChangesAsync();

			var schemaBPersonItem1 = new SchemaBPerson();
			schemaBPersonItem1.SetProperties(1, "A");
			this.Context.SchemaBPersons.Add(schemaBPersonItem1);

			var personRefItem1 = new PersonRef();
			personRefItem1.SetProperties(1, 1, 1);
			this.Context.PersonRefs.Add(personRefItem1);

			await this.Context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>832bfca7b62c94470cf6df144d736738</Hash>
</Codenesium>*/