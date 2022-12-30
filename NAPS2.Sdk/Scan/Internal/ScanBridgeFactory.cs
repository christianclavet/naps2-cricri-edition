﻿namespace NAPS2.Scan.Internal;

internal class ScanBridgeFactory : IScanBridgeFactory
{
    private readonly InProcScanBridge _inProcScanBridge;
    private readonly WorkerScanBridge _workerScanBridge;
    private readonly NetworkScanBridge _networkScanBridge;

    public ScanBridgeFactory(ScanningContext scanningContext)
        : this(new InProcScanBridge(scanningContext), new WorkerScanBridge(scanningContext),
            new NetworkScanBridge(scanningContext))
    {
    }

    public ScanBridgeFactory(InProcScanBridge inProcScanBridge, WorkerScanBridge workerScanBridge,
        NetworkScanBridge networkScanBridge)
    {
        _inProcScanBridge = inProcScanBridge;
        _workerScanBridge = workerScanBridge;
        _networkScanBridge = networkScanBridge;
    }

    public IScanBridge Create(ScanOptions options)
    {
        if (!string.IsNullOrEmpty(options.NetworkOptions.Ip))
        {
            // The physical scanner is connected to a different computer, so we connect to a NAPS2 server process over the network
            return _networkScanBridge;
        }
        if (options.Driver == Driver.Sane)
        {
            // Run SANE in a worker process for added stability
            return _workerScanBridge;
        }
        if (options is { Driver: Driver.Twain, TwainOptions.Adapter: TwainAdapter.Legacy })
        {
            // Legacy twain needs to run in a 32-bit worker
            // (Normal twain also does, but it runs the worker at a lower level via RemoteTwainSessionController)
            return _workerScanBridge;
        }
        return _inProcScanBridge;
    }
}