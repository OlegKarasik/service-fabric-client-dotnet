// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client.Http.Serialization
{
    using System;
    using System.Collections.Generic;
    using Microsoft.ServiceFabric.Common;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Converter for <see cref="UpgradeDomainNodesHealthEvaluation" />.
    /// </summary>
    internal class UpgradeDomainNodesHealthEvaluationConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static UpgradeDomainNodesHealthEvaluation Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static UpgradeDomainNodesHealthEvaluation GetFromJsonProperties(JsonReader reader)
        {
            var aggregatedHealthState = default(HealthState?);
            var description = default(string);
            var upgradeDomainName = default(string);
            var maxPercentUnhealthyNodes = default(int?);
            var totalCount = default(long?);
            var unhealthyEvaluations = default(IEnumerable<HealthEvaluationWrapper>);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("AggregatedHealthState", propName, StringComparison.Ordinal) == 0)
                {
                    aggregatedHealthState = HealthStateConverter.Deserialize(reader);
                }
                else if (string.Compare("Description", propName, StringComparison.Ordinal) == 0)
                {
                    description = reader.ReadValueAsString();
                }
                else if (string.Compare("UpgradeDomainName", propName, StringComparison.Ordinal) == 0)
                {
                    upgradeDomainName = reader.ReadValueAsString();
                }
                else if (string.Compare("MaxPercentUnhealthyNodes", propName, StringComparison.Ordinal) == 0)
                {
                    maxPercentUnhealthyNodes = reader.ReadValueAsInt();
                }
                else if (string.Compare("TotalCount", propName, StringComparison.Ordinal) == 0)
                {
                    totalCount = reader.ReadValueAsLong();
                }
                else if (string.Compare("UnhealthyEvaluations", propName, StringComparison.Ordinal) == 0)
                {
                    unhealthyEvaluations = reader.ReadList(HealthEvaluationWrapperConverter.Deserialize);
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new UpgradeDomainNodesHealthEvaluation(
                aggregatedHealthState: aggregatedHealthState,
                description: description,
                upgradeDomainName: upgradeDomainName,
                maxPercentUnhealthyNodes: maxPercentUnhealthyNodes,
                totalCount: totalCount,
                unhealthyEvaluations: unhealthyEvaluations);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, UpgradeDomainNodesHealthEvaluation obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Kind.ToString(), "Kind", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.AggregatedHealthState, "AggregatedHealthState", HealthStateConverter.Serialize);
            if (obj.Description != null)
            {
                writer.WriteProperty(obj.Description, "Description", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.UpgradeDomainName != null)
            {
                writer.WriteProperty(obj.UpgradeDomainName, "UpgradeDomainName", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.MaxPercentUnhealthyNodes != null)
            {
                writer.WriteProperty(obj.MaxPercentUnhealthyNodes, "MaxPercentUnhealthyNodes", JsonWriterExtensions.WriteIntValue);
            }

            if (obj.TotalCount != null)
            {
                writer.WriteProperty(obj.TotalCount, "TotalCount", JsonWriterExtensions.WriteLongValue);
            }

            if (obj.UnhealthyEvaluations != null)
            {
                writer.WriteEnumerableProperty(obj.UnhealthyEvaluations, "UnhealthyEvaluations", HealthEvaluationWrapperConverter.Serialize);
            }

            writer.WriteEndObject();
        }
    }
}
