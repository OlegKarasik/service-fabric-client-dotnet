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
    /// Converter for <see cref="EntityHealthStateChunkList" />.
    /// </summary>
    internal class EntityHealthStateChunkListConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static EntityHealthStateChunkList Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static EntityHealthStateChunkList GetFromJsonProperties(JsonReader reader)
        {
            var totalCount = default(long?);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("TotalCount", propName, StringComparison.Ordinal) == 0)
                {
                    totalCount = reader.ReadValueAsLong();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new EntityHealthStateChunkList(
                totalCount: totalCount);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, EntityHealthStateChunkList obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            if (obj.TotalCount != null)
            {
                writer.WriteProperty(obj.TotalCount, "TotalCount", JsonWriterExtensions.WriteLongValue);
            }

            writer.WriteEndObject();
        }
    }
}
