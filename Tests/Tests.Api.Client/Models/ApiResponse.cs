using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestsNS.Api.Client
{
	public partial class ApiResponse
	{
		public ApiResponse()
		{
		}

		public void Merge(ApiResponse from)
		{
			from.ColumnSameAsFKTables.ForEach(x => this.AddColumnSameAsFKTable(x));
			from.IncludedColumnTests.ForEach(x => this.AddIncludedColumnTest(x));
			from.People.ForEach(x => this.AddPerson(x));
			from.RowVersionChecks.ForEach(x => this.AddRowVersionCheck(x));
			from.SelfReferences.ForEach(x => this.AddSelfReference(x));
			from.Tables.ForEach(x => this.AddTable(x));
			from.TestAllFieldTypes.ForEach(x => this.AddTestAllFieldType(x));
			from.TestAllFieldTypesNullables.ForEach(x => this.AddTestAllFieldTypesNullable(x));
			from.TimestampChecks.ForEach(x => this.AddTimestampCheck(x));
			from.VPersons.ForEach(x => this.AddVPerson(x));
		}

		public List<ApiColumnSameAsFKTableClientResponseModel> ColumnSameAsFKTables { get; private set; } = new List<ApiColumnSameAsFKTableClientResponseModel>();

		public List<ApiIncludedColumnTestClientResponseModel> IncludedColumnTests { get; private set; } = new List<ApiIncludedColumnTestClientResponseModel>();

		public List<ApiPersonClientResponseModel> People { get; private set; } = new List<ApiPersonClientResponseModel>();

		public List<ApiRowVersionCheckClientResponseModel> RowVersionChecks { get; private set; } = new List<ApiRowVersionCheckClientResponseModel>();

		public List<ApiSelfReferenceClientResponseModel> SelfReferences { get; private set; } = new List<ApiSelfReferenceClientResponseModel>();

		public List<ApiTableClientResponseModel> Tables { get; private set; } = new List<ApiTableClientResponseModel>();

		public List<ApiTestAllFieldTypeClientResponseModel> TestAllFieldTypes { get; private set; } = new List<ApiTestAllFieldTypeClientResponseModel>();

		public List<ApiTestAllFieldTypesNullableClientResponseModel> TestAllFieldTypesNullables { get; private set; } = new List<ApiTestAllFieldTypesNullableClientResponseModel>();

		public List<ApiTimestampCheckClientResponseModel> TimestampChecks { get; private set; } = new List<ApiTimestampCheckClientResponseModel>();

		public List<ApiVPersonClientResponseModel> VPersons { get; private set; } = new List<ApiVPersonClientResponseModel>();

		public void AddColumnSameAsFKTable(ApiColumnSameAsFKTableClientResponseModel item)
		{
			if (!this.ColumnSameAsFKTables.Any(x => x.Id == item.Id))
			{
				this.ColumnSameAsFKTables.Add(item);
			}
		}

		public void AddIncludedColumnTest(ApiIncludedColumnTestClientResponseModel item)
		{
			if (!this.IncludedColumnTests.Any(x => x.Id == item.Id))
			{
				this.IncludedColumnTests.Add(item);
			}
		}

		public void AddPerson(ApiPersonClientResponseModel item)
		{
			if (!this.People.Any(x => x.PersonId == item.PersonId))
			{
				this.People.Add(item);
			}
		}

		public void AddRowVersionCheck(ApiRowVersionCheckClientResponseModel item)
		{
			if (!this.RowVersionChecks.Any(x => x.Id == item.Id))
			{
				this.RowVersionChecks.Add(item);
			}
		}

		public void AddSelfReference(ApiSelfReferenceClientResponseModel item)
		{
			if (!this.SelfReferences.Any(x => x.Id == item.Id))
			{
				this.SelfReferences.Add(item);
			}
		}

		public void AddTable(ApiTableClientResponseModel item)
		{
			if (!this.Tables.Any(x => x.Id == item.Id))
			{
				this.Tables.Add(item);
			}
		}

		public void AddTestAllFieldType(ApiTestAllFieldTypeClientResponseModel item)
		{
			if (!this.TestAllFieldTypes.Any(x => x.Id == item.Id))
			{
				this.TestAllFieldTypes.Add(item);
			}
		}

		public void AddTestAllFieldTypesNullable(ApiTestAllFieldTypesNullableClientResponseModel item)
		{
			if (!this.TestAllFieldTypesNullables.Any(x => x.Id == item.Id))
			{
				this.TestAllFieldTypesNullables.Add(item);
			}
		}

		public void AddTimestampCheck(ApiTimestampCheckClientResponseModel item)
		{
			if (!this.TimestampChecks.Any(x => x.Id == item.Id))
			{
				this.TimestampChecks.Add(item);
			}
		}

		public void AddVPerson(ApiVPersonClientResponseModel item)
		{
			if (!this.VPersons.Any(x => x.PersonId == item.PersonId))
			{
				this.VPersons.Add(item);
			}
		}
	}
}

/*<Codenesium>
    <Hash>9be62f1a0526a7602bf1e76129b77600</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/