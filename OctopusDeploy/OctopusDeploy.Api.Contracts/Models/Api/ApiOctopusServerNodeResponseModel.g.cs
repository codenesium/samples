using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public class ApiOctopusServerNodeResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        bool isInMaintenanceMode,
                        string jSON,
                        DateTimeOffset lastSeen,
                        int maxConcurrentTasks,
                        string name,
                        string rank)
                {
                        this.Id = id;
                        this.IsInMaintenanceMode = isInMaintenanceMode;
                        this.JSON = jSON;
                        this.LastSeen = lastSeen;
                        this.MaxConcurrentTasks = maxConcurrentTasks;
                        this.Name = name;
                        this.Rank = rank;
                }

                public string Id { get; private set; }

                public bool IsInMaintenanceMode { get; private set; }

                public string JSON { get; private set; }

                public DateTimeOffset LastSeen { get; private set; }

                public int MaxConcurrentTasks { get; private set; }

                public string Name { get; private set; }

                public string Rank { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIsInMaintenanceModeValue { get; set; } = true;

                public bool ShouldSerializeIsInMaintenanceMode()
                {
                        return this.ShouldSerializeIsInMaintenanceModeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeJSONValue { get; set; } = true;

                public bool ShouldSerializeJSON()
                {
                        return this.ShouldSerializeJSONValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLastSeenValue { get; set; } = true;

                public bool ShouldSerializeLastSeen()
                {
                        return this.ShouldSerializeLastSeenValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeMaxConcurrentTasksValue { get; set; } = true;

                public bool ShouldSerializeMaxConcurrentTasks()
                {
                        return this.ShouldSerializeMaxConcurrentTasksValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRankValue { get; set; } = true;

                public bool ShouldSerializeRank()
                {
                        return this.ShouldSerializeRankValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeIsInMaintenanceModeValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeLastSeenValue = false;
                        this.ShouldSerializeMaxConcurrentTasksValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeRankValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>579f95cc6f2e13a5503c034afb539f5e</Hash>
</Codenesium>*/