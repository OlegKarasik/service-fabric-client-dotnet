// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.ServiceFabric.Client.Exceptions;
    using Microsoft.ServiceFabric.Common;
    using Microsoft.ServiceFabric.Common.Exceptions;

    /// <summary>
    /// Interface containing methods for performing PartitionClient operataions.
    /// </summary>
    public partial interface IPartitionClient
    {
        /// <summary>
        /// Gets the list of partitions of a Service Fabric service.
        /// </summary>
        /// <remarks>
        /// Gets the list of partitions of a Service Fabric service. The response includes the partition ID, partitioning
        /// scheme information, keys supported by the partition, status, health, and other details about the partition.
        /// </remarks>
        /// <param name ="serviceId">The identity of the service. This is typically the full name of the service without the
        /// 'fabric:' URI scheme.
        /// Starting from version 6.0, hierarchical names are delimited with the "~" character.
        /// For example, if the service name is "fabric:/myapp/app1/svc1", the service identity would be "myapp~app1~svc1" in
        /// 6.0+ and "myapp/app1/svc1" in previous versions.
        /// </param>
        /// <param name ="continuationToken">The continuation token to obtain next set of results</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<PagedData<ServicePartitionInfo>> GetPartitionInfoListAsync(
            string serviceId,
            ContinuationToken continuationToken = default(ContinuationToken),
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the information about a Service Fabric partition.
        /// </summary>
        /// <remarks>
        /// Gets the information about the specified partition. The response includes the partition ID, partitioning scheme
        /// information, keys supported by the partition, status, health, and other details about the partition.
        /// </remarks>
        /// <param name ="partitionId">The identity of the partition.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<ServicePartitionInfo> GetPartitionInfoAsync(
            PartitionId partitionId,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the name of the Service Fabric service for a partition.
        /// </summary>
        /// <remarks>
        /// Gets name of the service for the specified partition. A 404 error is returned if the partition ID does not exist in
        /// the cluster.
        /// </remarks>
        /// <param name ="partitionId">The identity of the partition.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<ServiceNameInfo> GetServiceNameInfoAsync(
            PartitionId partitionId,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the health of the specified Service Fabric partition.
        /// </summary>
        /// <remarks>
        /// Gets the health information of the specified partition.
        /// Use EventsHealthStateFilter to filter the collection of health events reported on the service based on the health
        /// state.
        /// Use ReplicasHealthStateFilter to filter the collection of ReplicaHealthState objects on the partition.
        /// If you specify a partition that does not exist in the health store, this request returns an error.
        /// </remarks>
        /// <param name ="partitionId">The identity of the partition.</param>
        /// <param name ="eventsHealthStateFilter">Allows filtering the collection of HealthEvent objects returned based on
        /// health state.
        /// The possible values for this parameter include integer value of one of the following health states.
        /// Only events that match the filter are returned. All events are used to evaluate the aggregated health state.
        /// If not specified, all entries are returned. The state values are flag based enumeration, so the value could be a
        /// combination of these value obtained using bitwise 'OR' operator. For example, If the provided value is 6 then all
        /// of the events with HealthState value of OK (2) and Warning (4) are returned.
        /// 
        /// - Default - Default value. Matches any HealthState. The value is zero.
        /// - None - Filter that doesn't match any HealthState value. Used in order to return no results on a given collection
        /// of states. The value is 1.
        /// - Ok - Filter that matches input with HealthState value Ok. The value is 2.
        /// - Warning - Filter that matches input with HealthState value Warning. The value is 4.
        /// - Error - Filter that matches input with HealthState value Error. The value is 8.
        /// - All - Filter that matches input with any HealthState value. The value is 65535.
        /// </param>
        /// <param name ="replicasHealthStateFilter">Allows filtering the collection of ReplicaHealthState objects on the
        /// partition. The value can be obtained from members or bitwise operations on members of HealthStateFilter. Only
        /// replicas that match the filter will be returned. All replicas will be used to evaluate the aggregated health state.
        /// If not specified, all entries will be returned.The state values are flag based enumeration, so the value could be a
        /// combination of these value obtained using bitwise 'OR' operator. For example, If the provided value is 6 then all
        /// of the events with HealthState value of OK (2) and Warning (4) will be returned. The possible values for this
        /// parameter include integer value of one of the following health states.
        /// 
        /// - Default - Default value. Matches any HealthState. The value is zero.
        /// - None - Filter that doesn't match any HealthState value. Used in order to return no results on a given collection
        /// of states. The value is 1.
        /// - Ok - Filter that matches input with HealthState value Ok. The value is 2.
        /// - Warning - Filter that matches input with HealthState value Warning. The value is 4.
        /// - Error - Filter that matches input with HealthState value Error. The value is 8.
        /// - All - Filter that matches input with any HealthState value. The value is 65535.
        /// </param>
        /// <param name ="excludeHealthStatistics">Indicates whether the health statistics should be returned as part of the
        /// query result. False by default.
        /// The statistics show the number of children entities in health state Ok, Warning, and Error.
        /// </param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<PartitionHealth> GetPartitionHealthAsync(
            PartitionId partitionId,
            int? eventsHealthStateFilter = 0,
            int? replicasHealthStateFilter = 0,
            bool? excludeHealthStatistics = false,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the health of the specified Service Fabric partition, by using the specified health policy.
        /// </summary>
        /// <remarks>
        /// Gets the health information of the specified partition.
        /// If the application health policy is specified, the health evaluation uses it to get the aggregated health state.
        /// If the policy is not specified, the health evaluation uses the application health policy defined in the application
        /// manifest, or the default health policy, if no policy is defined in the manifest.
        /// Use EventsHealthStateFilter to filter the collection of health events reported on the partition based on the health
        /// state.
        /// Use ReplicasHealthStateFilter to filter the collection of ReplicaHealthState objects on the partition. Use
        /// ApplicationHealthPolicy in the POST body to override the health policies used to evaluate the health.
        /// If you specify a partition that does not exist in the health store, this request returns an error.
        /// </remarks>
        /// <param name ="partitionId">The identity of the partition.</param>
        /// <param name ="eventsHealthStateFilter">Allows filtering the collection of HealthEvent objects returned based on
        /// health state.
        /// The possible values for this parameter include integer value of one of the following health states.
        /// Only events that match the filter are returned. All events are used to evaluate the aggregated health state.
        /// If not specified, all entries are returned. The state values are flag based enumeration, so the value could be a
        /// combination of these value obtained using bitwise 'OR' operator. For example, If the provided value is 6 then all
        /// of the events with HealthState value of OK (2) and Warning (4) are returned.
        /// 
        /// - Default - Default value. Matches any HealthState. The value is zero.
        /// - None - Filter that doesn't match any HealthState value. Used in order to return no results on a given collection
        /// of states. The value is 1.
        /// - Ok - Filter that matches input with HealthState value Ok. The value is 2.
        /// - Warning - Filter that matches input with HealthState value Warning. The value is 4.
        /// - Error - Filter that matches input with HealthState value Error. The value is 8.
        /// - All - Filter that matches input with any HealthState value. The value is 65535.
        /// </param>
        /// <param name ="replicasHealthStateFilter">Allows filtering the collection of ReplicaHealthState objects on the
        /// partition. The value can be obtained from members or bitwise operations on members of HealthStateFilter. Only
        /// replicas that match the filter will be returned. All replicas will be used to evaluate the aggregated health state.
        /// If not specified, all entries will be returned.The state values are flag based enumeration, so the value could be a
        /// combination of these value obtained using bitwise 'OR' operator. For example, If the provided value is 6 then all
        /// of the events with HealthState value of OK (2) and Warning (4) will be returned. The possible values for this
        /// parameter include integer value of one of the following health states.
        /// 
        /// - Default - Default value. Matches any HealthState. The value is zero.
        /// - None - Filter that doesn't match any HealthState value. Used in order to return no results on a given collection
        /// of states. The value is 1.
        /// - Ok - Filter that matches input with HealthState value Ok. The value is 2.
        /// - Warning - Filter that matches input with HealthState value Warning. The value is 4.
        /// - Error - Filter that matches input with HealthState value Error. The value is 8.
        /// - All - Filter that matches input with any HealthState value. The value is 65535.
        /// </param>
        /// <param name ="applicationHealthPolicy">Describes the health policies used to evaluate the health of an application
        /// or one of its children.
        /// If not present, the health evaluation uses the health policy from application manifest or the default health
        /// policy.
        /// </param>
        /// <param name ="excludeHealthStatistics">Indicates whether the health statistics should be returned as part of the
        /// query result. False by default.
        /// The statistics show the number of children entities in health state Ok, Warning, and Error.
        /// </param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<PartitionHealth> GetPartitionHealthUsingPolicyAsync(
            PartitionId partitionId,
            int? eventsHealthStateFilter = 0,
            int? replicasHealthStateFilter = 0,
            ApplicationHealthPolicy applicationHealthPolicy = default(ApplicationHealthPolicy),
            bool? excludeHealthStatistics = false,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Sends a health report on the Service Fabric partition.
        /// </summary>
        /// <remarks>
        /// Reports health state of the specified Service Fabric partition. The report must contain the information about the
        /// source of the health report and property on which it is reported.
        /// The report is sent to a Service Fabric gateway Partition, which forwards to the health store.
        /// The report may be accepted by the gateway, but rejected by the health store after extra validation.
        /// For example, the health store may reject the report because of an invalid parameter, like a stale sequence number.
        /// To see whether the report was applied in the health store, run GetPartitionHealth and check that the report appears
        /// in the HealthEvents section.
        /// </remarks>
        /// <param name ="partitionId">The identity of the partition.</param>
        /// <param name ="healthInformation">Describes the health information for the health report. This information needs to
        /// be present in all of the health reports sent to the health manager.</param>
        /// <param name ="immediate">A flag which indicates whether the report should be sent immediately.
        /// A health report is sent to a Service Fabric gateway Application, which forwards to the health store.
        /// If Immediate is set to true, the report is sent immediately from HTTP Gateway to the health store, regardless of
        /// the fabric client settings that the HTTP Gateway Application is using.
        /// This is useful for critical reports that should be sent as soon as possible.
        /// Depending on timing and other conditions, sending the report may still fail, for example if the HTTP Gateway is
        /// closed or the message doesn't reach the Gateway.
        /// If Immediate is set to false, the report is sent based on the health client settings from the HTTP Gateway.
        /// Therefore, it will be batched according to the HealthReportSendInterval configuration.
        /// This is the recommended setting because it allows the health client to optimize health reporting messages to health
        /// store as well as health report processing.
        /// By default, reports are not sent immediately.
        /// </param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task ReportPartitionHealthAsync(
            PartitionId partitionId,
            HealthInformation healthInformation,
            bool? immediate = false,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the load information of the specified Service Fabric partition.
        /// </summary>
        /// <remarks>
        /// Returns information about the load of a specified partition.
        /// The response includes a list of load reports for a Service Fabric partition.
        /// Each report includes the load metric name, value, and last reported time in UTC.
        /// </remarks>
        /// <param name ="partitionId">The identity of the partition.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task<PartitionLoadInformation> GetPartitionLoadInformationAsync(
            PartitionId partitionId,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Resets the current load of a Service Fabric partition.
        /// </summary>
        /// <remarks>
        /// Resets the current load of a Service Fabric partition to the default load for the service.
        /// </remarks>
        /// <param name ="partitionId">The identity of the partition.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task ResetPartitionLoadAsync(
            PartitionId partitionId,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Indicates to the Service Fabric cluster that it should attempt to recover a specific partition which is currently
        /// stuck in quorum loss.
        /// </summary>
        /// <remarks>
        /// Indicates to the Service Fabric cluster that it should attempt to recover a specific partition which is currently
        /// stuck in quorum loss. This operation should only be performed if it is known that the replicas that are down cannot
        /// be recovered. Incorrect use of this API can cause potential data loss.
        /// </remarks>
        /// <param name ="partitionId">The identity of the partition.</param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task RecoverPartitionAsync(
            PartitionId partitionId,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Indicates to the Service Fabric cluster that it should attempt to recover the specified service which is currently
        /// stuck in quorum loss.
        /// </summary>
        /// <remarks>
        /// Indicates to the Service Fabric cluster that it should attempt to recover the specified service which is currently
        /// stuck in quorum loss. This operation should only be performed if it is known that the replicas that are down cannot
        /// be recovered. Incorrect use of this API can cause potential data loss.
        /// </remarks>
        /// <param name ="serviceId">The identity of the service. This is typically the full name of the service without the
        /// 'fabric:' URI scheme.
        /// Starting from version 6.0, hierarchical names are delimited with the "~" character.
        /// For example, if the service name is "fabric:/myapp/app1/svc1", the service identity would be "myapp~app1~svc1" in
        /// 6.0+ and "myapp/app1/svc1" in previous versions.
        /// </param>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task RecoverServicePartitionsAsync(
            string serviceId,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Indicates to the Service Fabric cluster that it should attempt to recover the system services which are currently
        /// stuck in quorum loss.
        /// </summary>
        /// <remarks>
        /// Indicates to the Service Fabric cluster that it should attempt to recover the system services which are currently
        /// stuck in quorum loss. This operation should only be performed if it is known that the replicas that are down cannot
        /// be recovered. Incorrect use of this API can cause potential data loss.
        /// </remarks>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task RecoverSystemPartitionsAsync(
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Indicates to the Service Fabric cluster that it should attempt to recover any services (including system services)
        /// which are currently stuck in quorum loss.
        /// </summary>
        /// <remarks>
        /// Indicates to the Service Fabric cluster that it should attempt to recover any services (including system services)
        /// which are currently stuck in quorum loss. This operation should only be performed if it is known that the replicas
        /// that are down cannot be recovered. Incorrect use of this API can cause potential data loss.
        /// </remarks>
        /// <param name ="serverTimeout">The server timeout for performing the operation in seconds. This timeout specifies the
        /// time duration that the client is willing to wait for the requested operation to complete. The default value for
        /// this parameter is 60 seconds.</param>
        /// <param name ="cancellationToken">Cancels the client-side operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        /// <exception cref="InvalidCredentialsException">Thrown when invalid credentials are used while making request to cluster.</exception>
        /// <exception cref="ServiceFabricRequestException">Thrown when request to Service Fabric cluster failed due to an underlying issue such as network connectivity, DNS failure or timeout.</exception>
        /// <exception cref="ServiceFabricException">Thrown when the requested operation failed at server. Exception contains Error code <see cref="FabricError.ErrorCode"/>, message indicating the failure. It also contains a flag wether the exception is transient or not, client operations can be retried if its transient.</exception>
        /// <exception cref="OperationCanceledException">Thrown when cancellation is requested for the cancellation token.</exception>
        Task RecoverAllPartitionsAsync(
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
