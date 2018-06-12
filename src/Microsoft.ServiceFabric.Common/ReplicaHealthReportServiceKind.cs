// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    /// <summary>
    /// Defines values for ReplicaHealthReportServiceKind.
    /// </summary>
    public enum ReplicaHealthReportServiceKind
    {
        /// <summary>
        /// Does not use Service Fabric to make its state highly available or reliable. The value is 1.
        /// </summary>
        Stateless,

        /// <summary>
        /// Uses Service Fabric to make its state or part of its state highly available and reliable. The value is 2..
        /// </summary>
        Stateful,
    }
}
