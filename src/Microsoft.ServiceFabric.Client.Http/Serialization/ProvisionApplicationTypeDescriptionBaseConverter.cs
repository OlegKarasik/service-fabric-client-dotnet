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
    /// Converter for <see cref="ProvisionApplicationTypeDescriptionBase" />.
    /// </summary>
    internal class ProvisionApplicationTypeDescriptionBaseConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ProvisionApplicationTypeDescriptionBase Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ProvisionApplicationTypeDescriptionBase GetFromJsonProperties(JsonReader reader)
        {
            ProvisionApplicationTypeDescriptionBase obj;
            var propName = reader.ReadPropertyName();
            if (!propName.Equals("Kind", StringComparison.Ordinal))
            {
                throw new JsonReaderException($"Incorrect discriminator property name {propName}, Expected discriminator property name is Kind.");
            }

            var propValue = reader.ReadValueAsString();
            if (propValue.Equals("ImageStorePath", StringComparison.Ordinal))
            {
                obj = ProvisionApplicationTypeDescriptionConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("ExternalStore", StringComparison.Ordinal))
            {
                obj = ExternalStoreProvisionApplicationTypeDescriptionConverter.GetFromJsonProperties(reader);
            }
            else
            {
                throw new InvalidOperationException("Unknown Kind.");
            }

            return obj;
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ProvisionApplicationTypeDescriptionBase obj)
        {
            var kind = obj.Kind;

            if (kind.Equals(ProvisionApplicationTypeKind.ImageStorePath))
            {
                ProvisionApplicationTypeDescriptionConverter.Serialize(writer, (ProvisionApplicationTypeDescription)obj);
            }
            else if (kind.Equals(ProvisionApplicationTypeKind.ExternalStore))
            {
                ExternalStoreProvisionApplicationTypeDescriptionConverter.Serialize(writer, (ExternalStoreProvisionApplicationTypeDescription)obj);
            }
            else
            {
                throw new InvalidOperationException("Unknown Kind.");
            }
        }
    }
}
