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
    /// Converter for <see cref="StoppedChaosEvent" />.
    /// </summary>
    internal class StoppedChaosEventConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static StoppedChaosEvent Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static StoppedChaosEvent GetFromJsonProperties(JsonReader reader)
        {
            var timeStampUtc = default(DateTime?);
            var reason = default(string);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("TimeStampUtc", propName, StringComparison.Ordinal) == 0)
                {
                    timeStampUtc = reader.ReadValueAsDateTime();
                }
                else if (string.Compare("Reason", propName, StringComparison.Ordinal) == 0)
                {
                    reason = reader.ReadValueAsString();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new StoppedChaosEvent(
                timeStampUtc: timeStampUtc,
                reason: reason);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, StoppedChaosEvent obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Kind.ToString(), "Kind", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.TimeStampUtc, "TimeStampUtc", JsonWriterExtensions.WriteDateTimeValue);
            if (obj.Reason != null)
            {
                writer.WriteProperty(obj.Reason, "Reason", JsonWriterExtensions.WriteStringValue);
            }

            writer.WriteEndObject();
        }
    }
}
