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
    /// Converter for <see cref="NamedPartitionSchemeDescription" />.
    /// </summary>
    internal class NamedPartitionSchemeDescriptionConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static NamedPartitionSchemeDescription Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static NamedPartitionSchemeDescription GetFromJsonProperties(JsonReader reader)
        {
            var count = default(int?);
            var names = default(IEnumerable<string>);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("Count", propName, StringComparison.Ordinal) == 0)
                {
                    count = reader.ReadValueAsInt();
                }
                else if (string.Compare("Names", propName, StringComparison.Ordinal) == 0)
                {
                    names = reader.ReadList(JsonReaderExtensions.ReadValueAsString);
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new NamedPartitionSchemeDescription(
                count: count,
                names: names);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, NamedPartitionSchemeDescription obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.PartitionScheme.ToString(), "PartitionScheme", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.Count, "Count", JsonWriterExtensions.WriteIntValue);
            writer.WriteEnumerableProperty(obj.Names, "Names", (w, v) => writer.WriteStringValue(v));
            writer.WriteEndObject();
        }
    }
}
