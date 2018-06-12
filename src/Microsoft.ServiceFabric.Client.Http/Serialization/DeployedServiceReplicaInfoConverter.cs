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
    /// Converter for <see cref="DeployedServiceReplicaInfo" />.
    /// </summary>
    internal class DeployedServiceReplicaInfoConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static DeployedServiceReplicaInfo Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static DeployedServiceReplicaInfo GetFromJsonProperties(JsonReader reader)
        {
            DeployedServiceReplicaInfo obj;
            var propName = reader.ReadPropertyName();
            if (!propName.Equals("ServiceKind", StringComparison.Ordinal))
            {
                throw new JsonReaderException($"Incorrect discriminator property name {propName}, Expected discriminator property name is ServiceKind.");
            }

            var propValue = reader.ReadValueAsString();
            if (propValue.Equals("Stateful", StringComparison.Ordinal))
            {
                obj = DeployedStatefulServiceReplicaInfoConverter.GetFromJsonProperties(reader);
            }
            else if (propValue.Equals("Stateless", StringComparison.Ordinal))
            {
                obj = DeployedStatelessServiceInstanceInfoConverter.GetFromJsonProperties(reader);
            }
            else
            {
                throw new InvalidOperationException("Unknown ServiceKind.");
            }

            return obj;
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, DeployedServiceReplicaInfo obj)
        {
            var kind = obj.ServiceKind;

            if (kind.Equals(ServiceKind.Stateful))
            {
                DeployedStatefulServiceReplicaInfoConverter.Serialize(writer, (DeployedStatefulServiceReplicaInfo)obj);
            }
            else if (kind.Equals(ServiceKind.Stateless))
            {
                DeployedStatelessServiceInstanceInfoConverter.Serialize(writer, (DeployedStatelessServiceInstanceInfo)obj);
            }
            else
            {
                throw new InvalidOperationException("Unknown ServiceKind.");
            }
        }
    }
}
