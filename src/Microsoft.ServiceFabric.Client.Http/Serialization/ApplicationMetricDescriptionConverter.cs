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
    /// Converter for <see cref="ApplicationMetricDescription" />.
    /// </summary>
    internal class ApplicationMetricDescriptionConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ApplicationMetricDescription Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static ApplicationMetricDescription GetFromJsonProperties(JsonReader reader)
        {
            var name = default(string);
            var maximumCapacity = default(long?);
            var reservationCapacity = default(long?);
            var totalApplicationCapacity = default(long?);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("Name", propName, StringComparison.Ordinal) == 0)
                {
                    name = reader.ReadValueAsString();
                }
                else if (string.Compare("MaximumCapacity", propName, StringComparison.Ordinal) == 0)
                {
                    maximumCapacity = reader.ReadValueAsLong();
                }
                else if (string.Compare("ReservationCapacity", propName, StringComparison.Ordinal) == 0)
                {
                    reservationCapacity = reader.ReadValueAsLong();
                }
                else if (string.Compare("TotalApplicationCapacity", propName, StringComparison.Ordinal) == 0)
                {
                    totalApplicationCapacity = reader.ReadValueAsLong();
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new ApplicationMetricDescription(
                name: name,
                maximumCapacity: maximumCapacity,
                reservationCapacity: reservationCapacity,
                totalApplicationCapacity: totalApplicationCapacity);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ApplicationMetricDescription obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            if (obj.Name != null)
            {
                writer.WriteProperty(obj.Name, "Name", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.MaximumCapacity != null)
            {
                writer.WriteProperty(obj.MaximumCapacity, "MaximumCapacity", JsonWriterExtensions.WriteLongValue);
            }

            if (obj.ReservationCapacity != null)
            {
                writer.WriteProperty(obj.ReservationCapacity, "ReservationCapacity", JsonWriterExtensions.WriteLongValue);
            }

            if (obj.TotalApplicationCapacity != null)
            {
                writer.WriteProperty(obj.TotalApplicationCapacity, "TotalApplicationCapacity", JsonWriterExtensions.WriteLongValue);
            }

            writer.WriteEndObject();
        }
    }
}
