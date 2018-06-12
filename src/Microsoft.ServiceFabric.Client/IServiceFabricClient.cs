// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client
{
    /// <summary>
    /// Interface for Service Fabric client.
    /// </summary>
    public interface IServiceFabricClient
    {
        /// <summary>
        /// Gets Application Client to performs management operations on applications.
        /// </summary>
        /// <returns>The <see cref="IApplicationClient"/></returns>
        IApplicationClient Applications { get; }

        /// <summary>
        /// Gets ApplicationType Client to performs management operations on application types.
        /// </summary>
        /// <returns>The <see cref="IApplicationTypeClient"/></returns>
        IApplicationTypeClient ApplicationTypes { get; }

        /// <summary>
        /// Gets BackupRestore to perform backup and restore operations.
        /// </summary>
        /// <returns>The <see cref="IBackupRestoreClient"/></returns>
        IBackupRestoreClient BackupRestore { get; }

        /// <summary>
        /// Gets Chaos Client to perform chaos operations.
        /// </summary>
        /// <returns>The <see cref="IChaosClient"/></returns>
        IChaosClient ChaosClient { get; }

        /// <summary>
        /// Gets Cluster Client to perform cluster operations.
        /// </summary>
        /// <returns>The <see cref="IClusterClient"/></returns>
        IClusterClient Cluster { get; }

        /// <summary>
        /// Gets CodePackage Client to perform operations on a code package.
        /// </summary>
        /// <returns>The <see cref="ICodePackageClient"/></returns>
        ICodePackageClient CodePackages { get; }

        /// <summary>
        /// Gets ComposeDeployment Client to perform compose deployment related operations.
        /// </summary>
        /// <returns>The <see cref="IComposeDeploymentClient"/></returns>
        IComposeDeploymentClient ComposeDeployments { get; }

        /// <summary>
        /// Gets Faults Client to perform Faults in the cluster application and services.
        /// </summary>
        /// <returns>The <see cref="IFaultsClient"/></returns>
        IFaultsClient Faults { get; }

        /// <summary>
        /// Gets ImageStore Client to performs management operations on image store.
        /// </summary>
        /// <returns>The <see cref="IImageStoreClient"/></returns>
        IImageStoreClient ImageStore { get; }

        /// <summary>
        /// Gets Infrastructure Client to perform operations for Infrastructure service..
        /// </summary>
        /// <returns>The <see cref="IInfrastructureClient"/></returns>
        IInfrastructureClient Infrastructure { get; }

        /// <summary>
        /// Gets Node Client to performs management operations for nodes in the cluster.
        /// </summary>
        /// <returns>The <see cref="INodeClient"/></returns>
        INodeClient Nodes { get; }

        /// <summary>
        /// Gets Partition Client to performs management operations on partitions.
        /// </summary>
        /// <returns>The <see cref="IPartitionClient"/></returns>
        IPartitionClient Partitions { get; }

        /// <summary>
        /// Gets Property Client to manage properties.
        /// </summary>
        /// <returns>The <see cref="IPropertyManagementClient"/></returns>
        IPropertyManagementClient Properties { get; }

        /// <summary>
        /// Gets Replica Client to performs management operations on service replicas.
        /// </summary>
        /// <returns>The <see cref="IReplicaClient"/></returns>
        IReplicaClient Replicas { get; }

        /// <summary>
        /// Gets Repair management client to performs repair operations..
        /// </summary>
        /// <returns>The <see cref="IRepairManagementClient"/></returns>
        IRepairManagementClient Repairs { get; }

        /// <summary>
        /// Gets Service Client to performs management operations on services.
        /// </summary>
        /// <returns>The <see cref="IServiceClient"/></returns>
        IServiceClient Services { get; }

        /// <summary>
        /// Gets ServicePackage Client to performs management operations on service packages.
        /// </summary>
        /// <returns>The <see cref="IServicePackageClient"/></returns>
        IServicePackageClient ServicePackages { get; }

        /// <summary>
        /// Gets ServiceType Client to performs management operations on service types.
        /// </summary>
        /// <returns>The <see cref="IServiceTypeClient"/></returns>
        IServiceTypeClient ServiceTypes { get; }

        /// <summary>
        /// Gets EventStore Client to query events related to applciaitons, services replicas and contianers..
        /// </summary>
        /// <returns>The <see cref="IEventsStoreClient"/></returns>
        IEventsStoreClient EventsStore { get; }
    }
}
