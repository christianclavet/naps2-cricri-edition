﻿using NAPS2.Dependencies;
using NAPS2.EtoForms;
using NAPS2.EtoForms.WinForms;
using NAPS2.ImportExport;
using NAPS2.ImportExport.Pdf;
using NAPS2.Scan;
using NAPS2.Scan.Batch;
using NAPS2.WinForms;
using Ninject;
using Ninject.Modules;

namespace NAPS2.Modules;

public class WinFormsModule : NinjectModule
{
    public override void Load()
    {
        Bind<IBatchScanPerformer>().To<BatchScanPerformer>();
        Bind<IPdfPasswordProvider>().To<WinFormsPdfPasswordProvider>();
        Bind<ErrorOutput>().To<MessageBoxErrorOutput>();
        Bind<IOverwritePrompt>().To<WinFormsOverwritePrompt>();
        Bind<OperationProgress>().To<WinFormsOperationProgress>().InSingletonScope();
        Bind<IComponentInstallPrompt>().To<WinFormsComponentInstallPrompt>();
        Bind<DialogHelper>().To<WinFormsDialogHelper>();
        Bind<IEtoPlatform>().To<WinFormsEtoPlatform>();
        Bind<NotificationManager>().ToSelf().InSingletonScope();
        Bind<ISaveNotify>().ToMethod(ctx => ctx.Kernel.Get<NotificationManager>());
        Bind<IScannedImagePrinter>().To<PrintDocumentPrinter>();
        Bind<IDevicePrompt>().To<WinFormsDevicePrompt>();
    }
}