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
    /// Converter for <see cref="NodeHealthState" />.
    /// </summary>
    internal class NodeHealthStateConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static NodeHealthState Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static NodeHealthState GetFromJsonProperties(JsonReader reader)
        {
            var aggregatedHealthState = default(HealthState?);
            var name = default(NodeName);
            var id = default(NodeId);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("AggregatedHealthState", propName, StringComparison.Ordinal) == 0)
                {
                    aggregatedHealthState = HealthStateConverter.Deserialize(reader);
                }
                else if (string.Compare("Name", propName, StringComparison.Ordinal) == 0)
                {
                    name = NodeNameConverter.Deserialize(reader);
                }
                else if (string.Compare("Id", propName, StringComparison.Ordinal) == 0)
                {
                    id = NodeIdConverter.Deserialize(reader);
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new NodeHealthState(
                aggregatedHealthState: aggregatedHealthState,
                name: name,
                id: id);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, NodeHealthState obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.AggregatedHealthState, "AggregatedHealthState", HealthStateConverter.Serialize);
            if (obj.Name != null)
            {
                writer.WriteProperty(obj.Name, "Name", NodeNameConverter.Serialize);
            }

            if (obj.Id != null)
            {
                writer.WriteProperty(obj.Id, "Id", NodeIdConverter.Serialize);
            }

            writer.WriteEndObject();
        }
    }
}
