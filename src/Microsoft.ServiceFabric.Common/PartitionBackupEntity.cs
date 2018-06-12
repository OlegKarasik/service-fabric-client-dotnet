// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Identifies the Service Fabric stateful partition which is being backed up.
    /// </summary>
    public partial class PartitionBackupEntity : BackupEntity
    {
        /// <summary>
        /// Initializes a new instance of the PartitionBackupEntity class.
        /// </summary>
        /// <param name="serviceName">The full name of the service with 'fabric:' URI scheme.</param>
        /// <param name="partitionId">An internal ID used by Service Fabric to uniquely identify a partition. This is a
        /// randomly generated GUID when the service was created. The partition ID is unique and does not change for the
        /// lifetime of the service. If the same service was deleted and recreated the IDs of its partitions would be
        /// different.</param>
        public PartitionBackupEntity(
            ServiceName serviceName = default(ServiceName),
            PartitionId partitionId = default(PartitionId))
            : base(
                Common.BackupEntityKind.Partition)
        {
            this.ServiceName = serviceName;
            this.PartitionId = partitionId;
        }

        /// <summary>
        /// Gets the full name of the service with 'fabric:' URI scheme.
        /// </summary>
        public ServiceName ServiceName { get; }

        /// <summary>
        /// Gets an internal ID used by Service Fabric to uniquely identify a partition. This is a randomly generated GUID when
        /// the service was created. The partition ID is unique and does not change for the lifetime of the service. If the
        /// same service was deleted and recreated the IDs of its partitions would be different.
        /// </summary>
        public PartitionId PartitionId { get; }
    }
}
